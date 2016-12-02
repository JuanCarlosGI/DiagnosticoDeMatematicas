using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Controllers
{
    public class SingleSelectionQuestionsController : Controller
    {
        private SiteContext db = new SiteContext();

        [HttpPost]
        public PartialViewResult Create(int examId)
        {
            var question = new SingleSelectionQuestion { Description = "Pregunta nueva", ExamID = examId };

            var list = new List<QuestionOption>();

            list.Add(new QuestionOption { Description = "Opción 1", Feedback = "Feedback de opción 1", IsCorrect = true });
            list.Add(new QuestionOption { Description = "Opción 2", Feedback = "Feedback de opción 2", IsCorrect = false });
            list.Add(new QuestionOption { Description = "Opción 3", Feedback = "Feedback de opción 3", IsCorrect = false });
            list.Add(new QuestionOption { Description = "Opción 4", Feedback = "Feedback de opción 4", IsCorrect = false });
            list.Add(new QuestionOption { Description = "Opción 5", Feedback = "Feedback de opción 5", IsCorrect = false });

            question.Options = list;

            db.SingleSelectionQuestions.Add(question);
            db.SaveChanges();

            var evaluator = new NotationlessEvaluator();
            question = evaluator.Evaluate(question) as SingleSelectionQuestion;
            return PartialView("_Details", question);
        }

        public PartialViewResult Details(int questionId)
        {
            var question = db.SingleSelectionQuestions.Find(questionId);

            var evaluator = new NotationlessEvaluator();
            question = evaluator.Evaluate(question) as SingleSelectionQuestion;
            return PartialView("_Details", question);
        }

        public PartialViewResult Edit(int questionId)
        {
            var question = db.SingleSelectionQuestions.Find(questionId);
            SingleSelectionQuestionWithOptionsViewModel model = new SingleSelectionQuestionWithOptionsViewModel
            {
                Id = questionId,
                ExamId = question.ExamID,
                Description = question.Description,
                Options = question.Options.ToList()
            };

            return PartialView("_Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult Edit([Bind(Include = "Id,Description,Options,ExamId")] SingleSelectionQuestionWithOptionsViewModel model)
        {
            if (ModelState.IsValid)
            {
                SingleSelectionQuestion question = new SingleSelectionQuestion
                {
                    Id = model.Id,
                    ExamID = model.ExamId,
                    Description = model.Description,
                    Options = model.Options
                };

                db.Entry(question).State = EntityState.Modified;
                foreach (var option in question.Options)
                {
                    db.Entry(option).State = EntityState.Modified;
                }

                db.SaveChanges();

                var evaluator = new NotationlessEvaluator();
                question = evaluator.Evaluate(question) as SingleSelectionQuestion;
                return PartialView("_Details", question);
            }

            return PartialView("_Edit", model);
        }

        [HttpPost]
        public PartialViewResult Delete(int questionId)
        {
            var question = db.SingleSelectionQuestions.Find(questionId);

            var options = question.Options.ToArray();
            foreach (var option in options)
                db.QuestionOptions.Remove(option);
            db.SaveChanges();

            db.SingleSelectionQuestions.Remove(question);
            db.SaveChanges();
            return PartialView("DeleteConfirmed");
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
