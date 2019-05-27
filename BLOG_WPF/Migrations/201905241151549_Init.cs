namespace BLOG_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.USERS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Pseudo = c.String(),
                        Password = c.String(),
                        Right = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        AuteurID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.USERS", t => t.AuteurID, cascadeDelete: true)
                .Index(t => t.AuteurID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "AuteurID", "dbo.USERS");
            DropIndex("dbo.Articles", new[] { "AuteurID" });
            DropTable("dbo.Articles");
            DropTable("dbo.USERS");
        }
    }
}
