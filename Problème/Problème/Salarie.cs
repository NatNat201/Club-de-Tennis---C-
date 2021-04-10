using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class Salarie : Personne
    {
        //Attributs
        private string rib;
        private int salaire;
        private DateTime entree;

        //Contructeur
        public Salarie(string n, string p, string s, DateTime naissance, string adresse, string tel, string rib, int salaire, DateTime entree) : base(n, p, s, naissance, adresse, tel)
        {
            this.rib = rib;
            this.salaire = salaire;
            this.entree = entree;
        }

        public Salarie(string n, string p) : base(n, p)
        {

        }

        #region Propriétés
        //Propriétes
        public string Rib
        {
            get { return this.rib; }
            set { this.rib = value; }
        }

        public int Salaire
        {
            get { return this.salaire; }
            set { this.salaire = value; }
        }

        public DateTime Entree
        {
            get { return this.entree; }
            set { this.entree = value; }
        }
        #endregion

        #region Méthodes
        public override string ToString()
        {
            return "Salarie : " + this.Nom + " " + this.Prenom + " " + this.Sexe + " " + this.Naissance + " " + this.Adresse + " " + this.Tel + " rib:" + this.rib + " salaire:" + this.salaire + "euros, date d'entrée:" + this.entree;
        }


        public bool Identiques(Salarie s)
        {
            bool identique = false;

            if (s.Nom == this.Nom && s.Prenom == this.Prenom && s.Sexe == this.Sexe && s.Naissance == this.Naissance)
            {
                identique = true;
            }

            return identique;
        }

        public bool Contient(List<Salarie> liste)
        {
            bool contient = false;
            foreach (Salarie salarie in liste)
            {
                if (salarie.Nom == this.Nom && salarie.Prenom == this.Prenom && salarie.Sexe == this.Sexe && salarie.Naissance == this.Naissance)
                {
                    contient = true;
                }
            }

            return contient;
        }


        //Modifier l'adresse d'un salarié
        public Salarie ModifierAdresse()
        {
            Console.WriteLine("Vous souhaitez modifier l'adresse de : " + this.ToString() + "\nVeuillez entrer la nouvelle adresse.");
            this.Adresse = Console.ReadLine();
            Console.WriteLine("La modification d'adresse a été effectuée : " + this.ToString());

            return this;
        }

        //Modifer le numéro de téléphone d'un salarié
        public Salarie ModifierTel()
        {
            Console.WriteLine("Vous souhaitez modifier le numéro de téléphone de : " + this.ToString() + "\nVeuillez entrer le nouveau numéro.");
            this.Tel = Console.ReadLine();
            Console.WriteLine("La modification du numéro a été effectuée : " + this.ToString());

            return this;
        }

        #endregion

    }
}
