using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using DiagnosticoDeMatematicas.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

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
                FirstName = "Juan Carlos",
                LastName = "Guzman",
                DateOfBirth = DateTime.Now,
                Email = "jcgi@admin.com",
                Gender = Gender.Masculino,
                Interest = Scale.Extremadamente,
                Facility = Scale.Extremadamente,
                Liking = Scale.Extremadamente,
                UserName = "JuanCarlosGI"
            }; 

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("Administrator"));
            roleManager.Create(new IdentityRole("User"));

            var userManager = new AppUserManager(new UserStore<User>(context));
            userManager.Create(admin, "@Admin1234");

            userManager.AddToRole(admin.Id, "Administrator");

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