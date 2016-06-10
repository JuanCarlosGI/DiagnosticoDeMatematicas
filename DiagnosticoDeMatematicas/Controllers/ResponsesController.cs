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
                responses = db.Responses.Where(r => r.UserID == (string)Session.Contents["Email"]).Include(r => r.Exam).Include(r => r.User).ToList();
            }
            
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
            if (response == null)
            {
                return HttpNotFound();
            }
            return View(response);
        }

        // GET: Responses/Create
        public ActionResult Create(int? ExamId)
        {
            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("Index", "Home");
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
