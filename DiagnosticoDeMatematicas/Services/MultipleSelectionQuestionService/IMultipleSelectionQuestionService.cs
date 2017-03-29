using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.MultipleSelectionQuestionService
{
    public interface IMultipleSelectionQuestionService
    {
        MultipleSelectionQuestion CreateQuestion(int examId);
        MultipleSelectionQuestion EvaluateNotationless(MultipleSelectionQuestion question);
        MultipleSelectionQuestion FindQuestion(int questionId);
    }
}
