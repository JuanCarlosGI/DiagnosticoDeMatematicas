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
    using System.Collections.Generic;
    public class QuestionsController : Controller
    {
        private SiteContext db = new SiteContext();

        public ActionResult Index()
        {
            return View(db.MultipleSelectionQuestions.ToList());
        }

        // GET: MultipleSelectionQuestions/Details/5
        public PartialViewResult Details(int id)
        {
            SelectionQuestion selectionQuestion = db.QuestionAbstracts.Find(id);

            var evaluator = new NotationlessEvaluator();
            selectionQuestion = evaluator.Evaluate(selectionQuestion) as SelectionQuestion;
            return PartialView("_Details", selectionQuestion);
        }

        // GET: MultipleSelectionQuestions/Create
        public ActionResult Create()
        {
            var model = new MultipleSelectionQuestion { Description = "Pregunta nueva" };

            var list = new List<QuestionOption>();

            list.Add(new QuestionOption { Description = "Opción 1", Feedback = "Feedback de opción 1", IsCorrect = true, });
            list.Add(new QuestionOption { Description = "Opción 2", Feedback = "Feedback de opción 2", IsCorrect = false, });
            list.Add(new QuestionOption { Description = "Opción 3", Feedback = "Feedback de opción 3", IsCorrect = false, });
            list.Add(new QuestionOption { Description = "Opción 4", Feedback = "Feedback de opción 4", IsCorrect = false, });
            list.Add(new QuestionOption { Description = "Opción 5", Feedback = "Feedback de opción 5", IsCorrect = false, });

            model.Options = list;

            return Create(model);
        }

        // POST: MultipleSelectionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] MultipleSelectionQuestion multipleSelectionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.MultipleSelectionQuestions.Add(multipleSelectionQuestion);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(multipleSelectionQuestion);
        }

        // GET: MultipleSelectionQuestions/Edit/5
        public PartialViewResult Edit(int id)
        {
            SelectionQuestion selectionQuestion = db.QuestionAbstracts.Find(id);
            SelectionQuestionWithOptionsViewModel model = new SelectionQuestionWithOptionsViewModel
            {
                Id = id,
                Description = selectionQuestion.Description,
                Options = selectionQuestion.Options.ToList()
            };

            return PartialView("_Edit", model);
        }

        // POST: MultipleSelectionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit([Bind(Include = "Id,Description,Options")] SelectionQuestionWithOptionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                MultipleSelectionQuestion multipleSelectionQuestion = new MultipleSelectionQuestion
                {
                    Id = model.Id,
                    Description = model.Description,
                    Options = model.Options
                };

                db.Entry(multipleSelectionQuestion).State = EntityState.Modified;
                foreach (var option in multipleSelectionQuestion.Options)
                {
                    db.Entry(option).State = EntityState.Modified;
                }

                db.SaveChanges();

                return PartialView("_Details", multipleSelectionQuestion);
            }

            return PartialView("_Edit", model);
        }

        // GET: MultipleSelectionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleSelectionQuestion multipleSelectionQuestion = db.MultipleSelectionQuestions.Find(id);
            if (multipleSelectionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(multipleSelectionQuestion);
        }

        // POST: MultipleSelectionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultipleSelectionQuestion multipleSelectionQuestion = db.MultipleSelectionQuestions.Find(id);
            db.MultipleSelectionQuestions.Remove(multipleSelectionQuestion);
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
