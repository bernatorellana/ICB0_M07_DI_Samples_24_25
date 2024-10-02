using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20241002_Classes.model
{
    internal class Persona
    {
        #region atributs
        private String nom;
        private int id;
        private String cognoms;

        public Persona(string nom, int id, string cognoms)
        {
            this.Nom = nom;
            this.Id = id;
            this.Cognoms = cognoms;
        }
        #endregion


        #region properties
        public String Nom
		{
			get { return nom; }
			set {
				if (value == null || value.Length < 2) throw new ArgumentException();
				nom = value; }
		}

        public int Id { get => id; set => id = value; }
        public string Cognoms { get => cognoms; set => cognoms = value; }

        public override bool Equals(object obj)
        {
            return obj is Persona persona &&
                   Id == persona.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id+":"+Nom+","+Cognoms;
        }
        #endregion




    }
}
