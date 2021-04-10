using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class Personnel : Entraineur, IAdministration
    {
        string rib;
        DateTime entree;
        double salaire;


        public Personnel(string nom, string prenom, string sexe, DateTime datenaissance, string adresse, string tel, bool compet, double classement, bool coti, int nbMatch, int nbMatchGagnes, bool entraineurIndependant, bool entraineurSalarie, string rib, DateTime entree, double salaire) :
            base(nom, prenom, sexe, datenaissance, adresse, tel, compet, classement, coti, nbMatch, nbMatchGagnes, entraineurIndependant, entraineurSalarie)
        {
            this.rib = rib;
            this.entree = entree;
            this.salaire = salaire;
        }

        public Personnel(string nom, string prenom, string sexe, DateTime datenaissance) : base(nom, prenom)
        {
            this.Sexe = sexe;
            this.Naissance = datenaissance;
        }


        #region Propriétés

        public string Rib
        {
            get { return this.rib; }
            set { this.rib = value; }
        }

        public double Salaire
        {
            get { return this.salaire; }
            set { this.salaire = value; }
        }

        public DateTime Entree
        {
            get { return this.entree; }
            set { this.entree = value; }
        }

        public bool Administration
        {
            get;set;
        }

        #endregion


        #region Méthodes

        public override string ToString()
        {
            return base.ToString()+", rib : " + this.rib + ", salaire : " + this.salaire + ", date d'entrée dans la compagnie : " + this.entree;
        }

        public int Anciennete()
        {
            DateTime ajourdhui = DateTime.Now;
            TimeSpan duree = ajourdhui - this.entree;
            int nbjours = duree.Days;

            int anciennete = nbjours / 365;

            return anciennete;
        }

        public bool Identiques(Personnel p)
        {
            bool identique = false;

            if(p.Nom==this.Nom && p.Prenom==this.Prenom && p.Sexe==this.Sexe && p.Naissance == this.Naissance)
            {
                identique = true;
            }

            return identique;
        }

        public bool Contient(List<Personnel> liste)
        {
            bool contient = false;
            foreach (Personnel personnel in liste)
            {
                if (personnel.Nom == this.Nom && personnel.Prenom == this.Prenom && personnel.Sexe == this.Sexe && personnel.Naissance == this.Naissance)
                {
                    contient = true;
                }
            }

            return contient;
        }

        //Modifier l'adresse d'un membre du personnel :
        public Personnel ModifierAdressePersonnel()
        {
            Console.WriteLine("Vous souhaitez modifier l'adresse de : " + this.ToString() + "\nVeuillez entrer la nouvelle adresse.");
            this.Adresse = Console.ReadLine();
            Console.WriteLine("La modification d'adresse a été effectuée : " + this.ToString());

            return this;
        }


        //Modifier le numéro de téléphone d'un membre du personnel :
        public Personnel ModifierTelPersonnel()
        {
            Console.WriteLine("Vous souhaitez modifier le numéro de téléphone de : " + this.ToString() + "\nVeuillez entrer le nouveau numéro.");
            this.Tel = Console.ReadLine();
            Console.WriteLine("La modification du numéro a été effectuée : " + this.ToString());

            return this;
        }

        //Vérifier le payement de la cotisation d'un membre du personnel :
        public bool VerifCotiPersonnel()
        {
            Console.WriteLine(this.Nom + " " + this.Prenom + " a payé sa cotisation : " + this.Cotisation);
            return this.Cotisation;
        }

        #endregion

    }
}
