using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

/////////////////////////////////
// Dll pour la gestion langage //
/////////////////////////////////

namespace Gestion_Langage
{
    public class Langage
    {
        // Declaration des variables
        private string Code_Langage = "";

        //private string Trace = "Non défini";

        protected class Traduction
        {
            public string Phrase_a_traduire;
            public string Phrase_traduite;
        }

        List<Traduction> Tableau_Traduction;
        
        // Declaration des fonctions
        public bool set_Langage(string Lang_a_charger)
        {
            Code_Langage = Lang_a_charger;
            Tableau_Traduction = new List<Traduction>();
            // Creation du fichier XML
            String CheminAccesLangageXml = ".\\Ressources\\Langages\\" + Code_Langage + ".xml"; 
            XmlDocument FichierXMLangage = new XmlDocument();
            // On essaye d'ouvrir le fichier XML
            try
            {
                FichierXMLangage.Load(CheminAccesLangageXml);
                //Trace = "OK";
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
            }
            // si le fichier n'existe pas on retourne une erreur
            catch
            {
                //Trace = "NOK";
                return false;
            }
            return true;
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
    }
}
