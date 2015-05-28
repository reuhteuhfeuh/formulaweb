using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Traceur;
using System.Net;
using System.Net.Sockets;
using Serveur_Gestion;

namespace FormulaWebServ
{
    public class FwebServeur
    {
        #region Variable
        static Gestion_Serveur Serveur;
        
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Serveur = new Gestion_Serveur();
            Serveur.Initialisation_Serveur();
        }

        #endregion


    }
}
