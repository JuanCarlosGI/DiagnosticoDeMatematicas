using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.DAL;
using DiagnosticoDeMatematicas.Models;
using DiagnosticoDeMatematicas.Services.ExamsService;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;

namespace DiagnosticoDeMatematicas.Services.HomeService
{
    public class HomeService : IHomeService
    {
        private readonly SiteContext _context;
        private readonly Settings _settings;
        private IExamsService _examService;

        public HomeService(SiteContext context)
        {
            _context = context;
            _settings = new Settings(_context);
        }

        public List<string> Evaluations()
        {
            var evaluationsString = _settings["Evaluations"] ?? (_settings["Evaluations"] = "-1");

            var evaluations = evaluationsString.Split(',').ToList();

            for (var e = 0; e < evaluations.Count; e++)
            {
                if (_context.Exams.Find(int.Parse(evaluations[e])) == null)
                {
                    evaluations[e] = "";
                }
            }

            while (evaluations.Count < 20)
            {
                evaluations.Add(""); 
            }

            return evaluations;
        }

        public void ChangeEvaluation(int evaluation, int examId)
        {
            var evaluationsString = _settings["Evaluations"];
            var evaluations = evaluationsString.Split(',').ToList();

            if (evaluation >= 20 || evaluation < 0) return;
            
            while (evaluations.Count < evaluation + 1)
                evaluations.Add("");

            evaluations[evaluation] = examId.ToString();

            _settings["Evaluations"] = string.Join(",", evaluations);
        }

        public List<List<User>> ApprovedEvaluations()
        {
            var approvedModules = new List<List<User>>
            {
                new List<User>(), new List<User>(),
                new List<User>(), new List<User>()
            };

            foreach (var user in _context.Users)
            {
                var grades = ExamGrades(user.Email);

                for (int module = 0; module < 4; module++)
                    if (grades.GetRange(module*5, 5).Count(g => g >= 2) >= 4)
                        approvedModules[module].Add(user);
            }

            return approvedModules;
        }

        private List<int> ExamGrades(string email)
        {
            var examGrades = new List<int>();

            var evaluations = _settings["Evaluations"].Split(',');

            foreach (var evaluation in evaluations)
            {
                var responses = _context.Responses.Where(e => e.ExamId.ToString() == evaluation && e.UserId == email && e.Date.Year == DateTime.Today.Year);
                if (!responses.Any())
                {
                    examGrades.Add(-1);
                }
                else
                {
                    var max = 0.0;
                    foreach (var response in responses)
                    {
                        if (response.Grade > max)
                            max = response.Grade;
                    }
                    examGrades.Add((int)(Math.Ceiling(max) / 100 * 3));
                }
            }

            while (examGrades.Count < 20)
                examGrades.Add(-1);

            return examGrades;
        }

        public void LoginUser(User user)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            var authManager = HttpContext.Current.GetOwinContext().Authentication;
            var ident = userManager.CreateIdentity(user,
                DefaultAuthenticationTypes.ApplicationCookie);
            authManager.SignIn(
                new AuthenticationProperties { IsPersistent = false }, ident);
        }

        public User GetUser(string userName, string password)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            return userManager.Find(userName, password);
        }

        public void SignOut()
        {
            var authManager = HttpContext.Current.GetOwinContext().Authentication;
            authManager.SignOut();
        }

        public ICollection<Exam> GetExams()
        {
            _examService = _examService ?? new ExamsService.ExamsService(_context);
            return _examService.GetExamList();
        }

        public ICollection<Exam> GetActiveExams()
        {
            _examService = _examService ?? new ExamsService.ExamsService(_context);
            return _examService.GetExamList().Where(e => e.Active).ToList();
        }
    }
}