using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Traceur;
using System.IO;


namespace Gestion_Regles
{
    public class Regles
    {


        public struct description_jeu
        {
            public string jeu_dispo;        // libelle du jeu
            public string jeu_dispo_code;   // code du jeu
            public bool jeu_menu_option;    // menu optionnel ou non
        }

        Traceur.Traceur Trace_Regles;
        string chemin_acces_ressources = ".\\Ressources\\Jeux\\" ;

        // liste structure des jeux dispo
        public List <description_jeu> liste_jeu;

        int jeu_en_cours { get; set; }
        int nombre_jeu { get; set; }

        string code_jeux_choisi { get; set; }

        // Declaration des variables communes
        public Int32 Nombre_Joueurs { get; set; }

        // Declaration des variables standards

        // Un dictionnaire par typologie.
        // Dictionnaire Int32
        Dictionary<String, Int32> Caracteristique_Int32 = new Dictionary<String, Int32>();
        // Dictionnaire String
        Dictionary<String, String> Caracteristique_String = new Dictionary<String, String>();
        // Dictionnaire Bool
        Dictionary<String, Boolean> Caracteristique_Bool = new Dictionary<String, Boolean>();

        public bool Injection_donnees(String selection, String variable, String valeur)
        {

            return true;
        }
        // A créer fonction delegate qui declenche Stockage
        


        

      

        public void Initialisation( Traceur.Traceur tra)
        {
            Trace_Regles = tra;
            Trace_Regles.Trace("Info", "initialisation Règles de jeu");
            jeu_en_cours = 0;
            liste_jeu = new List<description_jeu>();

        }

        public void Listing_Jeux()
        {
            string[] tmp_jeux_dispo;
            tmp_jeux_dispo = Directory.GetDirectories(chemin_acces_ressources);
            foreach (string jeu in tmp_jeux_dispo)
            {
                // Aller lire le petit fichier XMl de description et récupérer le nom du jeu
                XmlDocument FichierXmlDesciption = new XmlDocument();
                try
                {
                    FichierXmlDesciption.Load(jeu + "\\Description.xml");
                    foreach (XmlNode lectureXML_Racine in FichierXmlDesciption.ChildNodes)
                    {
                        if (lectureXML_Racine.Name == "Description")
                        {
                            string libelle = "";
                            string code = "";
                            bool option = false;

                            foreach (XmlNode lectureXML_Description in FichierXmlDesciption.DocumentElement.ChildNodes)
                            {
                                if (lectureXML_Description.Name == "libelle")
                                {
                                    libelle = lectureXML_Description.InnerText;
                                }
                                if (lectureXML_Description.Name == "code_jeu")
                                {
                                    code = lectureXML_Description.InnerText;
                                }
                                if (lectureXML_Description.Name == "menu_option")
                                {
                                    if (lectureXML_Description.InnerText == "true")
                                        option = true;
                                }
                            }

                            if (libelle == string.Empty || code == string.Empty)
                            {
                                Trace_Regles.Trace("INFO", jeu + " fichier incomplet données manquantes");
                            }
                            else
                            {
                                liste_jeu.Add(new description_jeu() { jeu_dispo = libelle, jeu_dispo_code = code, jeu_menu_option = option });
                                nombre_jeu++;
                            }
                        }
                    }
                }
                catch
                {
                    Trace_Regles.Trace("ERREUR", "Impossible d'ouvrir le xml " + jeu + "\\Description.xml");
                    Trace_Regles.Trace("INFO", "Le jeu est retiré de la liste");
                    //Trace_Regles.Trace("ERREUR", e.ToString());
                }
            }
            //nombre_jeu = jeu_en_cours;
        }

        public string Get_libelle_jeu(int pos_jeu)
        {
            return liste_jeu.ElementAt(pos_jeu).jeu_dispo;
        }


        // A regrouper les deux get par un delegate (et oui c'est comme ca qu'on apprend !)
        public string Get_libelle_jeu_suivant()
        {
            jeu_en_cours++;
            if (jeu_en_cours > nombre_jeu - 1) jeu_en_cours = 0;
            return Get_libelle_jeu(jeu_en_cours);
        }

        public string Get_libelle_jeu_precedent()
        {
            jeu_en_cours--;
            if (jeu_en_cours < 0 ) jeu_en_cours = nombre_jeu-1;
            return Get_libelle_jeu(jeu_en_cours);
        }

        public string Get_code_jeu()
        {
            return liste_jeu.ElementAt(jeu_en_cours).jeu_dispo_code;
        }

        public bool Get_Options_Menu()
        {
            return liste_jeu.ElementAt(jeu_en_cours).jeu_menu_option;
        }

    }
}
