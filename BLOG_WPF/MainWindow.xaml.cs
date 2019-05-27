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
    }
}
