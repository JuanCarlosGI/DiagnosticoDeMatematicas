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
    public class VariablesController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Variables/Details/5
        public ActionResult Details(int? QuestionID, string Symbol)
        {
            if (QuestionID == null || Symbol == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variable variable = db.Variables.Find(Symbol, QuestionID);
            if (variable == null)
            {
                return HttpNotFound();
            }

            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }
            return View(variable);
        }

        // GET: Variables/Create
        public ActionResult Create(int? QuestionID)
        {
            if (QuestionID == null)
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

            Variable variable = new Variable { QuestionID = QuestionID.Value };
            return View(variable);
        }

        // POST: Variables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuestionID,Symbol")] Variable variable)
        {
            Variable variable2 = db.Variables.Find(variable.Symbol, variable.QuestionID);
            if (variable2 != null)
            {
                ModelState.AddModelError("Symbol", "Esa variable ya existe.");
            }
            if (ModelState.IsValid)
            {
                db.Variables.Add(variable);
                db.SaveChanges();

                return RedirectToAction("Details", "Questions", new { id = variable.QuestionID });
            }

            return View(variable);
        }
        
        // GET: Variables/Delete/5
        public ActionResult Delete(int? QuestionID, string Symbol)
        {
            if (QuestionID == null || Symbol == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variable variable = db.Variables.Find(Symbol, QuestionID);
            if (variable == null)
            {
                return HttpNotFound();
            }

            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(variable);
        }

        // POST: Variables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int QuestionID,  string Symbol)
        {
            Variable variable = db.Variables.Find(Symbol, QuestionID);
            db.Variables.Remove(variable);
            db.SaveChanges();
            return RedirectToAction("Details", "Questions", new { id = variable.QuestionID });
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