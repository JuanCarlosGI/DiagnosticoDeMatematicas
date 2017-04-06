namespace DiagnosticoDeMatematicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BinaryOptionSelection",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        MultipleSelectionQuestionId = c.Int(nullable: false),
                        QuestionOptionId = c.Int(nullable: false),
                        Selected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.MultipleSelectionQuestionId, t.QuestionOptionId })
                .ForeignKey("dbo.MultipleSelectionAnswer", t => new { t.ResponseId, t.MultipleSelectionQuestionId })
                .ForeignKey("dbo.QuestionOption", t => t.QuestionOptionId)
                .Index(t => new { t.ResponseId, t.MultipleSelectionQuestionId })
                .Index(t => t.QuestionOptionId);
            
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.QuestionId })
                .ForeignKey("dbo.Question", t => t.QuestionId)
                .ForeignKey("dbo.Response", t => t.ResponseId, cascadeDelete: true)
                .Index(t => t.ResponseId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Response",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ExamId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exam", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ExamId);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Comments = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Role = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        Interest = c.Int(nullable: false),
                        Facility = c.Int(nullable: false),
                        Liking = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            CreateTable(
                "dbo.QuestionOption",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionId = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                        Feedback = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Variable",
                c => new
                    {
                        Symbol = c.String(nullable: false, maxLength: 1),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Symbol, t.QuestionId })
                .ForeignKey("dbo.Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Range",
                c => new
                    {
                        Symbol = c.String(nullable: false, maxLength: 1),
                        QuestionId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Minimum = c.Int(nullable: false),
                        Maximum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Variable", t => new { t.Symbol, t.QuestionId }, cascadeDelete: true)
                .Index(t => new { t.Symbol, t.QuestionId });
            
            CreateTable(
                "dbo.MultipleSelectionAnswer",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.QuestionId })
                .ForeignKey("dbo.Answer", t => new { t.ResponseId, t.QuestionId })
                .Index(t => new { t.ResponseId, t.QuestionId });
            
            CreateTable(
                "dbo.SingleSelectionAnswer",
                c => new
                    {
                        ResponseId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                        SelectionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ResponseId, t.QuestionId })
                .ForeignKey("dbo.Answer", t => new { t.ResponseId, t.QuestionId })
                .ForeignKey("dbo.QuestionOption", t => t.SelectionId)
                .Index(t => new { t.ResponseId, t.QuestionId })
                .Index(t => t.SelectionId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SingleSelectionAnswer", "SelectionId", "dbo.QuestionOption");
            DropForeignKey("dbo.SingleSelectionAnswer", new[] { "ResponseId", "QuestionId" }, "dbo.Answer");
            DropForeignKey("dbo.MultipleSelectionAnswer", new[] { "ResponseId", "QuestionId" }, "dbo.Answer");
            DropForeignKey("dbo.BinaryOptionSelection", "QuestionOptionId", "dbo.QuestionOption");
            DropForeignKey("dbo.BinaryOptionSelection", new[] { "ResponseId", "MultipleSelectionQuestionId" }, "dbo.MultipleSelectionAnswer");
            DropForeignKey("dbo.Range", new[] { "Symbol", "QuestionId" }, "dbo.Variable");
            DropForeignKey("dbo.Variable", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.QuestionOption", "QuestionId", "dbo.Question");
            DropForeignKey("dbo.Response", "UserId", "dbo.User");
            DropForeignKey("dbo.Response", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.Question", "ExamId", "dbo.Exam");
            DropForeignKey("dbo.Answer", "ResponseId", "dbo.Response");
            DropForeignKey("dbo.Answer", "QuestionId", "dbo.Question");
            DropIndex("dbo.SingleSelectionAnswer", new[] { "SelectionId" });
            DropIndex("dbo.SingleSelectionAnswer", new[] { "ResponseId", "QuestionId" });
            DropIndex("dbo.MultipleSelectionAnswer", new[] { "ResponseId", "QuestionId" });
            DropIndex("dbo.Range", new[] { "Symbol", "QuestionId" });
            DropIndex("dbo.Variable", new[] { "QuestionId" });
            DropIndex("dbo.QuestionOption", new[] { "QuestionId" });
            DropIndex("dbo.Response", new[] { "ExamId" });
            DropIndex("dbo.Response", new[] { "UserId" });
            DropIndex("dbo.Question", new[] { "ExamId" });
            DropIndex("dbo.Answer", new[] { "QuestionId" });
            DropIndex("dbo.Answer", new[] { "ResponseId" });
            DropIndex("dbo.BinaryOptionSelection", new[] { "QuestionOptionId" });
            DropIndex("dbo.BinaryOptionSelection", new[] { "ResponseId", "MultipleSelectionQuestionId" });
            DropTable("dbo.SingleSelectionAnswer");
            DropTable("dbo.MultipleSelectionAnswer");
            DropTable("dbo.Range");
            DropTable("dbo.Variable");
            DropTable("dbo.QuestionOption");
            DropTable("dbo.User");
            DropTable("dbo.Exam");
            DropTable("dbo.Response");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
            DropTable("dbo.BinaryOptionSelection");
        }
    }
}
