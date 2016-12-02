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

        public PartialViewResult CreateNew(int examId)
        {
            return PartialView("CreateNew", examId);
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
