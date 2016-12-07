namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Archivoes", "Admxx_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Citas", "Admxx_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.HistorialClinicoes", "Admxx_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Historials", "Admxx_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Archivoes", "Admxx_Id");
            CreateIndex("dbo.Citas", "Admxx_Id");
            CreateIndex("dbo.HistorialClinicoes", "Admxx_Id");
            CreateIndex("dbo.Historials", "Admxx_Id");
            AddForeignKey("dbo.Archivoes", "Admxx_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Citas", "Admxx_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.HistorialClinicoes", "Admxx_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Historials", "Admxx_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historials", "Admxx_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistorialClinicoes", "Admxx_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citas", "Admxx_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Archivoes", "Admxx_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Historials", new[] { "Admxx_Id" });
            DropIndex("dbo.HistorialClinicoes", new[] { "Admxx_Id" });
            DropIndex("dbo.Citas", new[] { "Admxx_Id" });
            DropIndex("dbo.Archivoes", new[] { "Admxx_Id" });
            DropColumn("dbo.Historials", "Admxx_Id");
            DropColumn("dbo.HistorialClinicoes", "Admxx_Id");
            DropColumn("dbo.Citas", "Admxx_Id");
            DropColumn("dbo.Archivoes", "Admxx_Id");
        }
    }
}
