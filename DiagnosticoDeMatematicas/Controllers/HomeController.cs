using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Models.ViewModels;
using DiagnosticoDeMatematicas.Services;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class HomeController : Controller
    {
        private readonly SiteContext _db = new SiteContext();
        private readonly HomeService _service;

        public HomeController()
        {
            _service = new HomeService(_db);
        }

        public ActionResult Index()
        {
            return View(_db.Exams.Where(m => m.Active).ToList());
        }

        public ActionResult SignIn(string email, string password)
        {
            if (!SessionValidator.IsSignedIn && !SessionManager.TrySignIn(email, password))
            {
                return View();
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult SignOut()
        {
            SessionManager.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        public PartialViewResult Evaluations()
        {
            var evaluations = _service.Evaluations();
            return PartialView("_Evaluations", evaluations);
        }

        public ActionResult ChangeEvaluation(int evaluation)
        {
            if (!SessionValidator.IsAdminSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            ViewBag.ExamID = new SelectList(_db.Exams, "ID", "Name", string.Empty);

            return View(new ChangeEvaluationViewModel {Evaluation = evaluation, ExamId = 0});
        }

        public ActionResult Exam()
        {
            if (!SessionValidator.IsSignedIn)
            {
                return RedirectToAction("SignIn", "Home");
            }

            return View();
        }

        public PartialViewResult ApprovedEvaluations()
        {
            var model = _service.ApprovedEvaluations();
            return PartialView("_ApprovedEvaluations", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeEvaluation(ChangeEvaluationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.ChangeEvaluation(model.Evaluation, model.ExamId);
                return RedirectToAction("Index");
            }

            ViewBag.ExamID = new SelectList(_db.Exams, "ID", "Name", string.Empty);

            return View(model);
        }
    }
}