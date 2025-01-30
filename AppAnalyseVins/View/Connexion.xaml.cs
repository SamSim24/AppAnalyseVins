using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP2_POO2.Model;

namespace TP2_POO2
{
    public partial class Connexion : Window
    {
        public string OenologueIdGlobal {  get; set; }
        public Connexion()
        {
            InitializeComponent();
            DataContext = new ModelView.TP2ViewModel();
        }

        //doit valider que l'identifiant et le mot de passe sont valide.
        private void OuvrirMenuPrincipal(object sender, RoutedEventArgs e)
        {
            string identifiant = IdTextBox.Text;
            string motDePasse = MdpBox.Password;
            OenologueIdGlobal = identifiant;

            bool identificationValide = ValiderID(identifiant, motDePasse);

            if (identificationValide)
            {
                string messageBienvenue = "Bienvenue " + identifiant + " dans notre application!";
                MenuPrincipal menuPrincipal = new MenuPrincipal(identifiant);
                menuPrincipal.Show();

                this.Close();
            }

            else
            {
                MessageBox.Show("Identifiant ou mot de passe invalide", "Erreur de connexion", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        //bool pour valider la connexion
        private bool ValiderID(string identifiant, string motDePasse)
        {
            using (var context = new TP2_POO2Context())
            {
                var oenologue = context.Oenologues.FirstOrDefault(o => o.AppMDP == motDePasse && o.oenologueId == identifiant);
                return oenologue != null;
            }
        }

        private void clickInscription(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vous etes inscrit a l'application! Bienvenue, vous serez redirigez vers l'onglet de connexion");
            pageConnexion.SelectedIndex = 0;
        }
    }
}