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
    public class RangesController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Ranges/Create
        public ActionResult Create(int? QuestionId, string Symbol)
        {
            if (QuestionId == null || Symbol == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            Range range = new Range { QuestionId = QuestionId.Value, Symbol = Symbol };
            return View(range);
        }

        // POST: Ranges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuestionId,Symbol,Minimum,Maximum")] Range range)
        {
            if (ModelState.IsValid)
            {
                db.Ranges.Add(range);
                db.SaveChanges();
                return RedirectToAction("Details", "Variables", new { QuestionID = range.QuestionId, Symbol = range.Symbol });
            }

            return View(range);
        }

        // GET: Ranges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // POST: Ranges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QuestionId,Symbol,Minimum,Maximum")] Range range)
        {
            if (ModelState.IsValid)
            {
                db.Entry(range).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Variables", new { QuestionID = range.QuestionId, Symbol = range.Symbol });
            }
            return View(range);
        }

        // GET: Ranges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            Range range = db.Ranges.Find(id.Value);
            if (range == null)
            {
                return HttpNotFound();
            }
            return View(range);
        }

        // POST: Ranges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            Range range = db.Ranges.Find(id);
            var symbol = range.Symbol;
            db.Ranges.Remove(range);
            db.SaveChanges();
            return RedirectToAction("Details", "Variables", new { QuestionID = range.QuestionId, Symbol = symbol });
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
