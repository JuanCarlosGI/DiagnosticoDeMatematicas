namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using System.Web.Mvc;
    using DAL;
    using Models;
    using Helpers;

    public class RangesController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Ranges/Create
        public ActionResult Create(int? questionId, string symbol)
        {
            if (questionId == null || symbol == null)
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

            Range range = new Range { QuestionId = questionId.Value, Symbol = symbol };
            return View(range);
        }

        // POST: Ranges/Create
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

            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            Range range = db.Ranges.Find(id);
            if (range == null)
            {
                return HttpNotFound();
            }

            return View(range);
        }

        // POST: Ranges/Edit/5
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

            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
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
