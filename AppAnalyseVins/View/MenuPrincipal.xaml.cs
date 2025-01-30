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
using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TP2_POO2.View;
using TP2_POO2.Model;
using CsvHelper;
using ConsoleTables;
using SimpleDecisionTreeLibrary;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using System.Data;

namespace TP2_POO2
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        private string identifiantUtilisateur;
        private string prenomUtilisateur;
        private string nomUtilisateur;
        private int clientId;
        public MenuPrincipal(string identifiantUtilisateur)
        {
            InitializeComponent();
            DataContext = new ModelView.TP2ViewModel();
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            ClientDataGrid.ItemsSource = tP2_POO2Context.Clients.ToList();
            VinDataGrid.ItemsSource = tP2_POO2Context.Vins.ToList();
            this.identifiantUtilisateur = identifiantUtilisateur;
            ExtraireInformationsUtilisateur();
            initialiserBienvenue();
        }
        
        private void initialiserBienvenue()
        {
            string messageBienvenue = "Bienvenue " + identifiantUtilisateur + ", " + prenomUtilisateur + " " + nomUtilisateur + " dans votre application de gestion des clients et d'évaluation de vin.";
            MessageBienvenueTextBlock.Text = messageBienvenue;
        }

        private void ExtraireInformationsUtilisateur()
        {
            using (var context = new TP2_POO2Context())
            {
                var utilisateur = context.Oenologues.FirstOrDefault(u => u.oenologueId == identifiantUtilisateur);
                if (utilisateur != null)
                {
                    prenomUtilisateur = utilisateur.prenom;
                    nomUtilisateur = utilisateur.nom;
                }
            }
        }
      

        //Méthode reliée au boutton Ouvrir dans le menu, ouvre en fenêtre modale le fichier CSV.
        private void OuvrirFichier(object sender, RoutedEventArgs e)
        {
            FichierCSV fichierCSV = new FichierCSV();
            fichierCSV.ShowDialog();
        }
        //Méthode reliée au boutton Quitter dans le menu, ramène à la page de connexion
        private void Quitter(object sender, RoutedEventArgs e)
        {
            Connexion connexion = new Connexion();
            connexion.Show();
            this.Close();
        }

        private void ConstruireArbre(object sender, RoutedEventArgs e)
        {
            string cheminFichier = @"..\train_reduced.csv";
            DecisionTree decisionTree = new DecisionTree();

            decisionTree.BuildTree(cheminFichier);
            ArbreConstruit.Content = "L'arbre de décision a été créer à partir du fichier suivant:" + cheminFichier;
        }
        private void PrecisionArbre(object sender, RoutedEventArgs e)
        {
            string cheminFichier = @"..\train_reduced.csv";
            DecisionTree decisionTree = new DecisionTree();

            decisionTree.BuildTree(cheminFichier);
            float precision = decisionTree.Evaluate(cheminFichier);

            ArbrePrecision.Content = "La prédiction de l'arbre est de " + precision;
        }
        private void MatriceConfusion(object sender, RoutedEventArgs e)
        {
            string cheminFichier = @"..\train_reduced.csv";

            DecisionTree decisionTree = new DecisionTree();

            decisionTree.BuildTree(cheminFichier);

          

        }

        //Méthode pour supprimer le vin qu'on a cliqué
        private void SupprimerVin(object sender, RoutedEventArgs e)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();

            // Récupérer le bouton qui a été cliqué
            Button button = sender as Button;

            // Récupérer le vin associé à la ligne où le bouton a été cliqué
            var vin = button.DataContext as Vin;

            vin.DeleteVin(vin.vinId);
            VinDataGrid.ItemsSource = tP2_POO2Context.Vins.ToList();
            VinDataGrid.Items.Refresh();

        }
        public void ButtonRefresh(object sender, RoutedEventArgs e)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            VinDataGrid.ItemsSource = tP2_POO2Context.Vins.ToList();
            ClientDataGrid.ItemsSource = tP2_POO2Context.Clients.ToList();
            clientIdData.Text = null; alcoolData.Text = null; sulphateData.Text = null; acideCitriqueData.Text = null; acideVolatileData.Text = null;

            VinDataGrid.Items.Refresh();
            ClientDataGrid.Items.Refresh();

        }

        private void SupprimerClient(object sender, RoutedEventArgs e)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();

            // Récupérer le bouton qui a été cliqué
            Button button = sender as Button;

            // Récupérer le client associé à la ligne où le bouton a été cliqué
            var client = button.DataContext as Client;

            client.DeleteClient(client.clientId);

            ClientDataGrid.ItemsSource = tP2_POO2Context.Clients.ToList();
            ClientDataGrid.Items.Refresh();

        }

        //Méthode pour afficher les champs de modifications du client et de prendre l'ID du client en question
        private void AfficherModification(object sender, RoutedEventArgs e)
        {
            // Récupérer le bouton qui a été cliqué
            Button button = sender as Button;

            // Récupérer le client associé à la ligne où le bouton a été cliqué
            var client = button.DataContext as Client;

            clientId = client.clientId;


            if (Modification.Visibility == Visibility.Collapsed)
            {
                Modification.Visibility = Visibility.Visible;
            }
            else
            {
                Modification.Visibility = Visibility.Collapsed;
            }
        }

        //Méthode pour modifier le client
        private void ModifierClient(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();

            //Si aucun champ n'est vide, on va modifier le client
            if (!PrenomClient.Text.IsNullOrEmpty() && !NomClient.Text.IsNullOrEmpty() && !DateNaissanceClient.Text.IsNullOrEmpty() && !VilleClient.Text.IsNullOrEmpty() && !ProvinceClient.Text.IsNullOrEmpty() && !PaysClient.Text.IsNullOrEmpty() && !AdresseClient.Text.IsNullOrEmpty() && !CiviliteClient.Text.IsNullOrEmpty())
            {
                client.UpdateClient(clientId, PrenomClient.Text, NomClient.Text, DateNaissanceClient.Text, VilleClient.Text, ProvinceClient.Text, PaysClient.Text, AdresseClient.Text, CiviliteClient.Text);
                PrenomClient.Text = null; NomClient.Text = null; DateNaissanceClient.Text = null; VilleClient.Text = null; ProvinceClient.Text = null; PaysClient.Text = null; AdresseClient.Text = null; CiviliteClient.Text = null;
                ClientDataGrid.Items.Refresh();

                //Pour cacher les champs de modifications
                if (Modification.Visibility == Visibility.Collapsed)
                {
                    Modification.Visibility = Visibility.Visible;
                }
                else
                {
                    Modification.Visibility = Visibility.Collapsed;
                }
            }
            else
                MessageBox.Show("Informations manquantes:\nVeuillez remplir tous les champs avant de modifier.", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Error);
            ClientDataGrid.ItemsSource = tP2_POO2Context.Clients.ToList();
            ClientDataGrid.Items.Refresh();
        }

        //Méthode pour modifier l'oenologue connecté
        private void ModifierOenologue(object sender, RoutedEventArgs e)
        {
            Oenologue oenologue = new Oenologue();

            //Si aucun champ n'est vide, on va modifier le client
            if (!PrenomOenologue.Text.IsNullOrEmpty() && !NomOenologue.Text.IsNullOrEmpty() && !DateNaissanceOenologue.Text.IsNullOrEmpty() && !VilleOenologue.Text.IsNullOrEmpty() && !ProvinceOenologue.Text.IsNullOrEmpty() && !PaysOenologue.Text.IsNullOrEmpty() && !AdresseOenologue.Text.IsNullOrEmpty() && !CiviliteOenologue.Text.IsNullOrEmpty())
            {
                oenologue.UpdateOenologue(identifiantUtilisateur, PrenomOenologue.Text, NomOenologue.Text, DateNaissanceOenologue.Text, VilleOenologue.Text, ProvinceOenologue.Text, PaysOenologue.Text, AdresseOenologue.Text, CiviliteOenologue.Text);
                PrenomOenologue.Text = null; NomOenologue.Text = null; DateNaissanceOenologue.Text = null; VilleOenologue.Text = null; ProvinceOenologue.Text = null; PaysOenologue.Text = null; AdresseOenologue.Text = null; CiviliteOenologue.Text = null;
                MenuPrincipal menuPrincipal = new MenuPrincipal(identifiantUtilisateur);
                menuPrincipal.Show();
                this.Close();
            }
            else
                MessageBox.Show("Informations manquantes:\nVeuillez remplir tous les champs avant de modifier.", "Erreur de modification", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void OuvrirPage(object sender, RoutedEventArgs e)
        {
            AjouterClient ajouterClient = new AjouterClient();
            ajouterClient.ShowDialog();
        }

        private void Clic_prediction(object sender, RoutedEventArgs e)
        {
            DecisionTree DecisionTree = new DecisionTree();

            string alcool = alcoolTextBox.Text;
            string sulphate = sulphateTextBox.Text;
            string acideVolatile = volatileTextBox.Text;
            string acideCitrique = volatileTextBox.Text;

            if (!EstNumerique(alcool) || !EstNumerique(sulphate) || !EstNumerique(acideVolatile) || !EstNumerique(acideCitrique))
            {
                MessageBox.Show("Veuillez saisir des valeurs valide", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string[] caracteristiqueVin = new string[] { alcool, sulphate, acideVolatile, acideCitrique };
            string qualitePredite = DecisionTree.Classify(caracteristiqueVin);
            qualiteTextBox.Text = "Qualité prédite du vin: " + qualitePredite;
            qualiteTextBox.Visibility = Visibility.Visible;
        }

        private bool EstNumerique(string valeur)
        {
            return double.TryParse(valeur, out _);
        }
    }
}
