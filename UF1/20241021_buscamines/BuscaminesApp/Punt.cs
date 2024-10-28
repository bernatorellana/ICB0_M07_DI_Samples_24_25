using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BuscaminesApp
{
    internal class Punt
    {

        public TextBlock MinaText{ get; set; }

        public bool isFlagged { get; set; }

        public Punt(int f, int c)
        {
            F = f;
            C = c;
        }

        public int F { get; set; }
        public int C { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Punt punt &&
                   F == punt.F &&
                   C == punt.C;
        }

        public override int GetHashCode()
        {
            int hashCode = 609168659;
            hashCode = hashCode * -1521134295 + F.GetHashCode();
            hashCode = hashCode * -1521134295 + C.GetHashCode();
            return hashCode;
        }
    }
}
