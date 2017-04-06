using System.Collections.Generic;
using System.Linq;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Helpers.IEvaluator;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.QuestionsService
{
    public class QuestionsService : IQuestionsService
    {
        private readonly SiteContext _context;

        public QuestionsService(SiteContext context)
        {
            _context = context;
        }

        public Question FindQuestion(int questionId)
        {
            return _context.Questions.Include("Variables").Single(q => q.Id == questionId);
        }

        public ICollection<Question> GetCombinations(Question question)
        {
            return SpectrumEvaluator.Evaluate(question, question.Variables.ToList());
        }

        public Question EvaluateNotationless(Question question)
        {
            return new NotationlessEvaluator().Evaluate(question);
        }

        public void DisposeDb()
        {
            _context.Dispose();
        }
    }
}