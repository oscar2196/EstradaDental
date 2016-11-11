namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        citaID = c.Int(nullable: false, identity: true),
                        confirmacion = c.Boolean(nullable: false),
                        fechaIn = c.DateTime(nullable: false),
                        fechaOut = c.DateTime(nullable: false),
                        doctorID = c.Int(nullable: false),
                        clienteID = c.Int(nullable: false),
                        comentario = c.String(),
                    })
                .PrimaryKey(t => t.citaID)
                .ForeignKey("dbo.Clientes", t => t.clienteID, cascadeDelete: true)
                .ForeignKey("dbo.Doctors", t => t.doctorID, cascadeDelete: true)
                .Index(t => t.doctorID)
                .Index(t => t.clienteID);
            
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
            
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        historialID = c.Int(nullable: false, identity: true),
                        comentario = c.String(),
                        fecha = c.DateTime(nullable: false),
                        clienteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.historialID)
                .ForeignKey("dbo.Clientes", t => t.clienteID, cascadeDelete: true)
                .Index(t => t.clienteID);
            
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
                        telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.doctorID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Citas", "doctorID", "dbo.Doctors");
            DropForeignKey("dbo.Historials", "clienteID", "dbo.Clientes");
            DropForeignKey("dbo.Citas", "clienteID", "dbo.Clientes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Historials", new[] { "clienteID" });
            DropIndex("dbo.Citas", new[] { "clienteID" });
            DropIndex("dbo.Citas", new[] { "doctorID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Doctors");
            DropTable("dbo.Historials");
            DropTable("dbo.Clientes");
            DropTable("dbo.Citas");
        }
    }
}
