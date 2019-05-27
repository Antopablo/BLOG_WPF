using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_WPF
{
    [Table("ARTICLE")]
    public class Article : INotifyPropertyChanged
    {
        public Article(string titre, string contenu, User writer)
        {
            Titre = titre;
            Contenu = contenu;
            Writer = writer;
        }

        [Key]
        public int Id { get; set; }

        
        private string _Titre;

        [Column("Titre")]
        public string Titre
        {
            get { return _Titre; }
            set {
                if (this._Titre != value)
                {
                    this._Titre = value;
                    this.NotifyPropertyChanged("Titre");
                }
            }
        }


        
        private string _Contenu;
        [Column("Contenu")]
        public string Contenu
        {
            get { return _Contenu; }
            set {
                if (this._Contenu != value)
                {
                    this._Contenu = value;
                    this.NotifyPropertyChanged("Contenu");
                }
            }
        }


        public User Writer { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public override string ToString()
        {
            return Titre + " par " + Writer.Pseudo;
        }
    }
}
