using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TP2_POO2.Model;
using System.Collections.ObjectModel;

namespace TP2_POO2.ModelView
{
    public class TP2ViewModel
    {
        public Model.Vin Vin { get; set; }
        public ICommand VinCommand { get; private set; }


        public Model.Client Client { get; set; }
        public ObservableCollection<string> Civilite { get; set; }
        public ICommand ClientCommand { get; private set; }



        public Model.Oenologue Oenologue { get; set; }
        public ICommand AddOenologueCommand { get; private set; }




        public TP2ViewModel()
        {
            Vin = new Model.Vin();


            VinCommand = new RelayCommand(
                o => Vin.IsValid,
                o => Vin.AddVin(Vin)
                );

            Client = new Model.Client();

            Civilite = new ObservableCollection<string>() { "Monsieur", "Madame" };

            ClientCommand = new RelayCommand(
                o => Client.IsValid,
                o => Client.AddClient(Client)
                );

            Oenologue = new Model.Oenologue();

            AddOenologueCommand = new RelayCommand(
                o => Oenologue.IsValid,
                o => Oenologue.AddOenologue(Oenologue)
                );
        }

      
    }
}
