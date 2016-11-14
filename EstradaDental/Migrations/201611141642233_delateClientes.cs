namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delateClientes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Citas", "clienteID", "dbo.Clientes");
            DropForeignKey("dbo.Historials", "clienteID", "dbo.Clientes");
            RenameColumn(table: "dbo.Citas", name: "ApplicationUser_Id", newName: "cliente_Id");
            RenameColumn(table: "dbo.Historials", name: "ApplicationUser_Id", newName: "cliente_Id");
            RenameIndex(table: "dbo.Citas", name: "IX_ApplicationUser_Id", newName: "IX_cliente_Id");
            RenameIndex(table: "dbo.Historials", name: "IX_ApplicationUser_Id", newName: "IX_cliente_Id");
            AddForeignKey("dbo.Citas", "cliente_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Historials", "cliente_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Historials", "cliente_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Citas", "cliente_Id", "dbo.AspNetUsers");
            RenameIndex(table: "dbo.Historials", name: "IX_cliente_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Citas", name: "IX_cliente_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Historials", name: "cliente_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Citas", name: "cliente_Id", newName: "ApplicationUser_Id");
            AddForeignKey("dbo.Historials", "clienteID", "dbo.Clientes", "clienteID", cascadeDelete: true);
            AddForeignKey("dbo.Citas", "clienteID", "dbo.Clientes", "clienteID", cascadeDelete: true);
        }
    }
}
