using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticoDeMatematicas.DAL;

namespace DiagnosticoDeMatematicas.Services
{
    public class UsersService
    {
        private readonly SiteContext _context;
        private readonly Settings _settings;

        public UsersService(SiteContext context)
        {
            _context = context;
            _settings = new Settings(_context);
        }

        public List<int> ExamGrades(string email)
        {
            var examGrades = new List<int>();

            var evaluations = _settings["Evaluations"].Split(',');

            foreach (var evaluation in evaluations)
            {
                var responses = _context.Responses.Where(e => e.ExamId.ToString() == evaluation && e.UserId == email);
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

            while(examGrades.Count < 20)
                examGrades.Add(-1);

            return examGrades;
        }
    }
}