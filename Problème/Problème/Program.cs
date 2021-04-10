using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problème
{
    class Program
    {
        #region Module Membre

        //On crée une base pour la liste de membres:
        static List<Membre> Init_Membres()
        {
            List<Membre> liste = new List<Membre>();
            Membre m1 = new Membre("Dupont", "Henri", "Homme", new DateTime(1997, 10, 20), "91 rue de Rivoli", "0648597410", false, 40.0, true, 0, 0);
            Membre m2 = new Membre("Martin", "Camille", "Femme", new DateTime(1989, 07, 03), "7 place de la Fontaine", "0784512230", true, 30.5, true, 10, 7);
            Membre m3 = new Membre("Fournier", "Pierre", "Homme", new DateTime(2000, 09, 18), "45 rue des Boulets", "0648495755", true, 27.0, true, 24, 13);
            Membre m4 = new Membre("Laforge", "Claudine", "Femme", new DateTime(1980, 12, 05), "2 place François Ier", "0654558913", true, 0.5, false, 84, 79);
            Membre m5 = new Membre("Laforge", "Luc", "Homme", new DateTime(1979, 10, 10), "64 rue de Rome", "0748451962", false, 50.0, false, 0, 0);
            Membre m6 = new Membre("Leroy", "Dominique", "Homme", new DateTime(1985, 04, 17), "6 rue du Chariot", "0701013634", true, -1.5, true, 127, 119);
            Membre m7 = new Membre("Dujardin", "Emilie", "Femme", new DateTime(2001, 12, 08), "4 place de l'Opéra", "0614108134", true, -0.2, false, 61, 60);
            Membre m8 = new Membre("Martin", "Eric", "Homme", new DateTime(2005, 06, 18), "5 place Dorin", "0631342851", false, 40.0, true, 0, 0);
            Membre m9 = new Membre("Fernandez", "Elia", "Femme", new DateTime(2009, 02, 21), "9 boulevard Haussman", "0784312690", false, 40.0, true, 0, 0);

            liste.Add(m1);
            liste.Add(m2);
            liste.Add(m3);
            liste.Add(m4);
            liste.Add(m5);
            liste.Add(m6);
            liste.Add(m7);
            liste.Add(m8);
            liste.Add(m9);

            return liste;
        }

        static List<Membre> AjouterMembre(List<Membre> liste)
        {
            // 1- on récolte d'abord les informations nécessaires sur le nouveau membre:
            Console.WriteLine("Veuillez entrer le nom de famille du membre que vous souhaitez ajouter.");
            string nom = Console.ReadLine();

            Console.WriteLine("Maintenant, son prénom.");
            string prenom = Console.ReadLine();

            Console.WriteLine("Son sexe : Femme/Homme");
            string sexe = Console.ReadLine();

            Console.WriteLine("Sa date de naissance, sous le format : JJ/MM/AAAA.");
            DateTime naissance = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Son adresse.");
            string adresse = Console.ReadLine();

            Console.WriteLine("Son numéro de téléphone.");
            string tel = Console.ReadLine();

            Console.WriteLine("Pratique-t-il le tennis en compétition ? : true/false");
            bool compet = Convert.ToBoolean(Console.ReadLine());

            double classement;
            if (compet)
            {
                Console.WriteLine("Entrez alors son classement.");
                classement = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                classement = 40.0;
            }

            Console.WriteLine("Cette personne a-t-elle payé sa cotisation ? : true/false");
            bool coti = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Entrez le nombre de matchs auxquels le joueur a déjà participé :");
            int nbM = Convert.ToInt32(Console.ReadLine());

            int nbMG;
            do
            {
                Console.WriteLine("Entrez le nombre de matchs que le membre a déjà gagné : ");
                nbMG = Convert.ToInt32(Console.ReadLine());
            } while (nbMG > nbM);

            // 2- on crée le nouveau membre:
            Membre m = new Membre(nom, prenom, sexe, naissance, adresse, tel, compet, classement, coti,nbM,nbMG);
            Console.WriteLine("Vous souhaitez ajouter le nouveau membre : " + m.ToString());
            Console.WriteLine();

            // 3- on vérifie que le nouveau membre n'est pas déjà dans la liste
            bool present = false;
            Membre identique = null;
            foreach(Membre membre in liste)
            {
                if (membre.Identiques(m))
                {
                    present = true;
                    identique = membre;
                };
            };

            // 4- enfin, on procède en conséquence de cette dernière information ci-dessus
            if (present)
            {
                Console.WriteLine("Ce membre est déjà enregistré dans la liste");
                Console.WriteLine("On ne peut donc pas ajouter ce membre. Pour changer les coordonées de ce membre, veuillez sélectionner l'option appropriée.");
            }
            else
            {
                Console.WriteLine("On ajoute à la liste le nouveau membre");
                liste.Add(m);
                Console.WriteLine("L'ajout du nouveau membre a été validé");
            }

            return liste;
        }

        static List<Membre> SupprimerMembre(List<Membre> liste)
        {
            // 1- on demande à l'utilisateur le membre qu'il souhaite enlever de la liste
            Console.WriteLine("Veuillez entrer le nom de famille du membre que vous souhaitez supprimer.");
            string nom = Console.ReadLine();

            Console.WriteLine("Maintenant, son prénom.");
            string prenom = Console.ReadLine();
;

            // 2- on repère le membre en question
            Membre membre = Trouver(liste, nom, prenom);

            // 3- on vérifie que la liste contient cette personne et on procède en conséquences
            if (membre.Contient(liste))
            {
                //on procède à la suppression
                Console.WriteLine("Vous souhaitez supprimer le membre : " + membre.ToString());
                liste.Remove(membre);
                Console.WriteLine("La suppression a été validé.");
            }
            else
            {
                //la liste ne contient pas ce membre
                Console.WriteLine("La liste ne contient pas ce membre. Aucune suppression n'a pu être effectuée.");
            }

            return liste;
        }

        //Va permettre de trouver le membre dont on veut changer l'adresse,
        //le numéro 
        //et vérifier s'il a payé sa cotisation
        static Membre Trouver(List<Membre> liste)
        {
            Membre m = null;

            Console.WriteLine("Veuillez entrer le nom de famille du membre que vous souhaitez ajouter.");
            string nom = Console.ReadLine();

            Console.WriteLine("Maintenant, son prénom.");
            string prenom = Console.ReadLine();

            foreach(Membre membre in liste)
            {
                if(membre.Nom==nom && membre.Prenom == prenom)
                {
                    m = membre;
                }
            }

            return m;
        }

        static Membre Trouver(List<Membre> liste, string nom, string prenom)
        {
            Membre m = null;
            foreach(Membre membre in liste)
            {
                if(nom==membre.Nom && prenom == membre.Prenom)
                {
                    m = membre;
                }
            }

            return m;
        }

        #region Tris
        //Tris
        static void TriAlpha(List<Membre> liste)
        {
            List<Membre> listeTriee = liste.OrderBy(x => x.Nom).ToList();
            Affichage(listeTriee);
        }

        static void TriClassement(List<Membre> liste)
        {
            List<Membre> listeTriee = liste.OrderBy(x => x.Classement).ToList();
            Affichage(listeTriee);
        }

        static void TriSexe(List<Membre> liste)
        {
            Console.WriteLine("Voulez-vous afficher:\n1-les femmes,\n2-les hommes,\n3-tous les afficher mais groupés");
            Console.WriteLine("Si vous souhaitez abandonner, entrez 0.");
            int numero = Convert.ToInt32(Console.ReadLine());
            while (numero != 0 && numero != 1 && numero != 2 && numero != 3)
            {
                Console.WriteLine("Vous n'avez pas entré un numéro reconnaissable, veuillez recommencer.");
            }

            //On affiche seulement les femmes;
            if (numero == 1)
            {
                Console.WriteLine(" \nVoici les femmes, membres du club :");
                foreach (Membre m in liste)
                {
                    if (m.Sexe == "Femme")
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
            }

            //On affiche seulement les hommes;
            if (numero == 2)
            {
                Console.WriteLine(" \nVoici les hommes, membres du club :");
                foreach (Membre m in liste)
                {
                    if (m.Sexe == "Homme")
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
            }

            //On regroupe;
            if (numero == 3)
            {
                List<Membre> listeTriee = liste.OrderBy(x => x.Sexe).ToList();
                Affichage(listeTriee);
            }
        }


        static void TriLoisir(List<Membre> liste)
        {
            Console.WriteLine("Voulez-vous afficher les membres : \n1- Uniquement les membres qui pratiquent pour le loisir \n2- Les membres qui pratiquent en compétition \n3- Tous les membres, par groupe \nVeuillez entrer le chiffres correspondant à votre choix.");
            Console.WriteLine("Si vous souhaitez abandonner, entrez 0.");
            int numero = Convert.ToInt32(Console.ReadLine());
            while (numero != 0 && numero != 1 && numero != 2 && numero != 3)
            {
                Console.WriteLine("Vous n'avez pas entré un numéro reconnaissable, veuillez recommencer.");
            }

            if (numero == 1)
            {
                Console.WriteLine(" \nVoici les membres qui jouent en loisir :");
                foreach (Membre m in liste)
                {
                    if (!m.Competition)
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
            }

            if (numero == 2)
            {
                Console.WriteLine(" \nVoici les membres qui jouent en compétition :");
                foreach (Membre m in liste)
                {
                    if (m.Competition)
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
            }

            if (numero == 3)
            {
                List<Membre> listeTriee = liste.OrderBy(x => x.Competition).ToList();
                Affichage(listeTriee);
            }

        }

        static void TriCoti(List<Membre> liste)
        {
            Console.WriteLine("Que souhaitez-vous savoir ?\n1-les membres qui ont payé leur cotisation,\n2-les membres qui n'ont pas payé leur cotisation");
            Console.WriteLine("3-avoir toutes les informations regroupées,\nSi vous souhaitez abandonner, entrez 0.");
            int numero = Convert.ToInt32(Console.ReadLine());
            while (numero != 0 && numero != 1 && numero != 2 && numero != 3)
            {
                Console.WriteLine("Vous n'avez pas entré un numéro reconnaissable, veuillez recommencer.");
            }

            if (numero == 1)
            {
                Console.WriteLine(" \nVoici les membres qui ont payé leur cotisation :");
                foreach(Membre m in liste)
                {
                    if (m.Cotisation)
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
            }

            if (numero == 2)
            {
                Console.WriteLine(" \nVoici les membres qu'il faut relancer pour la cotisation :");
                foreach (Membre m in liste)
                {
                    if (!m.Cotisation)
                    {
                        Console.WriteLine(m.ToString());
                    }
                }
            }

            if (numero == 3)
            {
                List<Membre> listeTriee = liste.OrderBy(x => x.Cotisation).ToList();
                Affichage(listeTriee);
            }

        }
        #endregion


        static void Affichage(List<Membre> liste)
        {
            foreach (Membre m in liste)
            {
                Console.WriteLine(m.ToString());
            }
        }

        #endregion


        #region Module Personnel

        //On crée une base pour la liste de membres du personnel :
        static List<Personnel> Init_Personnel()
        {
            List<Personnel> liste = new List<Personnel>();

            Personnel p1 = new Personnel("Petit", "Thierry", "Homme", new DateTime(1966, 05, 17), "9 rue des Piverts", "0697948513", false, 40.0, true, 0, 0, false, false, "RB45795", new DateTime(1999, 01, 15), 4500.0);
            Personnel p2 = new Personnel("Rodrigues", "Carolina", "femme", new DateTime(1997, 03, 29), "45 allée des Abeilles", "0648579103", true, 16.5, true, 45, 38, false, true, "BT485691", new DateTime(2003, 08, 14), 2100.0);
            Personnel p3 = new Personnel("Bart", "Pierre", "Homme", new DateTime(1988, 02, 09), "75 Grands Boulevards", "0754558110", true, 20.0, false, 31, 24, false, true, "PG48561", new DateTime(2004, 09, 16), 2400.0);

            liste.Add(p1);
            liste.Add(p2);
            liste.Add(p3);

            return liste;
        }

        static List<Personnel> AjouterPersonnel(List<Personnel> liste)
        {
            // 1- on récolte d'abord les informations nécessaires sur le nouveau membre:
            Console.WriteLine("Veuillez saisir votre nom ");
            string nomp = Console.ReadLine();

            Console.WriteLine("Veuillez saisir votre prénom ");
            string prenomp = Console.ReadLine();

            Console.WriteLine("Etre vous un homme ou un femme ? Femme/Homme");
            string sexep = Console.ReadLine();

            Console.WriteLine("Sa date de naissance, sous le format : JJ/MM/AAAA.");
            DateTime datep = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Veuillez saisir votre adresse");
            string adressep = Console.ReadLine();

            Console.WriteLine("Entrer votre numero de téléphone");
            string nump = Console.ReadLine();

            Console.WriteLine("Jouez-vous en compétition ? True/False ");
            bool competp = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Veuillez donner votre classement (si vous êtes un entranieur salarié qui fait de la compétition), si vous ne faites pas de competition ou que vous n'êtes pas entraineur, entrez 40.0");
            double classementp = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("A-t-il payé sa cotisation ? True/False ");
            bool cotip = bool.Parse(Console.ReadLine());

            Console.WriteLine("Nombre de match joués : ");
            int nbmatchp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nombre de match gagnés : ");
            int nbmatchgagnesp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Etes-vous un entraineur indépendant ? True/False ");
            bool entraineurIndependantp = Convert.ToBoolean(Console.ReadLine());

            bool entraineurSalariep = false;
            if (!entraineurIndependantp)
            {
                entraineurSalariep = true;
            }

            Console.WriteLine("Entrer le rib :");
            string ribp = Console.ReadLine();

            Console.WriteLine("Veuillez entrer votre date d'entrée dans le club : JJ/MM/AAAA ");
            DateTime entreep = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Salaire : ");
            double salairep = double.Parse(Console.ReadLine());

            //2- On crée le nouveau membre du personnel
            Personnel p = new Personnel(nomp, prenomp, sexep, datep, adressep, nump, competp, classementp, cotip, nbmatchp, nbmatchgagnesp, entraineurIndependantp, entraineurSalariep,  ribp, entreep, salairep);
            Console.WriteLine("Vous souhaitez ajouter le membre du personnel : " + p.ToString());

            //3- On vérifie que le membre du personnel n'est pas déjà présent dans la liste
            bool present = false;

            Personnel identique = null;
            foreach (Personnel personnel in liste)
            {
                if (p.Identiques(personnel))
                {
                    present = true;
                    identique = personnel;
                };
            };


            // 4 - enfin, on procède en conséquence de cette dernière information ci - dessus
            if (present)
            {
                Console.WriteLine("Ce membre du personnel est déjà enregistré dans la liste : " + identique.ToString());
                Console.WriteLine("On ne peut donc pas ajouter ce membre. Pour changer les coordonées de ce membre, veuillez sélectionner l'option appropriée.");
            }
            else
            {
                Console.WriteLine("On ajoute à la liste le nouveau membre : " + p.ToString());
                liste.Add(p);
                Console.WriteLine("L'ajout du nouveau membre a été validé");
            }

            return liste;
        }

        static List<Personnel> SupprimerPersonnel(List<Personnel> liste)
        {
            // 1- on demande à l'utilisateur le membre qu'il souhaite enlever de la liste
            Console.WriteLine("Veuillez entrer le nom de famille du membre du personnel que vous souhaitez supprimer.");
            string nom = Console.ReadLine();

            Console.WriteLine("Maintenant, son prénom.");
            string prenom = Console.ReadLine();

            Console.WriteLine("Son sexe : Femme/Homme");
            string sexe = Console.ReadLine();

            Console.WriteLine("Sa date de naissance, sous le format : JJ/MM/AAAA.");
            DateTime naissance = Convert.ToDateTime(Console.ReadLine());

            // 2- on repère le membre en question
            Personnel personnel = new Personnel(nom, prenom, sexe, naissance);

            // 3- on vérifie que la liste contient cette personne et on procède en conséquences
            if (personnel.Contient(liste))
            {
                //on procède à la suppression
                Console.WriteLine("Vous souhaitez supprimer le membre : " + personnel.ToString());
                liste.Remove(personnel);
                Console.WriteLine("La suppression a été validé.");
            }
            else
            {
                //la liste ne contient pas ce membre
                Console.WriteLine("La liste ne contient pas ce membre. Aucune suppression n'a pu être effectuée.");
            }

            return liste;
        }

        //Va permettre de trouver le membre dont on veut changer l'adresse,
        //le numéro 
        //et vérifier s'il a payé sa cotisation
        static Personnel Trouver(List<Personnel> liste)
        {
            Console.WriteLine("Veuillez entrer le nom de famille du membre que vous souhaitez ajouter.");
            string nom = Console.ReadLine();

            Console.WriteLine("Maintenant, son prénom.");
            string prenom = Console.ReadLine();

            Console.WriteLine("Son sexe : Femme/Homme");
            string sexe = Console.ReadLine();

            Console.WriteLine("Sa date de naissance, sous le format : JJ/MM/AAAA.");
            DateTime naissance = Convert.ToDateTime(Console.ReadLine());

            Personnel p = new Personnel(nom, prenom, sexe, naissance);

            return p;

        }

        static void Affichage(List<Personnel> liste)
        {
            foreach (Personnel p in liste)
            {
                Console.WriteLine(p.ToString());
            }
        }




        #endregion


        #region Module Compétition
        static List<Competition> Init_Compet()
        {
            List<Membre> membres = Init_Membres();
            List<Membre> l1 = new List<Membre>();
            l1.Add(Trouver(membres, "Martin", "Camille"));
            l1.Add(Trouver(membres, "Dujardin", "Emilie"));

            List<Membre> l2 = new List<Membre>();
            l2.Add(Trouver(membres, "Laforge", "Claudine"));
            l2.Add(Trouver(membres, "Fournier", "Pierre"));


            List<Competition> compets = new List<Competition>();
            Competition c1 = new Competition(248, "Paris", "Regional", 25, new DateTime(2020, 04, 16), 5, 2, l1);
            Competition c2 = new Competition(147, "Lyon", "Tout niveau", 35, new DateTime(2020, 09, 01), 2, 2, l2);

            compets.Add(c1);
            compets.Add(c2);

            return compets;
        }

        static Competition CreerCompet(List<Membre> liste)
        {
            Console.WriteLine("Vous souhaitez créer une compétition.\nVeuillez entrez son identifiant : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("La ville dans laquelle elle aura lieu : ");
            string ville = Console.ReadLine();

            Console.WriteLine("Le niveau de la compétition : Départemental/Régional/National/International");
            string niveau = Console.ReadLine();

            Console.WriteLine("L'âge minimal des participants :");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("La date à laquelle aura lieu la compétition : JJ/MM/AAAA");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("La durée de la compétition : ");
            int duree = Convert.ToInt32(Console.ReadLine());

            int nb;
            do
            {
                Console.WriteLine("Le nombre de joueurs qui peuvent participer à cette compétition : ");
                nb = Convert.ToInt32(Console.ReadLine());
            }
            while (nb < 1);

            List<Membre> joueurs = new List<Membre>();
            bool continuer = true;
            while (continuer&&joueurs.Count<nb)
            {
                Console.WriteLine("Ajoutez maintenant les participants.\nEntrez le nom du participant : ");
                string nom = Console.ReadLine();
                Console.WriteLine("Maintenant, entrez le prénom du participant : ");
                string prenom = Console.ReadLine();

                Membre joueur = null;
                foreach(Membre m in liste)
                {
                    if(m.Nom==nom && m.Prenom == prenom)
                    {
                        joueur = m;
                    }
                }

                joueurs.Add(joueur);
                //compet.AjouterParticipant(joueur);

                Console.WriteLine("Voulez-vous continuer ?");
                continuer = Convert.ToBoolean(Console.ReadLine());
            }

            Competition competition = new Competition(id, ville, niveau, age, date, duree, nb, joueurs);
            return competition;
        }




        #endregion


        #region Matrice/Calendrier
        static string[,] Matrice()
        {
            string[,] calendrier = new string[13, 32];

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    calendrier[i, j] = "0 ";
                }
            }

            for (int j = 1; j < 10; j++)
            {
                calendrier[0, j] = Convert.ToString(j + " ");
            }

            for (int j = 10; j < 32; j++)
            {
                calendrier[0, j] = Convert.ToString(j);
            }

            calendrier[1, 0] = "Jan";
            calendrier[2, 0] = "Fev";
            calendrier[3, 0] = "Mar";
            calendrier[4, 0] = "Avr";
            calendrier[5, 0] = "Mai";
            calendrier[6, 0] = "Jun";
            calendrier[7, 0] = "Jul";
            calendrier[8, 0] = "Aou";
            calendrier[9, 0] = "Sep";
            calendrier[10, 0] = "Oct";
            calendrier[11, 0] = "Nov";
            calendrier[12, 0] = "Dec";

            calendrier[0, 0] = "   ";

            calendrier[2, 31] = "x ";
            calendrier[2, 29] = "x ";
            calendrier[2, 30] = "x ";
            calendrier[4, 31] = "x ";
            calendrier[6, 31] = "x ";
            calendrier[9, 31] = "x ";
            calendrier[11, 31] = "x ";

            return calendrier;
        }

        static void Afficher(string[,] matrice)
        {
            int ligne = matrice.GetLength(0);
            int colonne = matrice.GetLength(1);

            for (int i = 0; i < ligne; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    Console.Write(matrice[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static string [,] MAJCalendrier(List<Competition> liste)
        {
            //On ne touche ni à la première ligne, ni à la première colonne car elles portent les informations de repérage à la lecture.

            string[,] calendrier = Matrice();

            foreach(Competition compet in liste)
            {
                List<DateTime> dates = compet.ListeDate();

                foreach(DateTime date in dates)
                {
                    //C'est ici qu'on ajoute la compétition au calendrier
                    string jourS = Convert.ToString(date).Substring(0,2);
                    string moisS = Convert.ToString(date).Substring(3, 2);

                    int jour = Convert.ToInt32(jourS);
                    int mois = Convert.ToInt32(moisS);

                    //On fait apparaître la compétition dans le calendrier
                    int nbCompet = Convert.ToInt32(calendrier[mois, jour]);
                    nbCompet += 1;
                    calendrier[mois, jour] = Convert.ToString(nbCompet);
                }

            }

            Afficher(calendrier);
            return calendrier;
        }

        #endregion


        #region Module Statistique
        static void Etat_Comept(List<Competition> liste)
        {
            int passees = 0;
            int afaire = 0;

            DateTime today = DateTime.Today;
            foreach(Competition compet in liste)
            {
                if (today > compet.Date)
                {
                    passees++;
                }
                else
                {
                    afaire++;
                }
            }

            Console.WriteLine("Voici le nombre de compétitions déjà réalisées : " + passees);
            Console.WriteLine("Voici le nombre de compétitions qui restent à faire : " + afaire);
        }

        static void Resultats_Membres(List<Membre> listeMembre, List<Personnel> listePersonnel)
        {
            Console.WriteLine("Voici les résultats des membres du club non membres du personnel : nom + prénom : matchs joués/gagnés/perdus :");
            foreach(Membre m in listeMembre)
            {
                Console.WriteLine(m.Nom + " " + m.Prenom + " : "+m.NbMatchs + "/" + m.NbMatchsGagnes + "/" + (m.NbMatchs - m.NbMatchsGagnes));
            }

            Console.WriteLine("Voici les résultats des membres du personnel : nom + prénom : matchs joués/gagnés/perdus :");
            foreach(Personnel p in listePersonnel)
            {
                Console.WriteLine(p.Nom + " " + p.Prenom + " : "+p.NbMatchs+"/"+p.NbMatchsGagnes+"/"+(p.NbMatchs-p.NbMatchsGagnes));
            }
        }

        static void Moy_Joueurs_Compet(List<Competition> liste)
        {
            double total = 0;
            foreach(Competition compet in liste)
            {
                total = total + (compet.Participants).Count;
            }

            double moyenne = total / (liste.Count);

            Console.WriteLine("Voici la moyenne du nombre de joueurs du club par compétition : " + moyenne);
        }

        static void Bilan_Annuel_Matchs(List<Membre> listeMembre, List<Personnel> listePersonnel)
        {
            int totalMatchs = 0;
            int totalGagnes = 0;
            foreach(Membre m in listeMembre)
            {
                totalMatchs += m.NbMatchs;
                totalGagnes += m.NbMatchsGagnes;
            }

            foreach(Personnel p in listePersonnel)
            {
                totalMatchs += p.NbMatchs;
                totalGagnes += p.NbMatchsGagnes;
            }

            Console.WriteLine("Cette année, le club a gagné : " + totalGagnes + " matchs, et a perdu " + (totalMatchs - totalGagnes) + " matchs cette saison");
        }

        static void Bilan_Categories(List<Membre> listeMembre, List<Personnel> listePersonnel)
        {
            double nbF = 0.0, nbFG = 0.0;
            double nbH = 0.0, nbHG = 0.0;
            double nbJ = 0.0, nbJG = 0.0;

            foreach(Membre m in listeMembre)
            {
                if(m.Sexe=="Femme" && !m.Junior())
                {
                    nbF += m.NbMatchs;
                    nbFG += m.NbMatchsGagnes;
                }
                if(m.Sexe=="Homme" && !m.Junior())
                {
                    nbH += m.NbMatchs;
                    nbHG += m.NbMatchsGagnes;
                }
                else
                {
                    nbJ += m.NbMatchs;
                    nbJG += m.NbMatchsGagnes;
                }
            }

            foreach(Personnel p in listePersonnel)
            {
                if (p.EntraineurSalarie)
                {
                    if (p.Sexe == "Femme")
                    {
                        nbF += p.NbMatchs;
                        nbFG += p.NbMatchsGagnes;
                    }
                    else
                    {
                        nbH += p.NbMatchs;
                        nbHG += p.NbMatchsGagnes;
                    }
                }
            }



            //On calcule les ratios
            double resultatsF = nbFG / nbF * 100;
            double resultatsH = nbHG / nbH * 100;
            double resultatsJ = nbJG / nbJ * 100;

            Console.WriteLine("Résultats annuels des femmes : " + resultatsF+"% de matchs gagnés.");
            Console.WriteLine("Résultats annuels des hommes : " + resultatsH + "% de matchs gagnés.");
            Console.WriteLine("Résultats annuels des juniors : " + resultatsJ + "% de matchs gagnés.");
        }

        #endregion


        #region Module Stage Junior

        static List<Membre> Init_Juniors(List<Membre> liste)
        {
            List<Membre> nouvelle = new List<Membre>();
            foreach(Membre m in liste)
            {
                if (m.Junior())
                {
                    nouvelle.Add(m);
                }
            }
            return nouvelle;
        }

        static Stage Inscription(List<Membre> liste, Stage stage)
        {
            if (!stage.StageComplet())
            {
                Membre ajouter = Trouver(liste);
                if (ajouter.Junior())
                {
                    stage.ListeMembres.Add(ajouter);
                    Console.WriteLine(ajouter.Nom + " " + ajouter.Prenom + " a été ajouté à la liste des participants au stage");
                }
                else
                {
                    Console.WriteLine("Impossible d'ajouter ce membre, il n'est pas junior.");
                }
            }
            else
            {
                Console.WriteLine("Le stage est complet, impossible d'ajouter de participants.");
            }

            return stage;
        }


        #endregion


        static List<Entraineur> Init_Entraineus()
        {
            List<Entraineur> liste = new List<Entraineur>();
            Entraineur e1 = new Entraineur("Gras", "Pierre", new DateTime(1966, 02, 17), 'H', "0612154795", "7 rue des Pins", "16.0", true, 50, 34, false, true);
            Entraineur e2 = new Entraineur("Tirou", "Celine", new DateTime(1994, 06, 04), 'F', "0648957684", "84 avenue des Lacs", "31.5", true, 37, 12, false, true);

            liste.Add(e1);
            liste.Add(e2);

            return liste;
        }


        static Entraineur Trouver(List<Entraineur> liste, string nom, string prenom)
        {
            Entraineur m = null;
            foreach (Entraineur membre in liste)
            {
                if (nom == membre.Nom && prenom == membre.Prenom)
                {
                    m = membre;
                }
            }

            return m;
        }

        static StageJunior Init_Stage(List<Membre> juniors, List<Entraineur> entraineurs)
        {
            StageJunior stage = null;
            List<Membre> l1 = new List<Membre>();
            List<Entraineur> l2 = new List<Entraineur>();

            l1.Add(Trouver(juniors, "Martin", "Eric"));
            l1.Add(Trouver(juniors, "Fernandez", "Elia"));

            l2.Add(Trouver(entraineurs, "Gras", "Pierre"));


            return stage;
        }

        Queue<Membre> fileAttente = new Queue<Membre>();
        Membre m = new Membre("Serta", "Vera", new DateTime(2008, 08, 16), 'F', "0648597612", "46 rue des Moulins", "NC", false, 12, 6);
        fileAttente.Enqueue(m);


        public static void ClubTennis() //ulm quand fini code
        {
            List<Membre> listemembres = Init_Membres();
            List<Membre> listeJuniors = Init_Juniors(listemembres); //Pour le module Stage Junior liste d'attenteeeeeeeeeeeeeee
            List<Personnel> listepersonnel = Init_Personnel();
            List<Competition> listecompetitions = Init_Compet();

            int choix1 = 0;

            while (choix1 != 6)
            {
                Console.WriteLine("Bienvenue ! \n\n");
                Console.WriteLine("Veuillez choisir un module : \n");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1 : Module Membre ");
                Console.WriteLine("2 : Module Personnel ");
                Console.WriteLine("3 : Module Compétition "); //Creer une liste des tournois ou l'avoir quelque part               
                Console.WriteLine("4 : Module Statistiques ");
                Console.WriteLine("5 : Module Stage Junior");
                Console.WriteLine("6 : Fin du programme");
                Console.WriteLine("----------------------------\n");
                Console.WriteLine("Quel est votre choix >>");

                choix1 = int.Parse(Console.ReadLine());

                switch (choix1)
                {
                    case 1:
                        #region Module Membre

                        int choix2 = 0;

                        while (choix2 != 12)
                        {
                            Console.WriteLine("Bienvenue dans le Module Membre \n\n");
                            Console.WriteLine("-------------------------------\n");
                            Console.WriteLine("Veuillez choisir une option : \n");
                            Console.WriteLine("01 : Insérer un nouveau membre");
                            Console.WriteLine("02 : Supprimmer un membre");
                            Console.WriteLine("03 : Modifier l'adresse d'un membre");
                            Console.WriteLine("04 : Modifier le numéro d'un membre");
                            Console.WriteLine("05 : Vérifier que le membre a payé son adhésion");
                            Console.WriteLine("06 : Classement par loisir/compétition");
                            Console.WriteLine("07 : Classement par ordre alphabétique");
                            Console.WriteLine("08 : Classement par classement au tennis");
                            Console.WriteLine("09 : Classement par sexe");
                            Console.WriteLine("10 : Classement par validation du paiement de l'adhésion");
                            Console.WriteLine("11 : Afficher la liste des membres");
                            Console.WriteLine("12 : Sortie du Module Membre");

                            choix2 = int.Parse(Console.ReadLine());

                            switch (choix2)
                            {
                                case 1:
                                    #region Insérer un nouveau membre
                                    listemembres = AjouterMembre(listemembres);
                                    #endregion 
                                    break;

                                case 2:
                                    #region Supprimer un membre
                                    listemembres = SupprimerMembre(listemembres);
                                    #endregion 
                                    break;

                                case 3:
                                    #region Modifier l'adresse d'un membre
                                    //Recherche du membre dont on veut modifier l'adresse :
                                    Membre membre1 = Trouver(listemembres);
                                    membre1.ModifierAdresse();

                                    Console.WriteLine("------------------------\n\n");
                                    #endregion 
                                    break;

                                case 4:
                                    #region Modifier le numéro d'un membre
                                    //Recherche du membre :
                                    Membre membre2 = Trouver(listemembres);
                                    membre2.ModifierTel();

                                    Console.WriteLine("-----------------------\n\n");
                                    #endregion 
                                    break;

                                case 5:
                                    #region Vérifier que le membre a payé son adhésion
                                    //Recherche du membre :
                                    Membre membre3 = Trouver(listemembres);

                                    //On vérifie qu'il a payé son adhésion :
                                    Console.WriteLine("Le membre a-t-il payé son adhésion ?");
                                    membre3.VerifCoti();
                                    Console.WriteLine("------------------------------------\n\n");
                                    #endregion 
                                    break;

                                case 6:
                                    #region Classement par loisir/compétition
                                    TriLoisir(listemembres);
                                    Console.WriteLine("Classement affiché");
                                    Console.WriteLine("------------------\n\n");
                                    #endregion
                                    break;

                                case 7:
                                    #region Classement par ordre alphabétique
                                    TriAlpha(listemembres);
                                    Console.WriteLine("Classement affiché");
                                    Console.WriteLine("------------------\n\n");
                                    #endregion 
                                    break;

                                case 8:
                                    #region Classement par classement au tennis
                                    TriClassement(listemembres);
                                    Console.WriteLine("Classement affiché");
                                    Console.WriteLine("------------------\n\n");
                                    #endregion
                                    break;

                                case 9:
                                    #region Classement par sexe
                                    TriSexe(listemembres);
                                    Console.WriteLine("Classement affiché");
                                    Console.WriteLine("------------------\n\n");
                                    #endregion
                                    break;

                                case 10:
                                    #region Classement par validation du paiement de l'adhésion
                                    TriCoti(listemembres);
                                    Console.WriteLine("Classement affiché");
                                    Console.WriteLine("------------------\n\n");
                                    #endregion
                                    break;

                                case 11:
                                    #region Afficher la liste des membres
                                    Affichage(listemembres);
                                    Console.WriteLine("Liste des membres affichée");
                                    Console.WriteLine("--------------------------\n\n");
                                    #endregion
                                    break;

                                case 12:
                                    #region Fin
                                    Console.WriteLine("Fin du Module Membre\n");
                                    Console.WriteLine("Retour au menu principal");
                                    Console.WriteLine("------------------------\n\n\n");
                                    #endregion 
                                    break;
                            }

                        }
                        #endregion 
                        break;

                    case 2:
                        #region Module Personnel

                        int choix3 = 0;

                        while (choix3 != 6)
                        {
                            Console.WriteLine("Bienvenue dans le Module Personnel \n\n\n");
                            Console.WriteLine("----------------------------------\n");
                            Console.WriteLine("Veuillez choisir une option : \n");
                            Console.WriteLine("1 : Insérer une nouvelle personne dans la liste du personnel");
                            Console.WriteLine("2 : Supprimmer une personne de la liste du personnel");
                            Console.WriteLine("3 : Modifier l'adresse d'un membre du personnel");
                            Console.WriteLine("4 : Modifier le numéro d'un membre du personnel");
                            Console.WriteLine("5 : Afficher la liste des membres du personnel");
                            Console.WriteLine("6 : Sortie du Module Personnel");

                            choix3 = int.Parse(Console.ReadLine());

                            switch (choix3)
                            {
                                case 1:
                                    #region Insérer une nouvelle personne dans la liste du personnel
                                    listepersonnel = AjouterPersonnel(listepersonnel);
                                    #endregion 
                                    break;

                                case 2:
                                    #region Supprimmer une personne de la liste du personnel
                                    listepersonnel = SupprimerPersonnel(listepersonnel);
                                    Console.WriteLine("-------------------\n\n\n");
                                    #endregion
                                    break;

                                case 3:
                                    #region Modifier l'adresse d'un membre du personnel
                                    Personnel p1 = Trouver(listepersonnel);
                                    p1.ModifierAdressePersonnel();

                                    Console.WriteLine("-------------------\n\n\n");
                                    #endregion 
                                    break;

                                case 4:
                                    #region Modifier le numéro d'un membre du personnel
                                    Personnel p2 = Trouver(listepersonnel);
                                    p2.ModifierTelPersonnel();

                                    Console.WriteLine("-----------------\n\n\n");
                                    #endregion
                                    break;

                                case 5:
                                    #region Afficher la liste des membres du personnel
                                    Affichage(listepersonnel);
                                    #endregion
                                    break;

                                case 6:
                                    #region Fin
                                    Console.WriteLine("Sortie du Module Personnel\n");
                                    Console.WriteLine("Retour au menu principal");
                                    Console.WriteLine("--------------------------\n\n");
                                    #endregion 
                                    break;
                            }
                        }
                        #endregion 
                        break;

                    case 3:
                        #region Module Compétition
                        #endregion
                        break;

                    case 4:
                        #region Module Statistiques
                        int choix5 = 0;

                        while (choix5 != 6)
                        {
                            Console.WriteLine("Bienvenue dans le Module Statistiques \n\n\n");
                            Console.WriteLine("--------------------------------------\n");
                            Console.WriteLine("Veuillez choisir une option : \n");
                            Console.WriteLine("1 : Afficher le nombre de compétitions réalisées et restantes à faire");
                            Console.WriteLine("2 : Afficher par membre les nombres de matchs joués, gagnés et perdus");
                            Console.WriteLine("3 : Afficher le nombre moyen de joueurs du club par compétition");
                            Console.WriteLine("4 : Afficher pour le club par année le nombre de matchs gagnés ou perdus");
                            Console.WriteLine("5 : Afficher les résultats par catégories (hommes, femmes, juniors)");
                            Console.WriteLine("6 : Sortie du Module Statistiques\n");
                            choix5 = int.Parse(Console.ReadLine());

                            switch (choix5)
                            {
                                case 1:
                                    #region Afficher le nombre de compétitions réalisées et restantes à faire
                                    Etat_Comept(listecompetitions);
                                    #endregion 
                                    break;

                                case 2:
                                    #region Afficher par membre les nombres de matchs joués, gagnés et perdus
                                    Resultats_Membres(listemembres, listepersonnel);
                                    #endregion 
                                    break;

                                case 3:
                                    #region Afficher le nombre moyen de joueurs du club par compétition
                                    Moy_Joueurs_Compet(listecompetitions);
                                    #endregion 
                                    break;

                                case 4:
                                    #region Afficher pour le club par année le nombre de matchs gagnés ou perdus
                                    Bilan_Annuel_Matchs(listemembres, listepersonnel);
                                    #endregion 
                                    break;

                                case 5:
                                    #region Afficher les résultats par catégories (hommes, femmes, juniors)
                                    Bilan_Categories(listemembres, listepersonnel);
                                    #endregion 
                                    break;

                                case 6:
                                    #region Fin
                                    Console.WriteLine("Fin du Module Statistiques \n");
                                    Console.WriteLine("Retour au menu principal");
                                    Console.WriteLine("------------------------\n\n\n");
                                    #endregion
                                    break;

                            }
                        }
                        #endregion
                        break;

                    case 5:
                        #region Module Stage Junior
                        int choix6 = 0;

                        while (choix6 != 6)
                        {
                            Console.WriteLine("Veuillez choisir une option : ");
                            Console.WriteLine("1 : Inscription au stage");
                            Console.WriteLine("2 : Suppression de l'inscription");
                            Console.WriteLine("3 : Ajouter un entraineur pour faire le stage");
                            Console.WriteLine("5 : Supprimer un entraineur pour le stage");
                            Console.WriteLine("6 : Afficher liste d'attente");
                            Console.WriteLine("7 : Fin du Module Stage \n Retour au menu principal");

                            choix6 = int.Parse(Console.ReadLine());

                            switch (choix6)
                            {
                                case 1:
                                    #region Inscription au stage
                                    //Inscription(listeJuniors);
                                    #endregion 
                                    break;

                                case 2:
                                    #region Suppression de l'inscription
                                    #endregion 
                                    break;

                            }


                        }

                        #endregion 
                        break;

                    case 6:
                        #region Fin du programme
                        #endregion 
                        break;

                }


            }

        }

        static void Main(string[] args)
        {
            ClubTennis();

            Console.ReadKey();
        }
    }
}
