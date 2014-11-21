using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Il s'agit ici de gérer toutes les interactions avec la BDD
namespace FormulaWebServ
{
    public class Gestion_Metier
    {
        //Int64 cacabeurk= 332;

        public bool Verification_Connexion(string Log, string Pass)
        {
            // A remplacer par un check en base de donnée
            if (Log=="RTF" & Pass=="prout")
            //Il faut ajouter l'injection dans la base de log des tentatives de connexions
            {
                return true;
            }
            else
            {   
                return false;
            }

        //public bool Lien joueur_Partie(Gestion_Partie)
        }
    }
}
