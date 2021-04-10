using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class Membre : Personne
    {
        //Attributs
        private bool competition;
        private double classement;
        private bool cotisation;
        private int nbmatchs;
        private int nbmatchsgagnes;

        //Constructeurs
        public Membre(string n, string p, string s, DateTime naissance, string adresse, string tel,bool compet, double classement, bool coti, int nbm, int nbmg) : base(n, p, s, naissance, adresse, tel)
        {
            this.competition = compet;
            this.classement = classement;
            this.cotisation = coti;
            this.nbmatchs = nbm;
            this.nbmatchsgagnes = nbmg;
        }

        public Membre(string n, string p) : base(n, p)
        {
        }

        #region Propriétés
        public bool Competition
        {
            get { return this.competition; }
            set { this.competition = value; }
        }

        public double Classement
        {
            get { return this.classement; }
            set { this.classement = value; }
        }

        public bool Cotisation
        {
            get { return this.cotisation; }
            set { this.cotisation = value; }
        }

        public int NbMatchs
        {
            get { return this.nbmatchs; }
            set { this.nbmatchs = value; }
        }

        public int NbMatchsGagnes
        {
            get { return this.nbmatchsgagnes; }
            set { this.nbmatchsgagnes = value; }
        }

        #endregion

        #region Méthodes

        public override string ToString()
        {
            return "Membre : " + this.Nom + " " + this.Prenom + " " + this.Sexe + " " + this.Naissance + " " + this.Adresse + " " + this.Tel + " compétition:" + this.competition + " classement:" + this.classement + " cotisation:" + this.cotisation ;
        }


        public bool Identiques(Membre m1)
        {
            bool identique = false;

            if (m1.Nom == this.Nom && m1.Prenom == this.Prenom && m1.Sexe == this.Sexe && m1.Naissance == this.Naissance)
            {
                identique = true;
            }

            return identique;
        }

        public bool Contient(List<Membre> liste)
        {
            bool contient = false;
            foreach (Membre membre in liste)
            {
                if (membre.Nom == this.Nom && membre.Prenom == this.Prenom && membre.Sexe == this.Sexe && membre.Naissance == this.Naissance)
                {
                    contient = true;
                }
            }

            return contient;
        }


        //Modifier l'adresse d'un membre:
        public Membre ModifierAdresse()
        {
            Console.WriteLine("Vous souhaitez modifier l'adresse de : " + this.ToString() + "\nVeuillez entrer la nouvelle adresse.");
            this.Adresse = Console.ReadLine();
            Console.WriteLine("La modification d'adresse a été effectuée : " + this.ToString());

            return this;
        }
       
        //Modifier le numéro de téléphone d'un membre:
        public Membre ModifierTel()
        {
            Console.WriteLine("Vous souhaitez modifier le numéro de téléphone de : " + this.ToString() + "\nVeuillez entrer le nouveau numéro.");
            this.Tel = Console.ReadLine();
            Console.WriteLine("La modification du numéro a été effectuée : " + this.ToString());

            return this;
        }

        //Vérifier le payement de la cotisation d'un membre
        public bool VerifCoti()
        {
            Console.WriteLine(this.Nom + " " + this.Prenom + " a payé sa cotisation : " + this.Cotisation);
            return this.Cotisation;
        }

       public bool Junior()
        {
            bool junior = false;
            DateTime ajourdhui = DateTime.Now;
            TimeSpan duree = ajourdhui - this.Naissance;
            int nbjours = duree.Days;

            int ans = nbjours / 365;

            if (ans < 18)
            {
                junior = true;
            }

            return junior;
        }

        #endregion

    }
}
