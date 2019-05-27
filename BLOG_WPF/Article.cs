using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_WPF
{
    [Table("ARTICLE")]
    public class Article
    {
        public Article(string titre, string contenu, User writer)
        {
            Titre = titre;
            Contenu = contenu;
            Writer = writer;
        }

        [Key]
        public int Id { get; set; }

        [Column("Titre")]
        public string Titre { get; set; }

        [Column("Contenu")]
        public string Contenu { get; set; }

        public User Writer { get; set; }

        public override string ToString()
        {
            return Titre + " par " + Writer.Pseudo;
        }
    }
}
