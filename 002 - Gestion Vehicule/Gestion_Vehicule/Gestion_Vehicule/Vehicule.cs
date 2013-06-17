using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gestion_Vehicule
{
    public class Vehicule
    {
        // Variables utilisées pour versionning
        private string Version = "0.0.0.1";

        // Declaration des variables
        private Int32 Numero_Case;
        private Int32 Carosserie;
        private Int32 Tenue_De_Route;
        private Int32 Moteur;
        private Int32 Pneu;
        private Int32 Frein;
        private Int32 Consommation;

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
        public void Set_Numero_Case(Int32 Position) { Numero_Case = Position; }
        public void Set_Carosserie(Int32 Pdv_car) { Carosserie = Pdv_car; }
        public void Set_Tenue_De_Route(Int32 Pdv_tdr) { Tenue_De_Route = Pdv_tdr; }
        public void Set_Moteur(Int32 Pdv_mot) { Moteur = Pdv_mot; }
        public void Set_Pneu(Int32 Pdv_pne) { Pneu = Pdv_pne; }
        public void Set_Frein(Int32 Pdv_fre) { Frein = Pdv_fre; }
        public void Set_Consommation(Int32 Pdv_con) { Consommation = Pdv_con; }


        ////////////////////
        // Accesseurs GET //
        ////////////////////
        public string Get_Version_Gestion() { return Version; }
        public Int32 Get_Numero_Case() { return Numero_Case; }
        public Int32 Get_Carosserie() { return Carosserie; }
        public Int32 Get_Tenue_De_Route() { return Tenue_De_Route; }
        public Int32 Get_Moteur() { return Moteur; }
        public Int32 Get_Pneu() { return Pneu; }
        public Int32 Get_Frein() { return Frein; }
        public Int32 Get_Consommation() { return Consommation; }

        //-----------------------------------//
        // Declaration des fonctions privees //
        //-----------------------------------//

        //-------------------------------------//
        // Declaration des fonctions publiques //
        //-------------------------------------//
        public void Construction_Voiture(Int32 Pdv_car, Int32 Pdv_tdr, Int32 Pdv_mot, Int32 Pdv_pne, Int32 Pdv_fre, Int32 Pdv_con)
        {
            Set_Carosserie(Pdv_car);
            Set_Consommation(Pdv_con);
            Set_Frein(Pdv_fre);
            Set_Moteur(Pdv_mot);
            Set_Pneu(Pdv_pne);
            Set_Tenue_De_Route(Pdv_tdr);
        }
    }
}
