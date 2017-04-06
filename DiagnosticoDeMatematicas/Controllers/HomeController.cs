using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models.ViewModels.Home;
using DiagnosticoDeMatematicas.Services.HomeService;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _service;

        public HomeController()
        {
            _service = new HomeService(new SiteContext());
        }

        public HomeController(IHomeService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.GetActiveExams());
        }

        public ActionResult SignIn()
        {
            return View(new SignInViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _service.GetUser(model.UserName, model.Password);
                if (user != null)
                {
                    _service.LoginUser(user);
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Usuario o contraseña inválidos");
            return View(model);
        }
        
        [Authorize]
        public ActionResult SignOut()
        {
            _service.SignOut();
            return RedirectToAction("Index");
        }

        public PartialViewResult Evaluations()
        {
            var evaluations = _service.Evaluations();
            return PartialView("_Evaluations", evaluations);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult ChangeEvaluation(int evaluation)
        {
            ViewBag.ExamID = new SelectList(_service.GetExams(), "ID", "Name", string.Empty);
            return View(new ChangeEvaluationViewModel {Evaluation = evaluation, ExamId = 0});
        }
        
        public ActionResult Exam()
        {
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

            ViewBag.ExamID = new SelectList(_service.GetExams(), "ID", "Name", string.Empty);

            return View(model);
        }
    }
}