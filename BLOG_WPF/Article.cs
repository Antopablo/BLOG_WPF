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
        [Key]
        public int Id { get; set; }

        [Column("Titre")]
        public string Titre { get; set; }

        [Column("Contenu")]
        public string Contenu { get; set; }

        [Column("Auteur_ID")]
        public int AuteurID { get; set; }

        public User Writer { get; set; }

        public override string ToString()
        {
            return Id + " - " + Titre + " par " + Writer.Pseudo + " : " + Contenu;
        }
    }
}
