using DiagnosticoDeMatematicas.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DiagnosticoDeMatematicas.DAL
{
    public class SiteContext : DbContext
    {
        public SiteContext(): base("SiteContext")
        {

        }
        
        public DbSet<User> Users  { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Answer> Answers  { get; set; }
        public DbSet<Exam> Exams  { get; set; }
        public DbSet<Question> Questions  { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Range> Ranges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Answer>()
                .HasRequired(f => f.Question)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}