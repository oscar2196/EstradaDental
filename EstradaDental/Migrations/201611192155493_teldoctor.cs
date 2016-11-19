namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teldoctor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctors", "telefono", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Doctors", "telefono", c => c.Int(nullable: false));
        }
    }
}
