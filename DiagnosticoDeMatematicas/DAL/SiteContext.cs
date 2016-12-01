﻿namespace DiagnosticoDeMatematicas.DAL
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Models;

    /// <summary>
    /// Class with access to the site database.
    /// </summary>
    public class SiteContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteContext"/> class.
        /// </summary>
        public SiteContext() : base("SiteContext")
        {
        }
        
        /// <summary>
        /// Gets or sets all the users in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<AnswerAbstract>()
                .HasRequired(f => f.Question)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

        public DbSet<MultipleSelectionQuestion> MultipleSelectionQuestions { get; set; }

        public DbSet<QuestionOption> QuestionOptions { get; set; }

        public DbSet<MultipleSelectionAnswer> MultipleSelectionAnswers { get; set; }

        public DbSet<SelectionQuestion> QuestionAbstracts { get; set; }
    }
}