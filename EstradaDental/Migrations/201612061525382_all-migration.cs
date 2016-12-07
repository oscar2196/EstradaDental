namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(),
                        apellidoP = c.String(),
                        apellidoM = c.String(),
                        direccion = c.String(),
                        fechaNac = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        ciudad = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Archivoes",
                c => new
                    {
                        archivoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        tipo = c.String(),
                        formatoContenido = c.String(),
                        contenido = c.Binary(),
                        admxx_Id = c.String(maxLength: 128),
                        cliente_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.archivoID)
                .ForeignKey("dbo.AspNetUsers", t => t.admxx_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.cliente_Id)
                .Index(t => t.admxx_Id)
                .Index(t => t.cliente_Id);
            
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        citaID = c.Int(nullable: false, identity: true),
                        confirmacion = c.Boolean(nullable: false),
                        fechaIn = c.DateTime(nullable: false),
                        fechaOut = c.DateTime(nullable: false),
                        doctorID = c.Int(nullable: false),
                        clienteID = c.String(maxLength: 128),
                        comentario = c.String(),
                        admxx_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.citaID)
                .ForeignKey("dbo.AspNetUsers", t => t.admxx_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.clienteID)
                .ForeignKey("dbo.Doctors", t => t.doctorID, cascadeDelete: true)
                .Index(t => t.doctorID)
                .Index(t => t.clienteID)
                .Index(t => t.admxx_Id);
            
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
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.HistorialClinicoes",
                c => new
                    {
                        historialClinicoID = c.Int(nullable: false, identity: true),
                        clienteID = c.String(maxLength: 128),
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
                        observaciones = c.String(),
                        antecedenteClinico = c.String(),
                    })
                .PrimaryKey(t => t.historialClinicoID)
                .ForeignKey("dbo.AspNetUsers", t => t.clienteID)
                .Index(t => t.clienteID);
            
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        historialID = c.Int(nullable: false, identity: true),
                        comentario = c.String(),
                        fecha = c.DateTime(nullable: false),
                        clienteID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.historialID)
                .ForeignKey("dbo.AspNetUsers", t => t.clienteID)
                .Index(t => t.clienteID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Historials", "clienteID", "dbo.AspNetUsers");
            DropForeignKey("dbo.HistorialClinicoes", "clienteID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Archivoes", "cliente_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citas", "doctorID", "dbo.Doctors");
            DropForeignKey("dbo.Citas", "clienteID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citas", "admxx_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Archivoes", "admxx_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Historials", new[] { "clienteID" });
            DropIndex("dbo.HistorialClinicoes", new[] { "clienteID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Citas", new[] { "admxx_Id" });
            DropIndex("dbo.Citas", new[] { "clienteID" });
            DropIndex("dbo.Citas", new[] { "doctorID" });
            DropIndex("dbo.Archivoes", new[] { "cliente_Id" });
            DropIndex("dbo.Archivoes", new[] { "admxx_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Historials");
            DropTable("dbo.HistorialClinicoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Doctors");
            DropTable("dbo.Citas");
            DropTable("dbo.Archivoes");
            DropTable("dbo.AspNetUsers");
        }
    }
}
