namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiopersonal : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.HistorialClinicoes", new[] { "clientes_Id" });
            DropIndex("dbo.Historials", new[] { "clientes_Id" });
            DropColumn("dbo.HistorialClinicoes", "clienteID");
            DropColumn("dbo.Historials", "clienteID");
            RenameColumn(table: "dbo.HistorialClinicoes", name: "clientes_Id", newName: "clienteID");
            RenameColumn(table: "dbo.Historials", name: "clientes_Id", newName: "clienteID");
            AddColumn("dbo.AspNetUsers", "apellidoM", c => c.String());
            AddColumn("dbo.AspNetUsers", "fechaNac", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ciudad", c => c.String());
            AddColumn("dbo.AspNetUsers", "MyProperty", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.HistorialClinicoes", "clienteID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Historials", "clienteID", c => c.String(maxLength: 128));
            CreateIndex("dbo.HistorialClinicoes", "clienteID");
            CreateIndex("dbo.Historials", "clienteID");
            AddForeignKey("dbo.Citas", "clienteID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "clienteID", "dbo.AspNetUsers");
            DropIndex("dbo.Historials", new[] { "clienteID" });
            DropIndex("dbo.HistorialClinicoes", new[] { "clienteID" });
            AlterColumn("dbo.Historials", "clienteID", c => c.String());
            AlterColumn("dbo.HistorialClinicoes", "clienteID", c => c.String());
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "MyProperty");
            DropColumn("dbo.AspNetUsers", "ciudad");
            DropColumn("dbo.AspNetUsers", "fechaNac");
            DropColumn("dbo.AspNetUsers", "apellidoM");
            RenameColumn(table: "dbo.Historials", name: "clienteID", newName: "clientes_Id");
            RenameColumn(table: "dbo.HistorialClinicoes", name: "clienteID", newName: "clientes_Id");
            AddColumn("dbo.Historials", "clienteID", c => c.String());
            AddColumn("dbo.HistorialClinicoes", "clienteID", c => c.String());
            CreateIndex("dbo.Historials", "clientes_Id");
            CreateIndex("dbo.HistorialClinicoes", "clientes_Id");
        }
    }
}
