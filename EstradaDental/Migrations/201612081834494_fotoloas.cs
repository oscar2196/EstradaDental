namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fotoloas : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Archivoes", new[] { "admxx_Id" });
            CreateIndex("dbo.Archivoes", "Admxx_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Archivoes", new[] { "Admxx_Id" });
            CreateIndex("dbo.Archivoes", "admxx_Id");
        }
    }
}
