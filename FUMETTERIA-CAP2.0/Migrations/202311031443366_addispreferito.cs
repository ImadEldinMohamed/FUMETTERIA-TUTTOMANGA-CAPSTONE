namespace FUMETTERIA_CAP2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addispreferito : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.preferito", "isPreferito", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.preferito", "isPreferito");
        }
    }
}
