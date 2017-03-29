namespace DiagnosticoDeMatematicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Setting");
        }
    }
}
