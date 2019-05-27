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
using System.Data.Entity;

namespace BLOG_WPF
{
    /// <summary>
    /// Logique d'interaction pour signin.xaml
    /// </summary>
    public partial class signin : Window
    {
        public signin(MainWindow w)
        {
            InitializeComponent();
            mw = w;
        }

        private MainWindow mw;

        private void Validation_Inscription_Click(object sender, RoutedEventArgs e)
        {
            bool pseudoDejaPris = false;

            User user = new User(Champ_pseudo.Text, Champ_password.Password);

            foreach (User item in mw.DB.User)
            {
                if (Champ_pseudo.Text == item.Pseudo)
                {
                    pseudoDejaPris = true;
                }
            }

            if (pseudoDejaPris)
            {
                mw.DB.User.Add(user);
                mw.DB.SaveChanges();
                MessageBox.Show("Vous vous êtes bien enregistré", "Bien enregistré", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            } else
            {
                MessageBox.Show("Pseudo déjà utilisé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
