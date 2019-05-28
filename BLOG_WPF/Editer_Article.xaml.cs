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
    /// Logique d'interaction pour Editer_Article.xaml
    /// </summary>
    public partial class Editer_Article : Window
    {
        public Editer_Article(MainWindow w)
        {
            InitializeComponent();
            mw = w;
        }

        private MainWindow mw;

        private void Valider_Article_Edit_Click(object sender, RoutedEventArgs e)
        {
            Article art = new Article(Champ_Titre_Edit.Text, Champ_Article_Content_Edit.Text, mw.Connected_user);
            mw.DB.Article.Add(art);
            mw.Collection_Article.Add(art);
            mw.DB.SaveChanges();
            MessageBox.Show("Article édité par " + mw.Connected_user.Pseudo);
            this.Close();
        }

        private void RAZ_Click(object sender, RoutedEventArgs e)
        {
            Champ_Titre_Edit.Text = "";
            Champ_Article_Content_Edit.Text = "";
        }
    }
}
