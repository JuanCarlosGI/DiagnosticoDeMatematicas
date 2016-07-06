namespace DiagnosticoDeMatematicas.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using DAL;
    using Helpers;
    using Models;
    using Models.ViewModels;

    public class ResponsesController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Responses
        public ActionResult Index()
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var responses = db.Responses.Include(r => r.Exam).Include(r => r.User).ToList();
            
            return View(responses);
        }

        public ActionResult StatisticDetails()
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", string.Empty);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StatisticDetails([Bind(Include = "ExamID,StartDate,EndDate")]StatisticDetailsViewModel details)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

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

        public ActionResult Statistics(StatisticDetailsViewModel details)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var statistics = new StatisticsViewModel
            {
                Responses = db.Responses.ToList(),
                Exam = db.Exams.Find(details.ExamID.Value),
                StartDate = details.StartDate,
                EndDate = details.EndDate
            };

            return View(statistics);
        }

        public ActionResult GlobalStatistics(StatisticDetailsViewModel details)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var model = new GlobalStatisticsViewModel
            {
                Responses = db.Responses.ToList(),
                StartDate = details.StartDate,
                EndDate = details.EndDate
            };

            return View(model);
        }

        // GET: Responses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }

            if (!SessionValidator.IsAdminSignedIn &&
                response.User.Email != SessionService.User.Email)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(response);
        }

        // GET: Responses/Create
        public ActionResult Create(int? examId)
        {
            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if (examId == null || db.Exams.Find(examId.Value) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ResponseWithAnswersViewModel response = new ResponseWithAnswersViewModel { ExamID = examId.Value, UserID = (string)Session.Contents["Email"], Exam = db.Exams.Find(examId) };

            var answers = new List<QuestionAnswer>();
            foreach (var question in response.Exam.Questions)
            {
                answers.Add(new QuestionAnswer { Question = question, SelectedOption = -1, QuestionID = question.ID });
            }

            foreach (var answer in answers)
            {
                answer.Shuffle();
            }

            response.Choices = answers;

            return View(response);
        }

        // POST: Responses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,ExamID,Choices")]ResponseWithAnswersViewModel responseWithAnswers)
        {
            var response = new Response
            {
                ExamID = responseWithAnswers.ExamID,
                UserID = responseWithAnswers.UserID,
                Date = DateTime.Now
            };

            foreach (var answer in responseWithAnswers.Choices)
            {
                answer.Question = db.Questions.Find(answer.QuestionID);
            }

            if (ModelState.IsValid)
            {
                db.Responses.Add(response);
                db.SaveChanges();

                foreach (var answer in responseWithAnswers.Choices)
                {
                    var choice = new Choice();
                    var selectedOption = answer.GetAnswer();
                    if (selectedOption == 0)
                    {
                        choice = Choice.A;
                    }
                    else if (selectedOption == 1)
                    {
                        choice = Choice.B;
                    }
                    else if (selectedOption == 2)
                    {
                        choice = Choice.C;
                    }
                    else
                    {
                        choice = Choice.D;
                    }

                    db.Answers.Add(new Answer { QuestionID = answer.Question.ID, ResponseID = response.ID, Choice = choice });
                }

                db.SaveChanges();

                return RedirectToAction("ThankYou");
            }
            
            return View(responseWithAnswers);
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        // GET: Responses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            Response response = db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }

            if (!SessionValidator.IsAdminSignedIn &&
                response.User.Email != SessionService.User.Email)
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
