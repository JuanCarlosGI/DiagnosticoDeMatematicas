using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class ExamsController : Controller
    {
        private SiteContext db = new SiteContext();

        // GET: Exams
        public ActionResult Index()
        {
            if(Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View(db.Exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
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

            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            if (Session.Contents["Email"] == null)
            {
                return RedirectToAction("SignIn", "Home");
            }

            if ((Role)Session.Contents["Role"] != Role.Administrador)
            {
                return RedirectToAction("AccessDenied", "Home");
            }

            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Active")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam);
        }

        // GET: Exams/Edit/5
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

            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Active")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam);
        }

        // GET: Exams/Delete/5
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

            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
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

            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
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
