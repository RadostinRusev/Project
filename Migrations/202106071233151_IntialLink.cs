namespace DisturbedAppsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Songs", "Link", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Songs", "Link");
        }
    }
}
