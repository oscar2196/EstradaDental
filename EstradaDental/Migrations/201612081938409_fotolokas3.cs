namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fotolokas3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Archivoes", name: "cliente_Id", newName: "clienteID");
            RenameIndex(table: "dbo.Archivoes", name: "IX_cliente_Id", newName: "IX_clienteID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Archivoes", name: "IX_clienteID", newName: "IX_cliente_Id");
            RenameColumn(table: "dbo.Archivoes", name: "clienteID", newName: "cliente_Id");
        }
    }
}
