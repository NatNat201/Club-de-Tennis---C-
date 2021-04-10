using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class StageJunior
    {
        #region Attributs et constructeur
        DateTime dateStage;
        int nbPlaces;
        int nbEntraineurs;
        List<Entraineur> listeEntraineurs;
        List<Membre> listeMembres;

        public StageJunior(DateTime dateStage, int nbPlaces, int nbEntraineurs, List<Entraineur> listeEntraineurs, List<Membre> listeMembres)
        {
            this.dateStage = dateStage;
            this.nbPlaces = nbPlaces;
            this.nbEntraineurs = nbEntraineurs;
            this.listeEntraineurs = listeEntraineurs;
            this.listeMembres = listeMembres;
        }
        #endregion

        #region Propriétés
        public DateTime DateStage
        {
            get { return dateStage; }
            set { dateStage = value; }
        }

        public int NbPlaces
        {
            get { return nbPlaces; }
            set { nbPlaces = value; }
        }

        public int NbEntraineurs
        {
            get { return nbEntraineurs; }
            set { nbEntraineurs = value; }
        }

        public List<Entraineur> ListeEntraineurs
        {
            get { return listeEntraineurs; }
            set { listeEntraineurs = value; }
        }

        public List<Membre> ListeMembres
        {
            get { return listeMembres; }
            set { listeMembres = value; }
        }
        #endregion 
    }
}
