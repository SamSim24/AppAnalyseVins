using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Windows.Shapes;


namespace TP2_POO2.Model
{
    public class Vin : INotifyPropertyChanged
    {
        private int _vinId;    
        private string? _alcool;
        private string? _sulphate;
        private string? _acideVolatile;
        private string? _acideCitrique;
        private bool _isValid;

        //Clé étrangère de Client
        public int clientId { get; set; }
        public Client? Client { get; set; }

        public int vinId
        {
            get
            {
                return _vinId;
            }
            set
            {
                if (_vinId != value)
                {
                    _vinId = value;
                    OnPropertyChanged();
                }
            }
        }
        public string alcool
        {
            get
            {
                return _alcool;
            }
            set
            {
                if (_alcool != value)
                {
                    _alcool = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string sulphate
        {
            get
            {
                return _sulphate;
            }
            set
            {
                if (_sulphate != value)
                {
                    _sulphate = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }

        }
        public string acideVolatile
        {
            get
            {
                return _acideVolatile;
            }
            set
            {
                if (_acideVolatile != value)
                {
                    _acideVolatile = value;
                    OnPropertyChanged();
                    SetIsValid();
                }
            }
        }
        public string acideCitrique
        {
            get
            {
                return _acideCitrique;
            }
            set
            {
                if (_acideCitrique != value)
                {
                    _acideCitrique = value;
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
            _isValid = !string.IsNullOrEmpty(alcool) && !string.IsNullOrEmpty(sulphate) && !string.IsNullOrEmpty(acideCitrique) && !string.IsNullOrEmpty(acideVolatile);
        }


        //Méthode pour ajouter un vin
        public void AddVin(Model.Vin vin)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            tP2_POO2Context.Vins.Add(vin);
            tP2_POO2Context.SaveChanges();
        }
        //Méthode pour ajouter une liste de vins
        static void AddVin(List<Model.Vin> vins)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            tP2_POO2Context.Vins.AddRange(vins);
            tP2_POO2Context.SaveChanges();
        }

        //Méthode pour lire tous les vins dans la base de données
        public void ShowVin()
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            List<Model.Vin> vins = tP2_POO2Context.Vins.ToList();
        }

        //Méthode pour lire un vin en particulier dans la base de données
        public void ShowVin(int vinId)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Vin vin = tP2_POO2Context.Vins.Find(vinId);
        }

        //Méthode pour mettre à jour un vin en particulier dans la base de données
        public void UpdateVin(int vinId, string alcool, string sulphate, string acideCitrique, string acideVolatile)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Vin vin = tP2_POO2Context.Vins.Find(vinId);

            vin.alcool = alcool;
            vin.sulphate = sulphate;
            vin.acideCitrique = acideCitrique;
            vin.acideVolatile = acideVolatile;

            tP2_POO2Context.SaveChanges();
        }

        //Méthode pour supprimer un vin en particulier dans la base de données
        public void DeleteVin(int vinId)
        {
            TP2_POO2Context tP2_POO2Context = new TP2_POO2Context();
            Model.Vin vin = tP2_POO2Context.Vins.Find(vinId);
            tP2_POO2Context.Vins.Remove(vin);
            tP2_POO2Context.SaveChanges();
        }
    }
}
