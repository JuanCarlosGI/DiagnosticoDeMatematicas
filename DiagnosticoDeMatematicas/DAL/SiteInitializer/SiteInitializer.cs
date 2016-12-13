using System;
using System.Collections.Generic;
using System.Data.Entity;
using DiagnosticoDeMatematicas.Models;

namespace DiagnosticoDeMatematicas.DAL
{
    public partial class SiteInitializer : DropCreateDatabaseIfModelChanges<SiteContext>
    {
        int _examCounter;
        int _questionCounter;
        int _rangeCounter;
        int _optionCounter;

        readonly List<Exam> _exams = new List<Exam>();
        readonly List<SingleSelectionQuestion> _questions = new List<SingleSelectionQuestion>();
        readonly List<QuestionOption> _options = new List<QuestionOption>();
        readonly List<Variable> _variables = new List<Variable>();
        readonly List<Range> _ranges = new List<Range>();

        protected override void Seed(SiteContext context)
        {
            var admin = new User
            {
                Role = Role.Administrador,
                FirstName = "Juan Carlos",
                LastName = "Guzman",
                Password = "⍵⫆랽豢鵚辭�엘䃀㕥㇥ꎨ譴깬~",
                DateOfBirth = DateTime.Now,
                Email = "jcgi@admin.com",
                Gender = Gender.Masculino,
                Interest = Scale.Extremadamente,
                Facility = Scale.Extremadamente,
                Liking = Scale.Extremadamente
            };

            context.Users.Add(admin);
            context.SaveChanges();

            NumbersExam();
            FormulasExam();
            GraphsExams();
            
            using (var transaction = context.Database.BeginTransaction())
            {
                foreach (var exam in _exams)
                {
                    context.Exams.Add(exam);
                }
                context.SaveChanges();
                
                foreach (var question in _questions)
                {
                    context.Questions.Add(question);
                }
                context.SaveChanges();
                
                foreach (var option in _options)
                {
                    context.QuestionOptions.Add(option);
                }
                context.SaveChanges();
                
                foreach (var variable in _variables)
                {
                    context.Variables.Add(variable);
                }
                context.SaveChanges();
                
                foreach (var range in _ranges)
                {
                    context.Ranges.Add(range);
                }
                context.SaveChanges();

                transaction.Commit();
            }
            
        }
    }
}