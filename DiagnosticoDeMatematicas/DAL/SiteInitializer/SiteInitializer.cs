namespace DiagnosticoDeMatematicas.DAL
{
    using System;
    using System.Collections.Generic;
    using Models;

    public partial class SiteInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SiteContext>
    {
        int ExamCounter = 0;
        int QuestionCounter = 0;
        int RangeCounter = 0;
        int OptionCounter = 0;

        List<Exam> Exams = new List<Exam>();
        List<SingleSelectionQuestion> Questions = new List<SingleSelectionQuestion>();
        List<QuestionOption> Options = new List<QuestionOption>();
        List<Variable> Variables = new List<Variable>();
        List<Range> Ranges = new List<Range>();

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
                foreach (var exam in Exams)
                {
                    context.Exams.Add(exam);
                }
                context.SaveChanges();
                
                foreach (var question in Questions)
                {
                    context.QuestionAbstracts.Add(question);
                }
                context.SaveChanges();
                
                foreach (var option in Options)
                {
                    context.QuestionOptions.Add(option);
                }
                context.SaveChanges();
                
                foreach (var variable in Variables)
                {
                    context.Variables.Add(variable);
                }
                context.SaveChanges();
                
                foreach (var range in Ranges)
                {
                    context.Ranges.Add(range);
                }
                context.SaveChanges();

                transaction.Commit();
            }
            
        }
    }
}