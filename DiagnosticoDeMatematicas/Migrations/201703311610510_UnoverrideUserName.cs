namespace DiagnosticoDeMatematicas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnoverrideUserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserName");
        }
    }
}
