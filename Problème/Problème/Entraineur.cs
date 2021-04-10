using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class Entraineur : Membre
    {
        #region Attributs et cosntructeurs
        bool entraineurIndependant;
        bool entraineurSalarie;

        public Entraineur(string nom, string prenom, string sexe, DateTime naissance, string adresse, string tel,bool compet, double classement,bool coti, int nbM,int nbMG,bool entraineurIndependant, bool entraineurSalarie) : base(nom, prenom, sexe, naissance, adresse, tel, compet, classement, coti, nbM, nbMG)
        {
            this.entraineurIndependant = entraineurIndependant;
            this.entraineurSalarie = entraineurSalarie;
        }

        public Entraineur(string n, string p) : base(n, p) { }

        #endregion

        #region Propriétés
        public bool EntraineurIndependant
        {
            get { return entraineurIndependant; }
            set { entraineurIndependant = value; }
        }
        public bool EntraineurSalarie
        {
            get { return entraineurSalarie; }
            set { entraineurSalarie = value; }
        }
        #endregion

        #region Méthode
        public override string ToString()
        {
            return base.ToString() + "Est un entraineur indépendant : " + this.entraineurIndependant + "Est un entraineur salarié : " + this.entraineurSalarie + "Et fait-il de la compétition ? NC : n'en fait pas/ n'est pas classé et sinon donner son classement " + this.Classement;
        }
        #endregion 
    }
}
