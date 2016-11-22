namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiouser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Citas", new[] { "cliente_Id" });
            DropColumn("dbo.Citas", "clienteID");
            RenameColumn(table: "dbo.Citas", name: "cliente_Id", newName: "clienteID");
            RenameColumn(table: "dbo.Historials", name: "cliente_Id", newName: "clientes_Id");
            RenameIndex(table: "dbo.Historials", name: "IX_cliente_Id", newName: "IX_clientes_Id");
            AlterColumn("dbo.Citas", "clienteID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Historials", "clienteID", c => c.String());
            CreateIndex("dbo.Citas", "clienteID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Citas", new[] { "clienteID" });
            AlterColumn("dbo.Historials", "clienteID", c => c.Int(nullable: false));
            AlterColumn("dbo.Citas", "clienteID", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Historials", name: "IX_clientes_Id", newName: "IX_cliente_Id");
            RenameColumn(table: "dbo.Historials", name: "clientes_Id", newName: "cliente_Id");
            RenameColumn(table: "dbo.Citas", name: "clienteID", newName: "cliente_Id");
            AddColumn("dbo.Citas", "clienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Citas", "cliente_Id");
        }
    }
}
