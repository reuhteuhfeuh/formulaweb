using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Traceur;
using System.IO;

/////////////////////////////////
// Dll pour la gestion langage //
/////////////////////////////////

namespace Gestion_Langage
{
    public class Langage
    {
        // Declaration des variables
        public Traceur.Traceur tracelangage { get; set; }
        private string Code_Langage = "";
        String CheminAccesLangageXml = ".\\Ressources\\Langages\\";
        List<string> langage_dispo = new List<string>();
        List<string> code_langage_dispo = new List<string>();
        public int langage_en_cours { get; set; }
        int nombre_langage { get; set; }
        List<Traduction> Tableau_Traduction = new List<Traduction>();


        protected class Traduction
        {
            public string Phrase_a_traduire;
            public string Phrase_traduite;
        }

        public void listing_langage()
        {
            string[] tmp_langage_dispo;
            tmp_langage_dispo = Directory.GetFiles(CheminAccesLangageXml);
            tracelangage.Trace("Info", tmp_langage_dispo[1]);
            //jeux_dispo = GetDirectories(
            foreach (string fichier_langage in tmp_langage_dispo)
            {
                // Aller lire le petit fichier XMl de description et récupérer le nom du jeu

                XmlDocument FichierXmlDesciption = new XmlDocument();
                try
                {
                    FichierXmlDesciption.Load(fichier_langage);
                    foreach (XmlNode lectureXML_Racine in FichierXmlDesciption.ChildNodes)
                    {
                        if (lectureXML_Racine.Name == "Langage")
                        {
                            foreach (XmlNode lectureXML_Description in FichierXmlDesciption.DocumentElement.ChildNodes)
                            {
                                if (lectureXML_Description.Name == "Code_Langage")
                                {
                                    // on garde la liste et l'adressage par tableau en attendant le bon choix
                                    code_langage_dispo.Add(lectureXML_Description.InnerText);
                                    //liste_jeux[jeu_en_cours] = lectureXML_Description.InnerText;
                                }
                                if (lectureXML_Description.Name == "Description_Langage")
                                {
                                    // on garde la liste et l'adressage par tableau en attendant le bon choix
                                    langage_dispo.Add(lectureXML_Description.InnerText);
                                    nombre_langage++;
                                    //liste_jeux[jeu_en_cours] = lectureXML_Description.InnerText;
                                }

                            }
                        }
                    }
                    tracelangage.Trace("Info", "fin du traitement de " + fichier_langage);
                }
                catch
                {
                    tracelangage.Trace("Erreur","Anoamalie sur le traitement de "+fichier_langage);
                }
            }
        }
        
        private bool chargement_xml(string acces)
        {
            XmlDocument FichierXMLangage = new XmlDocument();
            FichierXMLangage.Load(acces);
            Tableau_Traduction = new List<Traduction>();
            try
            {
                foreach (XmlNode lectureXML_Racine in FichierXMLangage.ChildNodes)
                {
                    // on parcout le noeud Langage
                    if (lectureXML_Racine.Name == "Langage")
                    {
                        foreach (XmlNode lectureXML_Niveau_1 in FichierXMLangage.DocumentElement.ChildNodes)
                        {
                            // on parcout le fichier XML
                            Traduction trad = new Traduction(); trad.Phrase_a_traduire = lectureXML_Niveau_1.Name; trad.Phrase_traduite = lectureXML_Niveau_1.InnerText; Tableau_Traduction.Add(trad);
                        }
                    }
                }
                return true;
            }
            catch
            {
                tracelangage.Trace("Info", "chargement_xml, anomalie au chargement de " + acces);
                return false;
            }
        }
        public string set_Langage()
        {
            return set_Langage(code_langage_dispo[langage_en_cours]);
        }

        // Declaration des fonctions
        public string set_Langage(string Lang_a_charger)
        {
            Code_Langage = Lang_a_charger;
            // Creation du fichier XML
            string CheminAccesLangageXmllocal = CheminAccesLangageXml + Code_Langage + ".xml"; 
            // On essaye d'ouvrir le fichier XML
            try
            {
                chargement_xml(CheminAccesLangageXmllocal);
                langage_en_cours = code_langage_dispo.FindIndex(lang => lang == Code_Langage);
                //tracelangage.Trace("Info", "Id du langage en cours : " + langage_en_cours);
                
            }
            // si le fichier n'existe pas on retourne une erreur
            catch
            {
                if (Lang_a_charger == "FR")
                {
                    tracelangage.Trace("ERREUR", "Anomalie importante sur le fichier FR standard");
                    return "INCONNU";
                }
                else
                {
                    tracelangage.Trace("ERREUR", "Impossible de charger le langage " + Lang_a_charger + ", utilisation FR");
                    try
                    {
                        return set_Langage("FR");
                        //return Lang_a_charger;
                    }
                    catch
                    {
                        tracelangage.Trace("ERREUR", "Impossible de charger le langage FR par défaut");
                        return "INCONNU";
                    }
                }
            }
            return Lang_a_charger;
        }

        // Fonction de traduction d'une chaine de caractere presente dans le ficheir XML
        public string Get_Traduction(string Atraduire)
        {
            Traduction traduction = Tableau_Traduction.Find(delegate(Traduction Recherche_trad)
            {
                return (Recherche_trad.Phrase_a_traduire == Atraduire);
            }) ;

            if (traduction != null)
            {
                return traduction.Phrase_traduite;
            }
            else
            {
                return "A traduire";
            }
        }

        public string Get_libelle_langage(int pos_jeu)
        {
            //return liste_jeux[pos_jeu];
            return langage_dispo.ElementAt(pos_jeu);
        }


        // A regrouper les deux get par un delegate (et oui c'est comme ca qu'on apprend !)
        public string Get_libelle_langage_suivant()
        {
            //if (nombre_jeu == 0) return "Aucun jeu" ;
            langage_en_cours++;
            if (langage_en_cours > nombre_langage - 1) langage_en_cours = 0;
            return Get_libelle_langage(langage_en_cours);
        }

        public string Get_libelle_langage_precedent()
        {
            //if (nombre_jeu == 0) return "Aucun jeu" ;
            langage_en_cours--;
            if (langage_en_cours < 0) langage_en_cours = nombre_langage - 1;
            return Get_libelle_langage(langage_en_cours);
        }
    }
}
