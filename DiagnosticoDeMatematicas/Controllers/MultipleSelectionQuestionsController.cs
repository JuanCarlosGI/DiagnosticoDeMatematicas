using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Models.ViewModels;
using DiagnosticoDeMatematicas.Services.MultipleSelectionQuestionService;

namespace DiagnosticoDeMatematicas.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class MultipleSelectionQuestionsController : Controller
    {
        private readonly SiteContext _db = new SiteContext();
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
            // TODO: refactor into service
            var question = _db.MultipleSelectionQuestions.Find(questionId);
            var model = new MultipleSelectionQuestionWithOptionsViewModel
            {
                Id = questionId,
                ExamId = question.ExamId,
                Description = question.Description,
                Options = question.Options.ToList()
            };

            return PartialView("_Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit([Bind(Include = "Id,Description,Options,ExamId")] MultipleSelectionQuestionWithOptionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                MultipleSelectionQuestion question = new MultipleSelectionQuestion
                {
                    Id = model.Id,
                    ExamId = model.ExamId,
                    Description = model.Description,
                    Options = model.Options
                };

                _db.Entry(question).State = EntityState.Modified;
                foreach (var option in question.Options)
                {
                    _db.Entry(option).State = EntityState.Modified;
                }

                _db.SaveChanges();

                question = _db.MultipleSelectionQuestions.Include(q => q.Variables).Single(q => q.Id == question.Id);
                var evaluator = new NotationlessEvaluator();
                question = evaluator.Evaluate(question) as MultipleSelectionQuestion;
                return PartialView("_Details", question);
            }

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public PartialViewResult Delete(int questionId)
        {
            var question = _db.MultipleSelectionQuestions.Find(questionId);

            foreach (var answer in question.Answers.ToArray())
                _db.MultipleSelectionAnswers.Remove(answer as MultipleSelectionAnswer);
            _db.SaveChanges();

            _db.Questions.Remove(question);
            _db.SaveChanges();
            return PartialView("DeleteConfirmed");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
