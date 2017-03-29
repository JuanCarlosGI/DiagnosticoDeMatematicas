using System.Net;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Services.ExamsService;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IExamsService _service;

        public ExamsController()
        {
            _service = new ExamsService(new SiteContext());
        }

        public ExamsController(IExamsService service)
        {
            _service = service;
        }

        // GET: Exams
        public ActionResult Index()
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            var model = _service.GetExamList();
            return View(model);
        }

        // GET: Exams/Details/5
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

            Exam exam = _service.FindExam(id.Value);
            if (exam == null)
            {
                return HttpNotFound();
            }

            return View(exam);
        }

        public PartialViewResult DetailsPartial(int examId)
        {
            Exam exam = _service.FindExam(examId);
            return PartialView("_Details", exam);
        }

        public PartialViewResult EditPartial(int examId)
        {
            Exam exam = _service.FindExam(examId);
            return PartialView("_Edit", exam);
        }

        [HttpPost]
        public PartialViewResult EditPartial([Bind(Include = "ID,Name,Description,Comments,Active")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _service.SaveExam(exam);
                return PartialView("_Details", exam);
            }
            return PartialView("_Edit", exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            return View(new Exam());
        }

        // POST: Exams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Comments,Active")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                _service.AddExam(exam);
                return RedirectToAction("Index");
            }

            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
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

            Exam exam = _service.FindExam(id.Value);
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
            if (!SessionValidator.IsAdminSignedIn)
            {
                if (SessionValidator.IsSignedIn)
                {
                    return RedirectToAction("AccessDenied", "Home");
                }

                return RedirectToAction("SignIn", "Home");
            }

            _service.DeleteExam(id);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.DisposeDb();
            }

            base.Dispose(disposing);
        }
    }
}
