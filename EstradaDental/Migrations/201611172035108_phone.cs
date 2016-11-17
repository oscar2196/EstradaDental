namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phone : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "telefono");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "telefono", c => c.Int(nullable: false));
        }
    }
}
