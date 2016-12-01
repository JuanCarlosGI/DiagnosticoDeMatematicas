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
    public class SelectionQuestionsController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: SelectionQuestions
        public ActionResult Index()
        {
            var questionAbstracts = db.QuestionAbstracts.Include(s => s.Exam);
            return View(questionAbstracts.ToList());
        }

        // GET: SelectionQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectionQuestion selectionQuestion = db.QuestionAbstracts.Find(id);
            if (selectionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(selectionQuestion);
        }

        // GET: SelectionQuestions/Create
        public ActionResult Create()
        {
            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name");
            return View();
        }

        // POST: SelectionQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ExamID,Description")] SelectionQuestion selectionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.QuestionAbstracts.Add(selectionQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", selectionQuestion.ExamID);
            return View(selectionQuestion);
        }

        // GET: SelectionQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectionQuestion selectionQuestion = db.QuestionAbstracts.Find(id);
            if (selectionQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", selectionQuestion.ExamID);
            return View(selectionQuestion);
        }

        // POST: SelectionQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ExamID,Description")] SelectionQuestion selectionQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(selectionQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamID = new SelectList(db.Exams, "ID", "Name", selectionQuestion.ExamID);
            return View(selectionQuestion);
        }

        // GET: SelectionQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectionQuestion selectionQuestion = db.QuestionAbstracts.Find(id);
            if (selectionQuestion == null)
            {
                return HttpNotFound();
            }
            return View(selectionQuestion);
        }

        // POST: SelectionQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SelectionQuestion selectionQuestion = db.QuestionAbstracts.Find(id);
            db.QuestionAbstracts.Remove(selectionQuestion);
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
