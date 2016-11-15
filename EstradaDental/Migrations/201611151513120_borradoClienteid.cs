namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borradoClienteid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "clienteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "clienteID", c => c.Int(nullable: false));
        }
    }
}
