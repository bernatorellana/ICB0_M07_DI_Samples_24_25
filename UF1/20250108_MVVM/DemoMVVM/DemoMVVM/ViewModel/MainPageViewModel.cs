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
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


		private ObservableCollection<Persona> persones;

		public ObservableCollection<Persona> Persones
		{
			get { return persones; }
            set { persones = value; }
		}

        
        public MainPageViewModel()
        {
                Persones = Persona.GetPersones();
        }
    }
}
