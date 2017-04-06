using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DiagnosticoDeMatematicas.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DiagnosticoDeMatematicas.DAL
{
    /// <summary>
    /// Class with access to the site database.
    /// </summary>
    public class SiteContext : IdentityDbContext<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteContext"/> class.
        /// </summary>
        public SiteContext() : base("SiteContext")
        {
        }

        /// <summary>
        /// Gets or sets all the responses in the database.
        /// </summary>
        public DbSet<Response> Responses { get; set; }

        /// <summary>
        /// Gets or sets all the answers in the database.
        /// </summary>
        public DbSet<SingleSelectionAnswer> SingleSelectionAnswers { get; set; }
        
        /// <summary>
        /// Gets or sets all the exams in the database.
        /// </summary>
        public DbSet<Exam> Exams { get; set; }

        /// <summary>
        /// Gets or sets all the questions in the database.
        /// </summary>
        public DbSet<SingleSelectionQuestion> SingleSelectionQuestions { get; set; }

        /// <summary>
        /// Gets or sets all the variables in the database.
        /// </summary>
        public DbSet<Variable> Variables { get; set; }

        /// <summary>
        /// Gets or sets all the ranges in the database.
        /// </summary>
        public DbSet<Range> Ranges { get; set; }

        public DbSet<MultipleSelectionQuestion> MultipleSelectionQuestions { get; set; }

        public DbSet<QuestionOption> QuestionOptions { get; set; }

        public DbSet<MultipleSelectionAnswer> MultipleSelectionAnswers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SelectionQuestion> SelectionQuestions { get; set; }

        public DbSet<BinaryOptionSelection> BinaryOptionSelections { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Answer>()
                .HasRequired(f => f.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .WillCascadeOnDelete(false);
            
            modelBuilder.Entity<BinaryOptionSelection>()
                .HasRequired(o => o.QuestionOption)
                .WithMany(o => o.BinaryOptionSelections)
                .HasForeignKey(s => s.QuestionOptionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SingleSelectionAnswer>()
                .HasRequired(a => a.Selection)
                .WithMany(s => s.SingleSelectionAnswers)
                .HasForeignKey(a => a.SelectionId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}