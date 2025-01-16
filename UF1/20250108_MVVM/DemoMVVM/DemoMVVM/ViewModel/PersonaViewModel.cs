using DemoMVVM.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace DemoMVVM.ViewModel
{
    public class PersonaViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Persona persona;


        public PersonaViewModel PersonaOriginal { get; set; }


        public PersonaViewModel(PersonaViewModel p)
        {
            this.PersonaOriginal = p;
            this.Id = p.Id;
            this.persona = p.persona;
            this.Nom = p.Nom;
            this.Sexe = p.Sexe;
            this.IsActiu = p.IsActiu;
            this.ImageURL = p.ImageURL;
            this.Edat = p.Edat;
        }
        public PersonaViewModel(Persona p)
        {
            this.Id = p.Id;
            this.persona = p;
            this.Nom = p.Nom;
            this.Sexe = p.Sexe;
            this.IsActiu = p.Actiu;
            this.ImageURL = p.ImageURL;
            this.Edat = p.Edat+"";
         }
        public int Id { get; set; }
        public String Nom { get; set; }
        public SexeEnum Sexe { get; set; }
        public bool IsActiu { get; set; }
        public String ImageURL { get; set; }
        public String Edat{ get; set; }


        public String EdatError { get
            {
                if (Persona.ValidaEdat(Edat))
                    return "";
                else return "Ruc, escriu l'edat.";
            } 
        }
        public bool EsValida
        {
            get
            {
                return (Persona.ValidaEdat(Edat) && 
                    Persona.ValidaNom(Nom));                    
            }
        }

        public Visibility CancelVisibility
        {
            get { return 
                    !this.Nom.Equals(this.persona.Nom) ||
                    !this.Edat.Equals(this.persona.Edat + "") ||
                     this.IsActiu!=persona.Actiu ||
                     this.Sexe!=persona.Sexe ? Visibility.Visible : Visibility.Collapsed;                                                            
                    }
        }


        public Brush EdatBackground
        {
            get
            {
                if (Persona.ValidaEdat(Edat))
                    return new SolidColorBrush(Colors.White);
                else return new SolidColorBrush(Colors.Red);
            }
        }

        public ArrayList ListSexe
        {
            get {
                // La llista de sexes ha de ser estàtica doncs és la mateixa 
                // per tots els objectes de tipus PersonaViewModel
                if (listSexes == null)
                {
                    listSexes = new ArrayList(Enum.GetValues(typeof(SexeEnum)));
                }
                return listSexes;
            }
        }

        private static ArrayList listSexes;


        public void Save()
        {
           

            PersonaOriginal.Nom = persona.Nom = this.Nom;

            int e;
            if(int.TryParse(this.Edat, out e))
            {
                persona.Edat = e;
                PersonaOriginal.Edat = this.Edat;
            }

            PersonaOriginal.IsActiu = persona.Actiu = this.IsActiu;
            PersonaOriginal.Sexe    = persona.Sexe  = this.Sexe;

            
            
            // Demanar a la UI que actualitzi l'estat del botó cancel i
            // del botó EsValida:
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CancelVisibility"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EsValida"));

        }


    }
}
