namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Error : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.VMUserRoleNames");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VMUserRoleNames",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nombreCompleto = c.String(),
                        email = c.String(),
                        rolID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
