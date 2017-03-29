using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using DiagnosticoDeMatematicas.Models;

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

        public MultipleSelectionQuestion FindQuestion(int questionId)
        {
            return _db.MultipleSelectionQuestions.Find(questionId);
        }
    }
}