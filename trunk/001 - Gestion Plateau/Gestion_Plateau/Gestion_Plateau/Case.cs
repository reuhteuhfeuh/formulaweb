using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Plateau
{
    class Case
    {
        // Declaration des variables standards
        public Int32 Case_Numero {get; set;}
        public Int32 Coord_X { get; set; }
        public Int32 Coord_Y { get; set; }

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

        // Spécifique FDE - to be deleted
        public Int32 Case_Classement { get; set; }
        private Int32 Case_Gauche;
        private Int32 Case_Droite;
        private Int32 Case_EnFace;
        //private Int32 Case_Occupee;
        private string Case_Adjacente = "";
        private string Case_Muret;

        //----------------------//
        // Accesseurs publiques //
        //----------------------//

        ////////////////////
        // Accesseurs SET //
        ////////////////////

        public void Set_Case_Adjacente(Int32 Numero_Case_Adjacente) { if (Case_Adjacente == "") { Case_Adjacente = string.Concat("-", Numero_Case_Adjacente.ToString(), "-"); } else { Case_Adjacente = string.Concat(Case_Adjacente, Numero_Case_Adjacente.ToString(), "-"); } }
        public void Set_Case_Gauche(Int32 Numero_Case_Gauche) { Case_Gauche = Numero_Case_Gauche; }
        public void Set_Case_Droite(Int32 Numero_Case_Droite) { Case_Droite = Numero_Case_Droite; }
        public void Set_Case_EnFace(Int32 Numero_Case_Enface) { Case_EnFace = Numero_Case_Enface; }
        public void Set_Case_Muret(string Muret) { Case_Muret = Muret; }

        ////////////////////
        // Accesseurs GET //
        ////////////////////
        public string Get_Case_Adjacente() { return Case_Adjacente; }
        public Int32 Get_Case_Gauche() { return Case_Gauche; }
        public Int32 Get_Case_Droite() { return Case_Droite; }
        public Int32 Get_Case_EnFace() { return Case_EnFace; }
        public string Get_Case_Muret() { return Case_Muret; }



        //-----------------------------------//
        // Declaration des fonctions privees //
        //-----------------------------------//

        //-------------------------------------//
        // Declaration des fonctions publiques //
        //-------------------------------------//
        public bool Construction_Case(Int32 Numero, Int32 Classement)
        {
            Case_Numero = Numero ;
            Case_Classement = Classement ;
            //Case_Occupee = 0 ;
            Case_Droite = 0 ;
            Case_Gauche = 0 ;
            Case_EnFace = 0 ;
            return true;
        }

        public bool Test_Colision(Int32 Numero_Case_A_Tester)
        {
            if (Case_Adjacente.Contains(Numero_Case_A_Tester.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
