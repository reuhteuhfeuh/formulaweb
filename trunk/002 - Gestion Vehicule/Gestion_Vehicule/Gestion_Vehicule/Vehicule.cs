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


        // Un dictionnaire par typologie.
        // Dictionnaire Int32
        Dictionary<String, Int32> Caracteristique_Int32 = new Dictionary<String, Int32>();
        // Dictionnaire String
        Dictionary<String, String> Caracteristique_String = new Dictionary<String, String>();
        // Dictionnaire Bool
        Dictionary<String, Boolean> Caracteristique_Bool = new Dictionary<String, Boolean>();

        // Declaration des variables
        private Int32 Numero_Case;
        private Int32 Carosserie;
        private Int32 Tenue_De_Route;
        private Int32 Moteur;
        private Int32 Pneu;
        private Int32 Frein;
        private Int32 Consommation;


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
