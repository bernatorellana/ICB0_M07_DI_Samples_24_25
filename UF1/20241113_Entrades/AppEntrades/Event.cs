using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppEntrades
{
    public class Event
    {
		private TipusEvent tipus;
        private long id;
        private String nom;
        private String protagonista;
        private string imatgePath;
        private string desc;
        private datetime data;
        private List<Tarifa> tarifes;
        private Sala sala;
        private Estat estat;
    }
}