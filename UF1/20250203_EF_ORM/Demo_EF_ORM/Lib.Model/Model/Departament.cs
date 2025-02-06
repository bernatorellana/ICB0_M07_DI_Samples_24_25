using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Model.Model
{
    public class Departament
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Nom { get; set; }

        public ICollection<Empleat> Empleats { get; set;}

        public override bool Equals(object? obj)
        {
            return obj is Departament departament &&
                   Id == departament.Id;
        }

        public override string? ToString()
        {
            return Nom;
        }



    }
}
