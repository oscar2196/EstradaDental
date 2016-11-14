namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migradonaltrump : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Citas", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Historials", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "clienteID", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "apellidoP", c => c.String());
            AddColumn("dbo.AspNetUsers", "direccion", c => c.String());
            AddColumn("dbo.AspNetUsers", "telefono", c => c.Int(nullable: false));
            CreateIndex("dbo.Citas", "ApplicationUser_Id");
            CreateIndex("dbo.Historials", "ApplicationUser_Id");
            AddForeignKey("dbo.Citas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Historials", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historials", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Historials", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Citas", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "telefono");
            DropColumn("dbo.AspNetUsers", "direccion");
            DropColumn("dbo.AspNetUsers", "apellidoP");
            DropColumn("dbo.AspNetUsers", "nombre");
            DropColumn("dbo.AspNetUsers", "clienteID");
            DropColumn("dbo.Historials", "ApplicationUser_Id");
            DropColumn("dbo.Citas", "ApplicationUser_Id");
        }
    }
}
