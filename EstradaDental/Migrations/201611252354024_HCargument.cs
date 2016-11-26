namespace EstradaDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HCargument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistorialClinicoes", "observaciones", c => c.String());
            AddColumn("dbo.HistorialClinicoes", "antecedenteClinico", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HistorialClinicoes", "antecedenteClinico");
            DropColumn("dbo.HistorialClinicoes", "observaciones");
        }
    }
}
