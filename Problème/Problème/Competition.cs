using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class Competition
    {
        //Attributs
        private int numero;
        private string ville;
        private string niveau;
        private int age;
        private DateTime date;
        private int duree;
        private int nb;
        private List<Membre> participants;

        //Constructeur
        public Competition(int n, string v, string niv,int age, DateTime d, int duree, int nombre, List<Membre> l)
        {
            this.numero = n;
            this.ville = v;
            this.niveau = niv;
            this.age = age;
            this.date = d;
            this.duree = duree;
            this.nb = nombre;
            this.participants = l;
        }

        public Competition()
        {
            this.numero = 0;
            this.ville = "";
            this.niveau = "";
            this.age = 0;
            this.date = new DateTime();
            this.duree = 0;
            this.nb = 0;
            this.participants = null;
        }

        #region Propriétés

        public int Numero
        {
            get { return this.numero; }
            set { this.numero = value; }
        }

        public string Ville
        {
            get { return this.ville; }
            set { this.ville = value; }
        }

        public string Niveau
        {
            get { return this.niveau; }
            set { this.niveau = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public int Duree
        {
            get { return this.duree; }
            set { this.duree = value; }
        }

        public int Nombre
        {
            get { return this.nb; }
            set { this.nb = value; }
        }

        public List<Membre> Participants
        {
            get { return this.participants; }
            set { this.participants = value; }
        }
        #endregion

        #region Méthodes
        public override string ToString()
        {
            string liste = "";
            foreach(Membre m in this.participants)
            {
                liste = liste + m.ToString() + " ,";
            }
            return "Compétition : " + this.numero + " " + this.ville + " " + this.niveau + " " + this.age + " " + this.date + " " + this.duree + " " + this.nb + ", équipe : " + liste;
        }

        //Méthode pour voir si un jour a le niveau adéquat pour cette compétition
        public bool Apte(Membre m)
        {
            bool autorisationNiveau = false;

            if (this.niveau == "Tout niveau")
            {
                autorisationNiveau = true;
            }

            if(this.niveau=="Départemental" && m.Classement < 30.0)
            {
                autorisationNiveau = true;
            }

            if(this.niveau == "Régional" && m.Classement < 15.0)
            {
                autorisationNiveau = true;
            }

            if(this.niveau == "National" && m.Classement < 0.0)
            {
                autorisationNiveau = true;
            }

            if (this.niveau == "International" && m.Classement < -15.0)
            {
                autorisationNiveau = true;
            }

            bool ageValide = false;
            if (this.Age <= m.Age(m.Naissance))
            {
                ageValide = true;
            }

            bool autorisation = false;
            if(autorisationNiveau && ageValide)
            {
                autorisation = true;
            }

            return autorisation;
        }

        //Ajouetr un participant
        public Competition AjouterParticipant(Membre m)
        {
            //On vérifie que le membre n'est pas déjà dans la liste et qu'il entre dans la catégorie de la compétition
            if (!m.Contient(this.participants) && Apte(m) && nb>this.participants.Count)
            {
                this.participants.Add(m);
                Console.WriteLine(m.Nom + " " + m.Prenom + " a été ajouté à la liste des participants à la compétition.");
            }
            else
            {
                Console.WriteLine(m.Nom + " " + m.Prenom + " n'a pas pu être ajouté à la liste des participants car il ne rentre pas dans les critères ou est déjà présent.");
            }
            return this;
        }

        public List<DateTime> ListeDate()
        {
            List<DateTime> liste = new List<DateTime>();
            int compteur = this.Duree;
            DateTime date = this.Date;
            while (compteur > 0)
            {
                liste.Add(date);
                date.AddDays(1);
                compteur -= 1;
            }
            return liste;
        }


        public bool CompetSuperposee(List<Competition> listeCompet)
        {
            bool validee = false;
            List<DateTime> liste1 = this.ListeDate();

            foreach(Competition compet in listeCompet)
            {
                List<DateTime> liste2 = compet.ListeDate();
                foreach(DateTime date1 in liste1)
                {
                    foreach(DateTime date2 in liste2)
                    {
                        if (date1 == date2)
                        {
                            validee = true;
                        }
                    }
                }
            }

            return validee;
        }

        public Competition CompetTrouvee(List<Competition> listeCompet)
        {
            Competition trouvee = new Competition();

            List<DateTime> liste1 = this.ListeDate();

            foreach (Competition compet in listeCompet)
            {
                List<DateTime> liste2 = compet.ListeDate();
                foreach (DateTime date1 in liste1)
                {
                    foreach (DateTime date2 in liste2)
                    {
                        if (date1 == date2)
                        {
                            trouvee = compet;
                        }
                    }
                }
            }

            return trouvee;
        }


        public bool JoueurDejaEngage(Competition compet)
        {
            bool memeJoueur = false;

            foreach(Membre m1 in this.Participants)
            {
                foreach(Membre m2 in compet.Participants)
                {
                    if (m1.Identiques(m2))
                    {
                        memeJoueur = true;
                    }
                }
            }

            return memeJoueur;
        }

        public List<Competition> AjouterCompet(List<Competition> liste)
        {
            if (!this.CompetSuperposee(liste))
            {
                Console.WriteLine("La compétition a été ajoutée avec succés.");
                liste.Add(this);
            }
            else
            {
                Competition superposee = CompetTrouvee(liste);
                if (!this.JoueurDejaEngage(superposee))
                {
                    Console.WriteLine("La compétition a été ajoutée avec succés.");
                    liste.Add(this);
                }
                else
                {
                    Console.WriteLine("Un joueur de l'équipe est déjà occuppé à ces dates.");
                }
            }

            return liste;
        }


        public List<double> EntrerResultats()
        {
            List<double> liste = new List<double>();

            //On vérifie que la compétition a eu lieu
            DateTime today = DateTime.Today;
            if (today > this.date)
            {
                //La compétition a eu lieu
                Console.WriteLine("Veuillez rentrez les résultats des matchs (2 pour double gagné, 1 pour simple gagné, 0 pour défaite.");
                int compteur = this.participants.Count;
                int total = this.participants.Count;
                double score = 0.0;

                do 
                {
                    Console.WriteLine("Entrez le résultat du joueur " + (total - compteur +1 ));
                    score = Convert.ToDouble(Console.ReadLine());
                    liste.Add(score);
                    this.participants[total - compteur].NbMatchs += 1;
                    if(score==2 || score == 1)
                    {
                        this.participants[total - compteur].NbMatchsGagnes += 1;
                    }
                    compteur -= 1;

                } while (compteur > 0);
            }

            else
            {
                Console.WriteLine("La compétition n'a pas encore eu lieu.");
            }

            return liste;
        }

        #endregion
    }
}
