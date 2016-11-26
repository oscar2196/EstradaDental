namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class histclinico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistorialClinicoes",
                c => new
                    {
                        historialClinicoID = c.Int(nullable: false, identity: true),
                        clienteID = c.String(),
                        pregunta1 = c.Boolean(nullable: false),
                        pregunta2 = c.Boolean(nullable: false),
                        pregunta3 = c.Boolean(nullable: false),
                        pregunta4 = c.Boolean(nullable: false),
                        pregunta5 = c.Boolean(nullable: false),
                        pregunta6 = c.Boolean(nullable: false),
                        pregunta7 = c.Boolean(nullable: false),
                        pregunta8 = c.Boolean(nullable: false),
                        pregunta9 = c.Boolean(nullable: false),
                        pregunta10 = c.Boolean(nullable: false),
                        pregunta11 = c.Boolean(nullable: false),
                        pregunta12 = c.Boolean(nullable: false),
                        pregunta13 = c.Boolean(nullable: false),
                        pregunta14 = c.Boolean(nullable: false),
                        pregunta15 = c.Boolean(nullable: false),
                        pregunta16 = c.Boolean(nullable: false),
                        pregunta17 = c.Boolean(nullable: false),
                        pregunta18 = c.Boolean(nullable: false),
                        pregunta19 = c.Boolean(nullable: false),
                        pregunta20 = c.Boolean(nullable: false),
                        pregunta21 = c.Boolean(nullable: false),
                        pregunta22 = c.Boolean(nullable: false),
                        pregunta23 = c.Boolean(nullable: false),
                        pregunta24 = c.Boolean(nullable: false),
                        pregunta25 = c.Boolean(nullable: false),
                        pregunta26 = c.Boolean(nullable: false),
                        pregunta27 = c.Boolean(nullable: false),
                        pregunta28 = c.Boolean(nullable: false),
                        pregunta29 = c.Boolean(nullable: false),
                        clientes_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.historialClinicoID)
                .ForeignKey("dbo.AspNetUsers", t => t.clientes_Id)
                .Index(t => t.clientes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistorialClinicoes", "clientes_Id", "dbo.AspNetUsers");
            DropIndex("dbo.HistorialClinicoes", new[] { "clientes_Id" });
            DropTable("dbo.HistorialClinicoes");
        }
    }
}
