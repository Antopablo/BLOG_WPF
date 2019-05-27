using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BLOG_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationContext _db;
        public ApplicationContext DB
        {
            get { return _db; }
            set { _db = value; }
        }

        private User _Connected_user;
        public User Connected_user
        {
            get { return _Connected_user; }
            set { _Connected_user = value; }
        }

        public ObservableCollection<Article> Collection_Article = new ObservableCollection<Article>();
        public MainWindow()
        {
            InitializeComponent();
            DB = new ApplicationContext();
            ListeArticles.ItemsSource = Collection_Article;
        }

        private void Bouton_SignOn_Click(object sender, RoutedEventArgs e)
        {
            signin signIn = new signin(this);
            signIn.Show();
        }

        private void Bouton_Login_Click(object sender, RoutedEventArgs e)
        {
            Connexion Conn = new Connexion(this);
            Conn.Show();

        }

        private void Bouton_Ajouter_Click(object sender, RoutedEventArgs e)
        {
           Ajout_Article ajoutArt = new Ajout_Article(this);
           ajoutArt.Show();
        }

        private void Bouton_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            Collection_Article.Remove((Article)ListeArticles.SelectedItem);
        }

        private void Bouton_Editer_Click(object sender, RoutedEventArgs e)
        {
            Ajout_Article ajoutArt = new Ajout_Article(this);
            ajoutArt.Champ_Titre.Text = ((Article)ListeArticles.SelectedItem).Titre;
            ajoutArt.Champ_Article_Content.Text = ((Article)ListeArticles.SelectedItem).Contenu;
            Collection_Article.Remove((Article)ListeArticles.SelectedItem);
            ajoutArt.Show();
        }

        private void ListeArticles_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Result_title.Text = ((Article)ListeArticles.SelectedItem).Titre;
            Result_Content.Text = ((Article)ListeArticles.SelectedItem).Contenu;

            //var query3 = from c in DB.User
            //             where c.Id == Connected_user.Id || Connected_user.Right == Right.ADMIN
            //             select c;

            var query2 = from x in DB.Article
                         where x.Writer.Id == Connected_user.Id || Connected_user.Right == Right.ADMIN
                         select x;

            //List<int> L = new List<int>();
            //foreach (var item in query3)
            //{
            //    L.Add(item.Id);
            //}

            //if (L.Contains(Connected_user.Id))
            //{
            //    Bouton_Supprimer.IsEnabled = true;
            //    Bouton_Editer.IsEnabled = true;
            //} else
            //{
            //    Bouton_Supprimer.IsEnabled = false;
            //    Bouton_Editer.IsEnabled = false;
            //}

            List<Article> L = new List<Article>();
            foreach (var item in query2)
            {
                L.Add(item);
            }
            if (L.Count > 0)
            {
                if (Connected_user.Id == L[0].Writer.Id)
                {
                    Bouton_Supprimer.IsEnabled = true;
                    Bouton_Editer.IsEnabled = true;
                }
                
            }
            else
            {
                Bouton_Supprimer.IsEnabled = false;
                Bouton_Editer.IsEnabled = false;
            }

        }

        private void Bouton_SignOut_Click(object sender, RoutedEventArgs e)
        {
            Connected_user.Right = Right.GUEST;
            Bouton_Supprimer.IsEnabled = false;
            Bouton_Editer.IsEnabled = false;
            Bouton_Ajouter.IsEnabled = false;

            Affichage_nomUser.Text = Connected_user.Right.ToString();

        }
    }
}
