namespace BLOG_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutArt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ARTICLE", "Auteur_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ARTICLE", "Auteur_ID", c => c.Int(nullable: false));
        }
    }
}
