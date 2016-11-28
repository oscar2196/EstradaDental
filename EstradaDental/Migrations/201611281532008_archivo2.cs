namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class archivo2 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Archivoes", "id_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Archivoes", new[] { "id_Id" });
            DropTable("dbo.Archivoes");
        }
    }
}
