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
    using Helpers.Extensions;
    using Helpers.IEvaluator;
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

            Response response = new Response { ExamId = examId.Value, UserId = SessionService.User.Email, Exam = db.Exams.Find(examId) };

            var answers = new List<AnswerAbstract>();
            foreach (var question in response.Exam.Questions)
            {
                if (question is SingleSelectionQuestion)
                    answers.Add(new SingleSelectionAnswer { Question = question as SingleSelectionQuestion, QuestionId = question.Id });
                else if (question is MultipleSelectionQuestion)
                    answers.Add(new MultipleSelectionAnswer(question as MultipleSelectionQuestion, null));
            }

            var evaluator = new RandomValueEvaluator();
            foreach (var answer in answers)
            {
                if (answer is SelectionAnswer)
                {
                    (answer.Question as SelectionQuestion).Options = (answer.Question as SelectionQuestion).Options.ToList().Shuffle().ToList();
                    answer.Question = evaluator.Evaluate(answer.Question);
                }
            }

            response.Answers = answers;

            return View(response);
        }

        // POST: Responses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,ExamId,Answers")]Response response)
        {
            response.Date = DateTime.Now;
            response.Exam = db.Exams.Find(response.ExamId);
            response.User = db.Users.Find(response.UserId);

            foreach(var answer in response.Answers)
            {
                answer.Question = db.QuestionAbstracts.Find(answer.QuestionId);
            }

            if (ModelState.IsValid)
            {
                db.Responses.Add(response);
                db.Entry(response).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("ThankYou");
            }
            
            return View(response);
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
