using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model.Model
{
    public class Empleat: INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Salari { get; set; }
        public DateTime DataNaix { get; set; }

        public Departament Dept { get; set; }

        public ICollection<Projecte> Projectes { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
