namespace DiagnosticoDeMatematicas.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        ResponseID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        Choice = c.Int(nullable: false),
                        Question_ID = c.Int(),
                    })
                .PrimaryKey(t => new { t.ResponseID, t.QuestionID })
                .ForeignKey("dbo.Question", t => t.Question_ID)
                .ForeignKey("dbo.Question", t => t.QuestionID)
                .ForeignKey("dbo.Response", t => t.ResponseID, cascadeDelete: true)
                .Index(t => t.ResponseID)
                .Index(t => t.QuestionID)
                .Index(t => t.Question_ID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ExamID = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        OptionA = c.String(nullable: false),
                        OptionACorrect = c.Boolean(nullable: false),
                        OptionAFeedback = c.String(nullable: false),
                        OptionB = c.String(nullable: false),
                        OptionBCorrect = c.Boolean(nullable: false),
                        OptionBFeedback = c.String(nullable: false),
                        OptionC = c.String(nullable: false),
                        OptionCCorrect = c.Boolean(nullable: false),
                        OptionCFeedback = c.String(nullable: false),
                        OptionD = c.String(nullable: false),
                        OptionDCorrect = c.Boolean(nullable: false),
                        OptionDFeedback = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exam", t => t.ExamID, cascadeDelete: true)
                .Index(t => t.ExamID);
            
            CreateTable(
                "dbo.Exam",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Response",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        ExamID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Exam", t => t.ExamID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ExamID);
            
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
                "dbo.Variable",
                c => new
                    {
                        Symbol = c.String(nullable: false, maxLength: 1),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Symbol, t.QuestionID })
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Range",
                c => new
                    {
                        Symbol = c.String(nullable: false, maxLength: 1),
                        QuestionId = c.Int(nullable: false),
                        ID = c.Int(nullable: false, identity: true),
                        Minimum = c.Int(nullable: false),
                        Maximum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Variable", t => new { t.Symbol, t.QuestionId }, cascadeDelete: true)
                .Index(t => new { t.Symbol, t.QuestionId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answer", "ResponseID", "dbo.Response");
            DropForeignKey("dbo.Answer", "QuestionID", "dbo.Question");
            DropForeignKey("dbo.Range", new[] { "Symbol", "QuestionId" }, "dbo.Variable");
            DropForeignKey("dbo.Variable", "QuestionID", "dbo.Question");
            DropForeignKey("dbo.Response", "UserID", "dbo.User");
            DropForeignKey("dbo.Response", "ExamID", "dbo.Exam");
            DropForeignKey("dbo.Question", "ExamID", "dbo.Exam");
            DropForeignKey("dbo.Answer", "Question_ID", "dbo.Question");
            DropIndex("dbo.Range", new[] { "Symbol", "QuestionId" });
            DropIndex("dbo.Variable", new[] { "QuestionID" });
            DropIndex("dbo.Response", new[] { "ExamID" });
            DropIndex("dbo.Response", new[] { "UserID" });
            DropIndex("dbo.Question", new[] { "ExamID" });
            DropIndex("dbo.Answer", new[] { "Question_ID" });
            DropIndex("dbo.Answer", new[] { "QuestionID" });
            DropIndex("dbo.Answer", new[] { "ResponseID" });
            DropTable("dbo.Range");
            DropTable("dbo.Variable");
            DropTable("dbo.User");
            DropTable("dbo.Response");
            DropTable("dbo.Exam");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
