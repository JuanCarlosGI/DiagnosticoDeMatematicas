using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.ExamsService
{
    public interface IExamsService
    {
        List<Exam> GetExamList();
        Exam FindExam(int id);
        void SaveExam(Exam exam);
        void AddExam(Exam exam);
        void DeleteExam(int id);
        void DisposeDb();
    }
}
