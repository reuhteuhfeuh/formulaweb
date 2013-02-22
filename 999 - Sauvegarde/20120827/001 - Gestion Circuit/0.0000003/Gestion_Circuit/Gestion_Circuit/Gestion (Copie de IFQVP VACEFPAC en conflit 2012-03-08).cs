using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

/////////////////////////////////
// Dll pour la gestion circuit //
/////////////////////////////////

namespace Gestion_Circuit
{
    public class Gestion
    {
        // Variables utilisées pour versionning
        private string Version = "0.0.0.3";

        // Declaration des variables
        private string Chemin_Access;
        private string Nom_Fichier_XML;
        private string Nom_Circuit;
        private string Nom_Image_Circuit;
        private string Chemin_Access_Image;
        private Int32 Nombre_Case;
        private Case[] Case_Circuit;
        //private bool Mode_debug;
        //private string Mode_debug_level;

        //----------------------//
        // Accesseurs publiques //
        //----------------------//

        ////////////////////
        // Accesseurs SET //
        ////////////////////

        public void Set_Chemin_Acces(string CheminAcces)
        {
            Chemin_Access = CheminAcces;
        }

        public void Set_Nom_Fichier_XML(string FichierXML)
        {
            Nom_Fichier_XML = FichierXML;
        }

        ////////////////////
        // Accesseurs GET //
        ////////////////////

        public string Get_Nom_Circuit()
        {
            return Nom_Circuit;
        }

        public string Get_Image_Circuit()
        {
            return Chemin_Access_Image;
        }

        public string Get_Version_Gestion()
        {
            return Version;
        }

        public Int32 Get_Classement(Int32 Numero_Case)
        {
            return Case_Circuit[Numero_Case].Get_Classement();
        }

        public int Get_NombreCase()
        {
            return Nombre_Case;
        }
        //-----------------------------------//
        // Declaration des fonctions privees //
        //-----------------------------------//

        //-------------------------------------//
        // Declaration des fonctions publiques //
        //-------------------------------------//

        // Lecture_Fichier_XLM
        // Créateur : FC
        // Date création : ??
        // Date dernière modification : 
        // Commentaire  : Fonction destinée à lire un fichier XML et y récupérer 
        //              : toutes les informations nécessaire au bon fonctionnement
        //              : de la gestion
        // Paramètres entrants : NULL
        // Paramètres sortants : NULL
        public void Lecture_Fichier_XML()
        {
            Int32 Numero_Case;
            Int32 Classement_Case;

            XmlDocument FichierXMLCircuit = new XmlDocument();
            FichierXMLCircuit.Load(Chemin_Access + "\\" + Nom_Fichier_XML);
            foreach (XmlNode lectureXML_Racine in FichierXMLCircuit.ChildNodes)
            {
                // on parcout le noeud Circuit_Definition
                if (lectureXML_Racine.Name == "Circuit_Definition")
                {
                    foreach (XmlNode lectureXML_Niveau_1 in FichierXMLCircuit.DocumentElement.ChildNodes)
                    {
                        if (lectureXML_Niveau_1.Name == "Circuit_Nom")
                        {
                            Nom_Circuit = lectureXML_Niveau_1.InnerText;
                        }
                        if (lectureXML_Niveau_1.Name == "Circuit_Graphique")
                        {
                            Nom_Image_Circuit = lectureXML_Niveau_1.InnerText;
                            Chemin_Access_Image = Chemin_Access + lectureXML_Niveau_1.InnerText;
                        }
                        if (lectureXML_Niveau_1.Name == "Circuit_Nombre_Case")
                        {
                            Nombre_Case = Int32.Parse(lectureXML_Niveau_1.InnerText);                            
                        }
                        Case_Circuit = new Case[Nombre_Case];
                        // on parcout le noeud Circuit_Case

                        if (lectureXML_Niveau_1.Name == "Circuit_Case")
                        {
                            Numero_Case = 0;
                            Classement_Case = 0;
                            foreach (XmlNode lectureXML_Case in lectureXML_Niveau_1.ChildNodes)
                            {
                                if (lectureXML_Case.Name == "Case")
                                {
                                    foreach (XmlNode lectureXML_Case_Case in lectureXML_Case.ChildNodes)
                                    {
                                        if (lectureXML_Case_Case.Name == "Case_Numero")
                                        {
                                            Numero_Case = Convert.ToInt32(lectureXML_Case_Case.InnerText);
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Classement")
                                        {
                                            Classement_Case = Convert.ToInt32(lectureXML_Case_Case.InnerText);
                                        }
                                        Case_Circuit[Numero_Case] = new Case();
                                        Case_Circuit[Numero_Case].Construction_Case(Numero_Case, Classement_Case);
                                    }
                                }
                            }                            
                        }
                    }
                }
            }
        }
    }
}

