namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using DAL;
    using Models;
    using Helpers.IEvaluator;
    using Helpers;

    public class QuestionsController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }

            var evaluator = new NotationlessEvaluator();
            return View(evaluator.Evaluate(question));
        }

        // GET: Questions/Create
        public ActionResult Create(int? examId)
        {
            if (examId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var question = new Question { ExamID = examId.Value };
            return View(question);
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ExamID,Description,OptionA,OptionACorrect,OptionAFeedback,OptionB,OptionBCorrect,OptionBFeedback,OptionC,OptionCCorrect,OptionCFeedback,OptionD,OptionDCorrect,OptionDFeedback")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Details", "Exams", new { id = question.ExamID });
            }

            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", question.ExamID);
            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", question.ExamID);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ExamID,Description,OptionA,OptionACorrect,OptionAFeedback,OptionB,OptionBCorrect,OptionBFeedback,OptionC,OptionCCorrect,OptionCFeedback,OptionD,OptionDCorrect,OptionDFeedback")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Exams", new { id = question.ExamID });
            }

            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", question.ExamID);
            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var answers = db.Answers.Where(a => a.QuestionID == id).ToList();
            foreach (Answer answer in answers)
            {
                db.Answers.Remove(answer);
            }

            db.SaveChanges();

            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Details", "Exams", new { id = question.ExamID });
        }

        public ActionResult Instructions()
        {
            return View();
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
