using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Traceur;
using System.Net;
using System.Net.Sockets;

namespace FormulaWebServ
{
    class FwebServeur
    {
        private static Int32 port_reseau = 12546;
        private static Int32 port_param = 12590;
        private static string Version = "0.1";


        static void Main(string[] args)
        {           
            Traceur.Traceur Serv_log = new Traceur.Traceur();
            Serv_log.Init("FormulaWebServeur.log");
            Serv_log.Trace("Initialisation du serveur FWeb version "+Version,"Log");
            Thread SFWEB = new Thread(new ParameterizedThreadStart (Ecoute_Reseau));
            Thread SFWEBPARAM = new Thread(new ParameterizedThreadStart (Ecoute_Reseau_parametrage));
            SFWEB.Start(port_reseau);
            SFWEBPARAM.Start(port_param);
        }

        static void Ecoute_Reseau(object port)
        {
            //Int32 port_serv = 12584;
            Int32 port_udp_jeu = (Int32)port;
            Console.WriteLine("Le serveur se met en mode ecoute ... sur le port " + port_udp_jeu.ToString());
            UdpClient SFWEBUDP = new UdpClient(port_udp_jeu);
            while (true)
            {

            }
        }

        static void Ecoute_Reseau_parametrage(object port)
        {
            Int32 port_udp_param = (Int32)port;
            Console.WriteLine("Le serveur parametrage se met en mode ecoute ... sur le port " + port_udp_param.ToString());
            UdpClient SFWEBUDPPARAM = new UdpClient(port_udp_param);
            while (true)
            {

            }
        }
    }
}
