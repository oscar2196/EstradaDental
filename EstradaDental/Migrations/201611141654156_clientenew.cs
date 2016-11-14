namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientenew : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "clienteID", "dbo.Clientes");
            DropForeignKey("dbo.Historials", "clienteID", "dbo.Clientes");
            DropIndex("dbo.Citas", new[] { "clienteID" });
            DropIndex("dbo.Historials", new[] { "clienteID" });
            DropTable("dbo.Clientes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        clienteID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        apellidoP = c.String(),
                        apellidoM = c.String(),
                        direccion = c.String(),
                        telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.clienteID);
            
            CreateIndex("dbo.Historials", "clienteID");
            CreateIndex("dbo.Citas", "clienteID");
            AddForeignKey("dbo.Historials", "clienteID", "dbo.Clientes", "clienteID", cascadeDelete: true);
            AddForeignKey("dbo.Citas", "clienteID", "dbo.Clientes", "clienteID", cascadeDelete: true);
        }
    }
}
