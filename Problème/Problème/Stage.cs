using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class Stage
    {
        //On traite ici de stage pour les enfants 
        DateTime dateStage;
        int nbPlaces;
        int nbEntraineurs;
        List<Personnel> listeEntraineurs;
        List<Membre> listeMembres;

        //Constructeurs
        public Stage(DateTime dateStage, int nbPlaces, int nbEntraineurs, List<Personnel> listeEntraineurs, List<Membre> listeMembres)
        {
            this.dateStage = dateStage;
            this.nbPlaces = nbPlaces;
            this.nbEntraineurs = nbEntraineurs;
            this.listeEntraineurs = listeEntraineurs;
            this.listeMembres = listeMembres;
        }

        #region Propriétés

        public DateTime DateStage
        {
            get { return this.dateStage; }
            set { this.dateStage = value; }
        }

        public int NbPlaces
        {
            get { return this.nbPlaces; }
            set { this.nbPlaces = value; }
        }

        public int NbEntraineurs
        {
            get { return this.nbEntraineurs; }
            set { this.nbEntraineurs = value; }
        }

        public List<Personnel> ListeEntraineurs
        {
            get { return this.listeEntraineurs; }
            set { this.listeEntraineurs = value; }
        }

        public List<Membre> ListeMembres
        {
            get { return this.listeMembres; }
            set { this.listeMembres = value; }
        }

        #endregion

        #region Méthodes

        public override string ToString()
        {
            string liste1 = "";
            foreach (Membre m in this.listeEntraineurs)
            {
                liste1 = liste1 + m.ToString() + " ,";
            }

            string liste2 = "";
            foreach (Membre m in this.listeMembres)
            {
                liste2 = liste2 + m.ToString() + " ,";
            }

            return "Stage :" + this.dateStage + " " + this.NbPlaces + " " + this.NbEntraineurs + " " + liste1 + " " + liste2;
        }

        public bool StageComplet()
        {
            bool complet = false;

            if (this.nbPlaces == this.listeMembres.Count)
            {
                complet = true;
            }

            return complet;
        }

        #endregion

    }
}
