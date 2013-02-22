using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/* Nom          : Classe Case
 * Description  : Chaque objet Case représente une case du circuit
 * Date Ajout   : 15/02/2012
 * Auteur       : RTF alias FC
 * 
 * Typologie    : Interne à la gestion
 *
 * 
 */
namespace Gestion_Circuit
{
    class Case
    {
        // Variables utilisées pour versionning
        //private string Version = "0.0.0.1";

        // Declaration des variables
        private Int32 Case_Numero;
        private Int32 Case_Classement;
        private Int32 Coord_X;
        private Int32 Coord_Y;
        private Int32 Case_Gauche;
        private Int32 Case_Droite;
        private Int32 Case_EnFace;
        private Int32 Case_Occupee;
        private string Case_Adjacente = "";
        private string Case_Muret;

        //----------------------//
        // Accesseurs publiques //
        //----------------------//

        ////////////////////
        // Accesseurs SET //
        ////////////////////
        public void Set_Occupee( Int32 Voiture_Occupee) { Case_Occupee = Voiture_Occupee; }
        public void Set_Coord_X(Int32 Position_X) { Coord_X = Position_X; }
        public void Set_Coord_Y(Int32 Position_Y) { Coord_Y = Position_Y; }
        public void Set_Case_Adjacente(Int32 Numero_Case_Adjacente) { if (Case_Adjacente == "") { Case_Adjacente = string.Concat("-", Numero_Case_Adjacente.ToString(), "-"); } else { Case_Adjacente = string.Concat(Case_Adjacente, Numero_Case_Adjacente.ToString(), "-"); } }
        public void Set_Case_Gauche(Int32 Numero_Case_Gauche) { Case_Gauche = Numero_Case_Gauche; }
        public void Set_Case_Droite(Int32 Numero_Case_Droite) { Case_Droite = Numero_Case_Droite; }
        public void Set_Case_EnFace(Int32 Numero_Case_Enface) { Case_EnFace = Numero_Case_Enface; }
        public void Set_Case_Muret(string Muret) { Case_Muret = Muret; }

        ////////////////////
        // Accesseurs GET //
        ////////////////////
        public Int32 Get_Numero() { return Case_Numero; }
        public Int32 Get_Classement() { return Case_Classement; }
        public Int32 Get_Coord_X() { return Coord_X; }
        public Int32 Get_Coord_Y() { return Coord_Y; }
        public Int32 Get_Occupee() { return Case_Occupee; }
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
            Case_Occupee = 0 ;
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
