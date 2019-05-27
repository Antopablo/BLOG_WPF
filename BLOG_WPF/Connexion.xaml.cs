using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BLOG_WPF
{
    /// <summary>
    /// Logique d'interaction pour Connexion.xaml
    /// </summary>
    public partial class Connexion : Window
    {
        public Connexion(MainWindow w)
        {
            InitializeComponent();
            mw = w;
        }

        private MainWindow mw;

        private void Bouton_SeConnecter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var query = from u in mw.DB.User
                            where u.Pseudo == Co_pseudo.Text && u.Password == Co_mdp.Password
                            select u;

                User usr = query.FirstOrDefault();
                usr.Right = Right.USER;

                ((MainWindow)System.Windows.Application.Current.MainWindow).Affichage_nomUser.Text = usr.Pseudo + " - " +usr.Right.ToString() ;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("MDP ou User invalides");
            }

        }
    }
}
