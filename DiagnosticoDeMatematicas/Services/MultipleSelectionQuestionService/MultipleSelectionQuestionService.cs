using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Models.ViewModels.MultipleSelectionQuestion;

namespace DiagnosticoDeMatematicas.Services.MultipleSelectionQuestionService
{
    public class MultipleSelectionQuestionService : IMultipleSelectionQuestionService
    {
        private readonly SiteContext _db;

        public MultipleSelectionQuestionService(SiteContext db)
        {
            _db = db;
        }

        public MultipleSelectionQuestion CreateQuestion(int examId)
        {
            var question = new MultipleSelectionQuestion { Description = "Pregunta nueva", ExamId = examId };

            var list = new List<QuestionOption>
            {
                new QuestionOption {Description = "Opción 1", Feedback = "Feedback de opción 1", IsCorrect = true},
                new QuestionOption {Description = "Opción 2", Feedback = "Feedback de opción 2", IsCorrect = false},
                new QuestionOption {Description = "Opción 3", Feedback = "Feedback de opción 3", IsCorrect = false},
                new QuestionOption {Description = "Opción 4", Feedback = "Feedback de opción 4", IsCorrect = false},
                new QuestionOption {Description = "Opción 5", Feedback = "Feedback de opción 5", IsCorrect = false}
            };

            question.Options = list;

            _db.MultipleSelectionQuestions.Add(question);
            _db.SaveChanges();

            return question;
        }

        public MultipleSelectionQuestion EvaluateNotationless(MultipleSelectionQuestion question)
        {
            var evaluator = new NotationlessEvaluator();
            return evaluator.Evaluate(question) as MultipleSelectionQuestion;
        }

        public QuestionWithOptionsViewModel GetQuestionWithOptions(int questionId)
        {
            var question = FindQuestion(questionId);
            var model = new QuestionWithOptionsViewModel
            {
                Id = questionId,
                ExamId = question.ExamId,
                Description = question.Description,
                Options = question.Options.ToList()
            };

            return model;
        }

        public void SaveQuestion(QuestionWithOptionsViewModel model)
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
        }

        public MultipleSelectionQuestion FindQuestion(int questionId)
        {
            return _db.MultipleSelectionQuestions.Include(q => q.Variables).Single(q => q.Id == questionId);
        }

        public void DeleteQuestion(int questionId)
        {
            var question = _db.MultipleSelectionQuestions.Find(questionId);

            foreach (var answer in question.Answers.ToArray())
                _db.MultipleSelectionAnswers.Remove(answer as MultipleSelectionAnswer);
            _db.SaveChanges();

            _db.Questions.Remove(question);
            _db.SaveChanges();
        }

        public void DisposeDb()
        {
            _db.Dispose();
        }
    }
}