namespace BLOG_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RAN : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ARTICLES", newName: "ARTICLE");
            DropForeignKey("dbo.ARTICLES", "Auteur_ID", "dbo.USERS");
            DropIndex("dbo.ARTICLE", new[] { "Auteur_ID" });
            AddColumn("dbo.ARTICLE", "Writer_Id", c => c.Int());
            CreateIndex("dbo.ARTICLE", "Writer_Id");
            AddForeignKey("dbo.ARTICLE", "Writer_Id", "dbo.USERS", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ARTICLE", "Writer_Id", "dbo.USERS");
            DropIndex("dbo.ARTICLE", new[] { "Writer_Id" });
            DropColumn("dbo.ARTICLE", "Writer_Id");
            CreateIndex("dbo.ARTICLE", "Auteur_ID");
            AddForeignKey("dbo.ARTICLES", "Auteur_ID", "dbo.USERS", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.ARTICLE", newName: "ARTICLES");
        }
    }
}
