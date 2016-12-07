namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class doctor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "doctorID", "dbo.Doctors");
            DropIndex("dbo.Citas", new[] { "doctorID" });
            DropColumn("dbo.Citas", "doctorID");
            DropTable("dbo.Doctors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        doctorID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        apellidoP = c.String(),
                        apellidoM = c.String(),
                        especialidad = c.String(),
                        direccion = c.String(),
                        telefono = c.String(),
                    })
                .PrimaryKey(t => t.doctorID);
            
            AddColumn("dbo.Citas", "doctorID", c => c.Int(nullable: false));
            CreateIndex("dbo.Citas", "doctorID");
            AddForeignKey("dbo.Citas", "doctorID", "dbo.Doctors", "doctorID", cascadeDelete: true);
        }
    }
}
