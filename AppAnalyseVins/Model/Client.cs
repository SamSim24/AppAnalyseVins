using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TP2_POO2.Migrations;

namespace TP2_POO2.Model
{
    //INotify.. Indique au binding un changement dans la valeur de
    //Pour eviter le surlignement, on definie avec le ? que la variable is nullable
    public class Client : INotifyPropertyChanged
    {
        private int _clientId;
        private string? _prenom;
        private string? _nom;
        private string? _dateNaissance;
        private string? _ville;
        private string? _province;
        private string? _pays;
        private string? _adresse;
        private string? _civilite;
        private bool _isValid;

        //Clé étrangère de Oenologue
        public string oenologueId { get; set; }
        public Oenologue Oenologue {  get; set; }

        //Instance d'une collection de vins des clients
        public Client()
        {
            Vins = new List<Vin>();
        }
        public ICollection<Vin> Vins { get; set; }

        public int clientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                if (_clientId != value)
                {
                    _clientId = value;
                    OnPropertyChanged();
                }
            }
        }

        public string prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string nom
        {
            get
            {
                return _nom;
            }
            set
            {
                if (_nom != value)
                {
                    _nom = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string dateNaissance
        {
            get
            {
                return _dateNaissance;
            }
            set
            {
                if (_dateNaissance != value)
                {
                    _dateNaissance = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string ville
        {
            get
            {
                return _ville;
            }
            set
            {
                if (_ville != value)
                {
                    _ville = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string province
        {
            get
            {
                return _province;
            }
            set
            {
                if (_province != value)
                {
                    _province = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string pays
        {
            get
            {
                return _pays;
            }
            set
            {
                if (_pays != value)
                {
                    _pays = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string adresse
        {
            get
            {
                return _adresse;
            }
            set
            {
                if (_adresse != value)
                {
                    _adresse = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string civilite
        {
            get
            {
                return _civilite;
            }
            set
            {
                if (_civilite != value)
                {
                    _civilite = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }

        public bool IsValid
        {
            get { return _isValid; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SetIsValid()
        {
            _isValid = !string.IsNullOrEmpty(nom) && !string.IsNullOrEmpty(prenom) && !string.IsNullOrEmpty(civilite) && !string.IsNullOrEmpty(dateNaissance) && !string.IsNullOrEmpty(ville) && !string.IsNullOrEmpty(province) && !string.IsNullOrEmpty(pays) && !string.IsNullOrEmpty(adresse);
        }


        //Méthode pour ajouter un client
        public void AddClient(Model.Client client)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            //client.oenologueId = Connex
            tP2_POO2Context.Clients.Add(client);
            tP2_POO2Context.SaveChanges();
        }
        //Méthode pour ajouter une liste de clients
        public void AddClient(List<Model.Client> clients)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            tP2_POO2Context.Clients.AddRange(clients);
            tP2_POO2Context.SaveChanges();
        }

        //Méthode pour lire tous les clients dans la base de données
        public void ShowClient()
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            List<Model.Client> clients = tP2_POO2Context.Clients.ToList();
        }

        //Méthode pour lire un client en particulier dans la base de données
        public void ShowClient(int clientId)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Client client = tP2_POO2Context.Clients.Find(clientId);
        }

        //Méthode pour mettre à jour un client en particulier dans la base de données
        public void UpdateClient(int clientId, string prenom, string nom, string dateNaissance, string ville, string province, string pays, string adresse, string civilite)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Client client = tP2_POO2Context.Clients.Find(clientId);

            client.prenom = prenom;
            client.nom = nom;
            client.dateNaissance = dateNaissance;
            client.ville = ville;
            client.province = province;
            client.pays = pays;
            client.adresse = adresse;
            client.civilite = civilite;

            tP2_POO2Context.SaveChanges();
        }

        //Méthode pour supprimer un client en particulier dans la base de données
        public void DeleteClient(int clientId)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Client client = tP2_POO2Context.Clients.Find(clientId);
            tP2_POO2Context.Clients.Remove(client);
            tP2_POO2Context.SaveChanges();
        }
    }
}
