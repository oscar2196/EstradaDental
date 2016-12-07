namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Archivoes", "cliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Archivoes", "cliente", c => c.Int(nullable: false));
        }
    }
}
