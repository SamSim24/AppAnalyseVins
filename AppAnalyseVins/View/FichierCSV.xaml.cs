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
using System.IO;
using System.Printing;

namespace TP2_POO2.View
{
    /// <summary>
    /// Interaction logic for FichierCSV.xaml
    /// </summary>
    public partial class FichierCSV : Window
    {
        public FichierCSV()
        {
            InitializeComponent();
            string cheminFichier = @"..\train_reduced.csv";

            string[] lines = File.ReadAllLines(cheminFichier);
            foreach (string line in lines)
            {
                Donnees.Text += line+"\n";
            }
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
