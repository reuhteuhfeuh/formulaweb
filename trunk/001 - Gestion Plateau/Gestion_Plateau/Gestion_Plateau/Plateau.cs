using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

/////////////////////////////////
// Dll pour la gestion circuit //
/////////////////////////////////

namespace Gestion_Plateau
{
    public class Plateau
    {
        // Variables utilisées pour versionning
        private string Version = "0.0.0.3";

        // Declaration des variables standards
        private string Chemin_Access;
        private string Nom_Fichier_XML;
        private string Nom_Plateau;
        private string Nom_Image_Plateau;
        private string Chemin_Access_Image;
        private Int32 Nombre_Case;
        private double Ratio_Voiture;
        private Case[] Case_Plateau;
        private bool Mode_debug = false;

        // Declaration des Int64
        public Int64 Caracteristique_Int64_01 { get; set; }
        public Int64 Caracteristique_Int64_02 { get; set; }
        public Int64 Caracteristique_Int64_03 { get; set; }
        public Int64 Caracteristique_Int64_04 { get; set; }
        public Int64 Caracteristique_Int64_05 { get; set; }
        public Int64 Caracteristique_Int64_06 { get; set; }
        public Int64 Caracteristique_Int64_07 { get; set; }
        public Int64 Caracteristique_Int64_08 { get; set; }
        public Int64 Caracteristique_Int64_09 { get; set; }
        public Int64 Caracteristique_Int64_10 { get; set; }

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
        public string Get_Nom_Circuit() { return Nom_Plateau; }
        public string Get_Image_Circuit() { return Chemin_Access_Image; }
        public string Get_Version_Gestion() { return Version; }
        public Int32 Get_Classement(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Case_Classement; }
        public Int32 Get_Coordonnees_X(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Coord_X; }
        public Int32 Get_Coordonnees_Y(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Coord_Y; }
        public string Get_Case_Adjacente(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Get_Case_Adjacente(); }
        public string Get_Case_Muret(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Get_Case_Muret(); }
        public int Get_NombreCase() { return Nombre_Case; }
        public Int32 Get_Case_Gauche(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Get_Case_Gauche(); }
        public Int32 Get_Case_Droite(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Get_Case_Droite(); }
        public Int32 Get_Case_EnFace(Int32 Numero_Case) { return Case_Plateau[Numero_Case].Get_Case_EnFace(); }
        public double Get_Ratio_Voiture() { return Ratio_Voiture; }

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
                            Nom_Plateau = lectureXML_Niveau_1.InnerText;
                        }
                        if (lectureXML_Niveau_1.Name == "Circuit_Graphique")
                        {
                            Nom_Image_Plateau = lectureXML_Niveau_1.InnerText;
                            Chemin_Access_Image = Chemin_Access + "\\" + lectureXML_Niveau_1.InnerText;
                        }
                        if (lectureXML_Niveau_1.Name == "Circuit_Nombre_Case")
                        {
                            Nombre_Case = Int32.Parse(lectureXML_Niveau_1.InnerText);
                            Case_Plateau = new Case[Nombre_Case + 1];
                        }
                        if (lectureXML_Niveau_1.Name == "Circuit_Ratio_Voiture")
                        {
                            Ratio_Voiture = double.Parse(lectureXML_Niveau_1.InnerText);
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
                                            Case_Plateau[Numero_Case] = new Case();
                                            Case_Plateau[Numero_Case].Construction_Case(Numero_Case, Classement_Case);
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_X")
                                        {
                                            //Case_Circuit[Numero_Case].Set_Coord_X(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            Case_Plateau[Numero_Case].Coord_X = Convert.ToInt32(lectureXML_Case_Case.InnerText);
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Y")
                                        {
                                            Case_Plateau[Numero_Case].Coord_Y = (Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Adjacente")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Plateau[Numero_Case].Set_Case_Adjacente(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Gauche")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Plateau[Numero_Case].Set_Case_Gauche(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Droite")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Plateau[Numero_Case].Set_Case_Droite(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_EnFace")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Plateau[Numero_Case].Set_Case_EnFace(Convert.ToInt32(lectureXML_Case_Case.InnerText));
                                            }
                                        }
                                        if (lectureXML_Case_Case.Name == "Case_Muret")
                                        {
                                            if (lectureXML_Case_Case.InnerText != "")
                                            {
                                                Case_Plateau[Numero_Case].Set_Case_Muret(lectureXML_Case_Case.InnerText);
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

