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
        // Declaration des Int32
        public Int32 Caracteristique_Int32_01 { get; set; }
        public Int32 Caracteristique_Int32_02 { get; set; }
        public Int32 Caracteristique_Int32_03 { get; set; }
        public Int32 Caracteristique_Int32_04 { get; set; }
        public Int32 Caracteristique_Int32_05 { get; set; }
        public Int32 Caracteristique_Int32_06 { get; set; }
        public Int32 Caracteristique_Int32_07 { get; set; }
        public Int32 Caracteristique_Int32_08 { get; set; }
        public Int32 Caracteristique_Int32_09 { get; set; }
        public Int32 Caracteristique_Int32_10 { get; set; }
        public Int32 Caracteristique_Int32_11 { get; set; }
        public Int32 Caracteristique_Int32_12 { get; set; }
        public Int32 Caracteristique_Int32_13 { get; set; }
        public Int32 Caracteristique_Int32_14 { get; set; }
        public Int32 Caracteristique_Int32_15 { get; set; }
        public Int32 Caracteristique_Int32_16 { get; set; }
        public Int32 Caracteristique_Int32_17 { get; set; }
        public Int32 Caracteristique_Int32_18 { get; set; }
        public Int32 Caracteristique_Int32_19 { get; set; }
        public Int32 Caracteristique_Int32_20 { get; set; }

        // Declaration des string
        public String Caracteristique_String_01 { get; set; }
        public String Caracteristique_String_02 { get; set; }
        public String Caracteristique_String_03 { get; set; }
        public String Caracteristique_String_04 { get; set; }
        public String Caracteristique_String_05 { get; set; }
        public String Caracteristique_String_06 { get; set; }
        public String Caracteristique_String_07 { get; set; }
        public String Caracteristique_String_08 { get; set; }
        public String Caracteristique_String_09 { get; set; }
        public String Caracteristique_String_10 { get; set; }
        public String Caracteristique_String_11 { get; set; }
        public String Caracteristique_String_12 { get; set; }
        public String Caracteristique_String_13 { get; set; }
        public String Caracteristique_String_14 { get; set; }
        public String Caracteristique_String_15 { get; set; }

        // Declaration des bool
        public bool Caracteristique_Bool_01 { get; set; }
        public bool Caracteristique_Bool_02 { get; set; }
        public bool Caracteristique_Bool_03 { get; set; }
        public bool Caracteristique_Bool_04 { get; set; }
        public bool Caracteristique_Bool_05 { get; set; }
        public bool Caracteristique_Bool_06 { get; set; }
        public bool Caracteristique_Bool_07 { get; set; }
        public bool Caracteristique_Bool_08 { get; set; }
        public bool Caracteristique_Bool_09 { get; set; }
        public bool Caracteristique_Bool_10 { get; set; }
      

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
