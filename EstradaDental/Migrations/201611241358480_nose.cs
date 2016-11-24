namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nose : DbMigration
    {
        public override void Up()
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
        
        public override void Down()
        {
            DropTable("dbo.VMUserRoleNames");
        }
    }
}
