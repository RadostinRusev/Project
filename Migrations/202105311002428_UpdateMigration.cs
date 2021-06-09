namespace DisturbedAppsProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Genre = c.String(maxLength: 20),
                        Quantity = c.Int(nullable: false),
                        DOC = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        DOC = c.DateTime(),
                        Author = c.String(nullable: false),
                        Duration = c.Single(nullable: false),
                        Genre = c.String(maxLength: 20),
                        PlayListId = c.Int(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlayLists", t => t.PlayListId, cascadeDelete: true)
                .Index(t => t.PlayListId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        Password = c.String(nullable: false, maxLength: 60),
                        age = c.Int(nullable: false),
                        gender = c.String(maxLength: 7),
                        DOB = c.DateTime(),
                        Online = c.Boolean(nullable: false),
                        City = c.String(maxLength: 40),
                        CreatedBy = c.Int(nullable: false),
                        CreatedOn = c.DateTime(),
                        UpdatedBy = c.Int(nullable: false),
                        UpdatedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.Songs", "PlayListId", "dbo.PlayLists");
            DropIndex("dbo.Songs", new[] { "PlayListId" });
            DropIndex("dbo.PlayLists", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Songs");
            DropTable("dbo.PlayLists");
        }
    }
}
