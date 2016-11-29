namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class archivo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "clienteID", "dbo.AspNetUsers");
            //DropIndex("dbo.Citas", new[] { "clienteID" });
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        archivoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        tipo = c.String(),
                        formatoContenido = c.String(),
                        contenido = c.Binary(),
                        cliente = c.Int(nullable: false),
                        id_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.archivoID)
                .ForeignKey("dbo.AspNetUsers", t => t.id_Id)
                .Index(t => t.id_Id);
            
            //AddColumn("dbo.Citas", "id_Id", c => c.String(maxLength: 128));
            ////AlterColumn("dbo.Citas", "clienteID", c => c.String());
            //CreateIndex("dbo.Citas", "id_Id");
            //AddForeignKey("dbo.Citas", "id_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Citas", "id_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Archivoes", "id_Id", "dbo.AspNetUsers");
            //DropIndex("dbo.Citas", new[] { "id_Id" });
            DropIndex("dbo.Archivoes", new[] { "id_Id" });
            //AlterColumn("dbo.Citas", "clienteID", c => c.String(maxLength: 128));
            //DropColumn("dbo.Citas", "id_Id");
            DropTable("dbo.Archivoes");
            //CreateIndex("dbo.Citas", "clienteID");
            //AddForeignKey("dbo.Citas", "clienteID", "dbo.AspNetUsers", "Id");
        }
    }
}
