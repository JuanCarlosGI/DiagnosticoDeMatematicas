using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.IO;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class ResponsesController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Responses
        public ActionResult Index()
        {
            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            List<Response> responses;
            if ((Role)Session.Contents["Role"] == Role.Administrador)
            {
                responses = db.Responses.Include(r => r.Exam).Include(r => r.User).ToList();
            }
            else
            {
                var email = (string)Session.Contents["Email"];
                responses = db.Responses.Where(r => r.UserID == email).Include(r => r.Exam).Include(r => r.User).ToList();
            }
            
            return View(responses);
        }

        public ActionResult StatisticDetails()
        {
            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", "");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StatisticDetails([Bind(Include = "ExamID,StartDate,EndDate")]Models.ViewModels.StatisticsDetails details)
        {
            if (details.StartDate != null && details.EndDate != null && details.StartDate.Value > details.EndDate.Value)
            {
                ModelState.AddModelError("EndDate", "La fecha de terminación debe ser igual o mayor a la fecha de inicio.");
            }
            else
            {
                if (!details.ExamID.HasValue)
                {
                    return RedirectToAction("GlobalStatistics", "Responses", details);
                }
                return RedirectToAction("Statistics", "Responses", details);
            }

            details.ExamID = 0;
            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name");
            return View(details);
        }

        public ActionResult Statistics(Models.ViewModels.StatisticsDetails details)
        {
            var responses = from r in db.Responses
                        where !details.ExamID.HasValue || r.ExamID == details.ExamID.Value
                        where !details.StartDate.HasValue || r.Date >= details.StartDate.Value
                        where !details.EndDate.HasValue || r.Date <= details.EndDate.Value
                        select r;

            var statistics = new Models.ViewModels.StatisticsGenerator { responses = responses, Exam = db.Exams.Find(details.ExamID.Value) };

            var chart1 = new Chart();
            chart1.Width = 1000;
            chart1.Height = 400;
            chart1.ChartAreas.Add("xAxis").BackColor = Color.White;
            chart1.Series.Add("xAxis");

            var counter = 0;
            foreach (var result in statistics.GradeRanges)
            {
                chart1.Series["xAxis"].Points.AddXY(counter.ToString(), result);
                counter++;
            }

            chart1.Series["xAxis"].IsValueShownAsLabel = true;
            chart1.Series["xAxis"].LabelForeColor = Color.Black;
            chart1.Series["xAxis"].LabelFormat = "{0:0.00}%";
            chart1.ChartAreas[0].AxisX.Title = "Reactivos correctos (n de cada 20)";
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = true;
            chart1.ChartAreas[0].AxisY.Title = "Porcentaje de alumnos";
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.Maximum = (Math.Ceiling(statistics.GradeRanges.Max() / 10) + 1 ) * 10;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.BackColor = Color.White;

            MemoryStream imageStream = new MemoryStream();
            chart1.SaveImage(imageStream, ChartImageFormat.Png);
            byte[] arrbyte = imageStream.ToArray();
            ViewBag.Chart = Convert.ToBase64String(arrbyte);

            return View(statistics);
        }

        public ActionResult GlobalStatistics(Models.ViewModels.StatisticsDetails details)
        {
            var responses = from r in db.Responses
                            where !details.StartDate.HasValue || r.Date >= details.StartDate.Value
                            where !details.EndDate.HasValue || r.Date <= details.EndDate.Value
                            select r;

            return View(responses);
        }

        // GET: Responses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Response response = db.Responses.Find(id);

            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if (response == null)
            {
                return HttpNotFound();
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador &&
                response.UserID != (string)Session.Contents["Email"])
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(response);
        }

        // GET: Responses/Create
        public ActionResult Create(int? ExamId)
        {
            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if (ExamId == null || db.Exams.Find(ExamId.Value) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ResponseWithAnswers response = new ResponseWithAnswers { ExamID = ExamId.Value, UserID = (string)Session.Contents["Email"], Exam = db.Exams.Find(ExamId) };

            var answers = new List<QuestionAnswer>();
            foreach (var question in response.Exam.Questions)
            {
                answers.Add(new QuestionAnswer { QuestionID = question.ID, SelectedOption = -1 });
            }

            response.Choices = answers;

            return View(response);
        }

        // POST: Responses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,ExamID,Choices")]ResponseWithAnswers responseWithAnswers)
        {
            var response = new Response
            {
                ExamID = responseWithAnswers.ExamID,
                UserID = responseWithAnswers.UserID,
                Date = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                db.Responses.Add(response);
                db.SaveChanges();

                foreach (var answer in responseWithAnswers.Choices)
                {
                    var choice = new Choice();
                    if (answer.SelectedOption == 0) choice = Choice.A;
                    else if (answer.SelectedOption == 1) choice = Choice.B;
                    else if (answer.SelectedOption == 1) choice = Choice.C;
                    else choice = Choice.D;
                    db.Answers.Add(new Answer { QuestionID = answer.QuestionID, ResponseID = response.ID, Choice = choice });
                }
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", response.ExamID);
            ViewBag.UserID = new SelectList(db.Users, "Email", "FullName", response.UserID);
            return View(response);
        }

        // GET: Responses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }

            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador &&
                response.UserID != (string)Session.Contents["Email"])
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            return View(response);
        }

        // POST: Responses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Response response = db.Responses.Find(id);
            db.Responses.Remove(response);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
