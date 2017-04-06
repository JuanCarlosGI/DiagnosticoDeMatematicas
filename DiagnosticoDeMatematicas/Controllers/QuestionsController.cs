using System.Web.Mvc;
using DiagnosticoDeMatematicas.Services.QuestionsService;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionsService _service;

        public QuestionsController()
        {
            _service = new QuestionsService(new DAL.SiteContext());
        }

        public QuestionsController(QuestionsService service)
        {
            _service = service;
        }

        public PartialViewResult CreateNew(int examId)
        {
            return PartialView("CreateNew", examId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.DisposeDb();
            }
            base.Dispose(disposing);
        }

        public ActionResult TestCombinations(int questionId)
        {
            var question = _service.FindQuestion(questionId);
            var combinations = _service.GetCombinations(question);
            ViewBag.Notation = _service.EvaluateNotationless(question);

            return View(combinations);
        }
    }
}
