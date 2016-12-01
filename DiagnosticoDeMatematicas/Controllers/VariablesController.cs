namespace DiagnosticoDeMatematicas.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using DAL;
    using Models;
    using Helpers;

    public class VariablesController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Variables/Details/5
        public ActionResult Details(int? questionID, string symbol)
        {
            if (questionID == null || symbol == null)
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

            Variable variable = db.Variables.Find(symbol, questionID);
            if (variable == null)
            {
                return HttpNotFound();
            }

            return View(variable);
        }

        // GET: Variables/Create
        public ActionResult Create(int? questionID)
        {
            if (questionID == null)
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

            Variable variable = new Variable { QuestionId = questionID.Value };
            return View(variable);
        }

        // POST: Variables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuestionID,Symbol")] Variable variable)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            if (ModelState.IsValid)
            {
                db.Variables.Add(variable);
                db.SaveChanges();

                return RedirectToAction("Details", "Questions", new { id = variable.QuestionId });
            }

            return View(variable);
        }
        
        // GET: Variables/Delete/5
        public ActionResult Delete(int? questionID, string symbol)
        {
            if (questionID == null || symbol == null)
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

            Variable variable = db.Variables.Find(symbol, questionID);
            if (variable == null)
            {
                return HttpNotFound();
            }

            return View(variable);
        }

        // POST: Variables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int questionID,  string symbol)
        {
            Variable variable = db.Variables.Find(symbol, questionID);
            db.Variables.Remove(variable);
            db.SaveChanges();
            return RedirectToAction("Details", "Questions", new { id = variable.QuestionId });
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