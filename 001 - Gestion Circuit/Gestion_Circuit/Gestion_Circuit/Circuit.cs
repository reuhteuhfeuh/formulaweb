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
    public class Circuit
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
        private bool Mode_debug = false;

        //----------------------//
        // Accesseurs publiques //
        //----------------------//

        ////////////////////
        // Accesseurs SET //
        ////////////////////
        public void Set_Chemin_Acces(string CheminAcces) { Chemin_Access = CheminAcces; }
        public void Set_Nom_Fichier_XML(string FichierXML) { Nom_Fichier_XML = FichierXML; }
        public void Set_Mode_Debug(bool Activation) { Mode_debug = Activation; }

        ////////////////////
        // Accesseurs GET //
        ////////////////////
        public string Get_Nom_Circuit() { return Nom_Circuit; }
        public string Get_Image_Circuit() { return Chemin_Access_Image; }
        public string Get_Version_Gestion() { return Version; }
        public Int32 Get_Classement(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Classement(); }
        public Int32 Get_Coordonnees_X(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Coord_X(); }
        public Int32 Get_Coordonnees_Y(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Coord_Y(); }
        public string Get_Case_Adjacente(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Case_Adjacente(); }
        public string Get_Case_Muret(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Case_Muret(); }
        public int Get_NombreCase() { return Nombre_Case; }
        public Int32 Get_Case_Gauche(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Case_Gauche(); }
        public Int32 Get_Case_Droite(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Case_Droite(); }
        public Int32 Get_Case_EnFace(Int32 Numero_Case) { return Case_Circuit[Numero_Case].Get_Case_EnFace(); }

        //-----------------------------------//
        // Declaration des fonctions privees //
        //-----------------------------------//

        //-------------------------------------//
        // Declaration des fonctions publiques //
        //-------------------------------------//

        public string Lecture_Fichier_XML()
        {
            // il faut une première étape de validation du fichier XML par rapport à un xsd

            Int32 Numero_Case;
            Int32 Classement_Case;
            String Chemin_Complet;

            XmlDocument FichierXMLCircuit = new XmlDocument();
            // Penser à rajouter un try catch ici et récupérer l'erreur sur le fichier XML
            Chemin_Complet = Chemin_Access + "\\" + Nom_Fichier_XML;

            // On essaye d'ouvrir le fichier XML
            try
            {
                FichierXMLCircuit.Load(Chemin_Complet);
            }
            // si le fichier n'existe pas on retourne une erreur
            catch
            {
                return "Chargementfichierxmlnok";
            }

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
                            Chemin_Access_Image = Chemin_Access + "\\" + lectureXML_Niveau_1.InnerText;
                        }
                        if (lectureXML_Niveau_1.Name == "Circuit_Nombre_Case")
                        {
                            Nombre_Case = Int32.Parse(lectureXML_Niveau_1.InnerText);
                            Case_Circuit = new Case[Nombre_Case + 1];
                        }
                        
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
                                            Classement_Case = Convert.ToInt32(lectureXML_Case_Case.InnerText);                                        //Construction de la case à partir des attributs.
                                            Case_Circuit[Numero_Case] = new Case();
                                            Case_Circuit[Numero_Case].Construction_Case(Numero_Case, Classement_Case);
                                        } 
                                        if (lectureXML_Case_Case.Name == "Case_X")
                                        {
                                            Case_Circuit[Numero_Case].Set_Coord_X(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Y")
                                        {
                                            Case_Circuit[Numero_Case].Set_Coord_Y(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Adjacente")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Circuit[Numero_Case].Set_Case_Adjacente(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Gauche")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Circuit[Numero_Case].Set_Case_Gauche(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Droite")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Circuit[Numero_Case].Set_Case_Droite(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_EnFace")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Circuit[Numero_Case].Set_Case_EnFace(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Muret")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Circuit[Numero_Case].Set_Case_Muret(lectureXML_Case_Case.InnerText);
                                            }
                                        }

                                    }// Fin parcout noeud XML Case                              
                                }
                            }// Fin parcourt noeud XML Circuit_Case
                        }
                    }// Fin parcourt noeud XML Circuit_Definition
                }
            }
            return "Chargementxmlok";
            // fin la fonction Lecture_Fichier_XML()
        }
    }
}

