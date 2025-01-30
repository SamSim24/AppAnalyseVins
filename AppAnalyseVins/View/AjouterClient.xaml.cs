
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
using TP2_POO2.Model;
using TP2_POO2.ModelView;

namespace TP2_POO2.View
{
    /// <summary>

    public partial class AjouterClient : Window
    {
        public AjouterClient()
        {
            InitializeComponent();
            this.DataContext = new TP2ViewModel();
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal(idOenologue.Text);
            menuPrincipal.Show();
            this.Close();
        }
    }
}


