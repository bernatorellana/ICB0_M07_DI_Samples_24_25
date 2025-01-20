using DemoMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVVM.ViewModel
{
    internal class MainPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public PersonaViewModel PersonaSeleccionada { get; set; }


        private ObservableCollection<PersonaViewModel> persones;

		public ObservableCollection<PersonaViewModel> Persones
		{
			get { return persones; }
            set { persones = value; }
		}

        
        public MainPageViewModel()
        {
            LoadPersones();
        }

        public void LoadPersones()
        {
            Persones = new ObservableCollection<PersonaViewModel>(
                                Persona.GetPersones().Select(
                                    p => new PersonaViewModel(p)
                                )
                            );
        }

        public void NewPerson()
        {
            PersonaSeleccionada = new PersonaViewModel();
            PersonaSeleccionada.PersonaOriginal = new PersonaViewModel();
        }

        
    }
}
