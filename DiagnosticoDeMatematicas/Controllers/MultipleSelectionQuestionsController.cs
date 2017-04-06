using System.Web.Mvc;
using DiagnosticoDeMatematicas.Models.ViewModels.MultipleSelectionQuestion;
using DiagnosticoDeMatematicas.Services.MultipleSelectionQuestionService;

namespace DiagnosticoDeMatematicas.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MultipleSelectionQuestionsController : Controller
    {
        private readonly IMultipleSelectionQuestionService _service;

        public MultipleSelectionQuestionsController()
        {
            _service = new MultipleSelectionQuestionService(new DAL.SiteContext());
        }

        public MultipleSelectionQuestionsController(IMultipleSelectionQuestionService service)
        {
            _service = service;
        }


        [HttpPost]
        public PartialViewResult Create(int examId)
        {
            var question = _service.CreateQuestion(examId);
            question = _service.EvaluateNotationless(question);

            return PartialView("_Details", question);
        }

        public PartialViewResult Details(int questionId)
        {
            var question = _service.FindQuestion(questionId);
            question = _service.EvaluateNotationless(question);

            return PartialView("_Details", question);
        }

        public PartialViewResult Edit(int questionId)
        {
            var viewModel = _service.GetQuestionWithOptions(questionId);
            return PartialView("_Edit", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit([Bind(Include = "Id,Description,Options,ExamId")] QuestionWithOptionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                _service.SaveQuestion(model);
                var question = _service.FindQuestion(model.Id);
                question = _service.EvaluateNotationless(question);
                return PartialView("_Details", question);
            }

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public PartialViewResult Delete(int questionId)
        {
            _service.DeleteQuestion(questionId);
            return PartialView("DeleteConfirmed");
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
