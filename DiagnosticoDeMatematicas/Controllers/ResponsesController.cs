using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class ResponsesController : Controller
    {
        private readonly SiteContext _db = new SiteContext();

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

            var responses = _db.Responses.Include(r => r.Exam).Include(r => r.User).ToList();
            foreach(var response in responses)
                foreach (var answer in response.Answers.ToArray())
                {
                    var multipleAnswer = answer as MultipleSelectionAnswer;
                    if (multipleAnswer != null)
                    {
                        response.Answers.Remove(answer);
                        response.Answers.Add(_db.MultipleSelectionAnswers
                            .Include(a => a.Selections)
                            .SingleOrDefault(e => e.QuestionId == answer.QuestionId && e.ResponseId == answer.ResponseId));
                    }
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

            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            Response response = _db.Responses.Find(id);
            if (response == null)
            {
                return HttpNotFound();
            }

            foreach (var answer in response.Answers.ToArray())
            {
                var multipleAnswer = answer as MultipleSelectionAnswer;
                if (multipleAnswer != null)
                {
                    response.Answers.Remove(answer);
                    response.Answers.Add(_db.MultipleSelectionAnswers
                        .Include(a => a.Selections)
                        .Include(a => a.Question)
                        .Include(a => a.Response)
                        .SingleOrDefault(e => e.QuestionId == answer.QuestionId && e.ResponseId == answer.ResponseId));
                }
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

            if (examId == null || _db.Exams.Find(examId.Value) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Response response = new Response { ExamId = examId.Value, UserId = SessionService.User.Email, Exam = _db.Exams.Find(examId) };

            var answers = new List<Answer>();
            foreach (var question in response.Exam.Questions)
            {
                if (question is SingleSelectionQuestion)
                    answers.Add(new SingleSelectionAnswer { Question = question as SingleSelectionQuestion, QuestionId = question.Id });
                else if (question is MultipleSelectionQuestion)
                    answers.Add(new MultipleSelectionAnswer(question as MultipleSelectionQuestion));
            }

            var evaluator = new RandomValueEvaluator();
            foreach (var answer in answers)
            {
                if (answer is SelectionAnswer)
                {
                    var question = _db.SelectionQuestions.Find(answer.QuestionId);
                    question.Options = question.Options.ToList().Shuffle().ToList();
                    answer.Question = evaluator.Evaluate(question);
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
            response.Exam = _db.Exams.Find(response.ExamId);
            response.User = _db.Users.Find(response.UserId);

            foreach(var answer in response.Answers)
            {
                answer.Question = _db.Questions.Find(answer.QuestionId);
            }

            if (ModelState.IsValid)
            {
                _db.Responses.Add(response);
                _db.Entry(response).State = EntityState.Added;
                _db.SaveChanges();

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

            Response response = _db.Responses.Find(id);
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
            Response response = _db.Responses.Find(id);
            _db.Responses.Remove(response);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
