using System.Collections.Generic;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.Services.HomeService
{
    public interface IHomeService
    {
        List<string> Evaluations();
        void ChangeEvaluation(int evaluation, int examId);
        List<List<User>> ApprovedEvaluations();
        void LoginUser(User user);
        User GetUser(string userName, string password);
        void SignOut();
        ICollection<Exam> GetExams();
        ICollection<Exam> GetActiveExams();
    }
}
