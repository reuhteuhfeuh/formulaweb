using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace FormulaWebServ
{
    // Ici on regroupera tous les joueurs connectés, ainsi que les infos qui y sont liées, par exemple id de la partie, sa socket de connexion, etc.
    class Gestion_Connexion
    {
        // Listing des variables de la classe
        public Socket socket_joueur { get; set; }
        //public TcpClient client_joueur { get; set; }
        public Gestion_Partie partie { get; set; }

        // Listing des fonctions
        public bool deconnexion()
        {
            return true ;
        }
    }
}
