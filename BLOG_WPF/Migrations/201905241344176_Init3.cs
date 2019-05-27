namespace BLOG_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ARTICLES", name: "Title", newName: "Titre");
            RenameColumn(table: "dbo.ARTICLES", name: "Content", newName: "Contenu");
            RenameColumn(table: "dbo.ARTICLES", name: "AuteurID", newName: "Auteur_ID");
            RenameIndex(table: "dbo.ARTICLES", name: "IX_AuteurID", newName: "IX_Auteur_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ARTICLES", name: "IX_Auteur_ID", newName: "IX_AuteurID");
            RenameColumn(table: "dbo.ARTICLES", name: "Auteur_ID", newName: "AuteurID");
            RenameColumn(table: "dbo.ARTICLES", name: "Contenu", newName: "Content");
            RenameColumn(table: "dbo.ARTICLES", name: "Titre", newName: "Title");
        }
    }
}
