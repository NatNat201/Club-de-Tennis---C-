using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    abstract class Personne
    {
        //Attributs
        private string nom;
        private string prenom;
        private string sexe;
        private DateTime naissance;
        private string adresse;
        private string tel;

        //Constructeurs
        public Personne(string n, string p, string s, DateTime naissance, string adresse, string tel)
        {
            this.nom = n;
            this.prenom = p;
            this.sexe = s;
            this.naissance = naissance;
            this.adresse = adresse;
            this.tel = tel;
        }

        public Personne(string n, string p)
        {
            this.nom = n;
            this.prenom = p;
        }

        #region Propriétés
        //Propriétés
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }

        public string Sexe
        {
            get { return this.sexe; }
            set { this.sexe = value; }
        }

        public DateTime Naissance
        {
            get { return this.naissance; }
            set { this.naissance = value; }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }

        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }
        #endregion


        public int Age(DateTime naissance)
        {
            DateTime aujourdhui = DateTime.Now;
            TimeSpan duree = aujourdhui - naissance;

            int age = duree.Days / 365;

            return age;
        }

    }
}
