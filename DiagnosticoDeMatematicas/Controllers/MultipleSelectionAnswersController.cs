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
    public class MultipleSelectionAnswersController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: MultipleSelectionAnswers
        public ActionResult Index()
        {
            var multipleSelectionAnswers = db.MultipleSelectionAnswers.Include(m => m.Question).Include(m => m.Response);
            return View(multipleSelectionAnswers.ToList());
        }

        // GET: MultipleSelectionAnswers/Details/5
        public PartialViewResult Details(int responseId, int questionId)
        {
            MultipleSelectionAnswer multipleSelectionAnswer = db.MultipleSelectionAnswers.Find(responseId, questionId);
            return PartialView("_Details", multipleSelectionAnswer);
        }

        // GET: MultipleSelectionAnswers/Create
        public ActionResult Create()
        {
            ViewBag.MultipleSelectionQuestionId = new SelectList(db.MultipleSelectionQuestions, "Id", "Description");
            ViewBag.ResponseId = new SelectList(db.Responses, "ID", "UserID");
            return View();
        }

        // POST: MultipleSelectionAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResponseId,MultipleSelectionQuestionId")] MultipleSelectionAnswer multipleSelectionAnswer)
        {
            if (ModelState.IsValid)
            {
                db.MultipleSelectionAnswers.Add(multipleSelectionAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MultipleSelectionQuestionId = new SelectList(db.MultipleSelectionQuestions, "Id", "Description", multipleSelectionAnswer.QuestionId);
            ViewBag.ResponseId = new SelectList(db.Responses, "ID", "UserID", multipleSelectionAnswer.ResponseId);
            return View(multipleSelectionAnswer);
        }

        // GET: MultipleSelectionAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleSelectionAnswer multipleSelectionAnswer = db.MultipleSelectionAnswers.Find(id);
            if (multipleSelectionAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.MultipleSelectionQuestionId = new SelectList(db.MultipleSelectionQuestions, "Id", "Description", multipleSelectionAnswer.QuestionId);
            ViewBag.ResponseId = new SelectList(db.Responses, "ID", "UserID", multipleSelectionAnswer.ResponseId);
            return View(multipleSelectionAnswer);
        }

        // POST: MultipleSelectionAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResponseId,MultipleSelectionQuestionId")] MultipleSelectionAnswer multipleSelectionAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(multipleSelectionAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultipleSelectionQuestionId = new SelectList(db.MultipleSelectionQuestions, "Id", "Description", multipleSelectionAnswer.QuestionId);
            ViewBag.ResponseId = new SelectList(db.Responses, "ID", "UserID", multipleSelectionAnswer.ResponseId);
            return View(multipleSelectionAnswer);
        }

        // GET: MultipleSelectionAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultipleSelectionAnswer multipleSelectionAnswer = db.MultipleSelectionAnswers.Find(id);
            if (multipleSelectionAnswer == null)
            {
                return HttpNotFound();
            }
            return View(multipleSelectionAnswer);
        }

        // POST: MultipleSelectionAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MultipleSelectionAnswer multipleSelectionAnswer = db.MultipleSelectionAnswers.Find(id);
            db.MultipleSelectionAnswers.Remove(multipleSelectionAnswer);
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
