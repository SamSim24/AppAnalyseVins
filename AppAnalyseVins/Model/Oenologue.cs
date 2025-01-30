using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TP2_POO2.Model
{
    public class Oenologue : INotifyPropertyChanged
    {
        private string _oenologueId;
        private string? _appMDP;
        private string? _prenom;
        private string? _nom;
        private string? _dateNaissance;
        private string? _ville;
        private string? _province;
        private string? _pays;
        private string? _adresse;
        private string? _civilite;
        private bool _isValid;

        public ICollection<Client> Clients { get; set; }

        //Instance d'une collection de clients pour les oenologues
        public Oenologue() 
        {
            Clients = new List<Client>();
        }
        

        public string oenologueId
        {
            get
            {
                return _oenologueId;
            }
            set
            {
                if (_oenologueId != value)
                {
                    _oenologueId = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AppMDP
        {
            get
            {
                return _appMDP;
            }
            set
            {
                if (_appMDP != value)
                {
                    _appMDP = value;
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

        public void SetIsValid()
        {
            _isValid = !string.IsNullOrEmpty(nom) && !string.IsNullOrEmpty(prenom) && !string.IsNullOrEmpty(civilite);
        }

        //Méthode pour ajouter un oenologue
        public void AddOenologue(Model.Oenologue oenologue)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            tP2_POO2Context.Oenologues.Add(oenologue);
            tP2_POO2Context.SaveChanges();
        }
        //Méthode pour ajouter une liste de oenologues
        public void AddOenologue(List<Model.Oenologue> oenologues)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            tP2_POO2Context.Oenologues.AddRange(oenologues);
            tP2_POO2Context.SaveChanges();
        }

        //Méthode pour lire tous les oenologues dans la base de données
        public void ShowOenologue()
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            List<Model.Oenologue> oenologues = tP2_POO2Context.Oenologues.ToList();
        }

        //Méthode pour lire un oenologue en particulier dans la base de données
        public void ShowOenologue(int oenologueId)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Oenologue oenologue = tP2_POO2Context.Oenologues.Find(oenologueId);
        }

        //Méthode pour mettre à jour un client en particulier dans la base de données
        public void UpdateOenologue(string oenologueId, string prenom, string nom, string dateNaissance, string ville, string province, string pays, string adresse, string civilite)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Oenologue oenologue = tP2_POO2Context.Oenologues.Find(oenologueId);

            oenologue.prenom = prenom;
            oenologue.nom = nom;
            oenologue.dateNaissance = dateNaissance;
            oenologue.ville = ville;
            oenologue.province = province;
            oenologue.pays = pays;
            oenologue.adresse = adresse;
            oenologue.civilite = civilite;

            tP2_POO2Context.SaveChanges();
        }

        //Méthode pour supprimer un client en particulier dans la base de données
        public void DeleteOenologue(int oenologueId)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Oenologue oenologue = tP2_POO2Context.Oenologues.Find(oenologueId);
            tP2_POO2Context.Oenologues.Remove(oenologue);
            tP2_POO2Context.SaveChanges();
        }
    }
}
