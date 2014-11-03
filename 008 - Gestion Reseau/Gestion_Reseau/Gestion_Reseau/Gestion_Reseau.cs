using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using Traceur;

namespace Gestion_Reseau
{
    public class Gestion_Reseau
    {
        private String ServeurJeu;
        private Int16 PortJeu;
        TcpClient ClientJeu;
        NetworkStream Message;
        static private Boolean Connecte;
        public Traceur.Traceur tracereseau { get; set; }
        public Boolean Initialisation()
        {
            tracereseau.Trace("INFO", "Initialisation Gestion Reseau");
            ServeurJeu = "Localhost";
            PortJeu = 12546;
            Connecte = true;

            try
            {
                ClientJeu = new TcpClient(ServeurJeu, PortJeu);
                Message = ClientJeu.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("PREMIERE CONNEXION !!!!");
                Message.Write(data, 0, data.Length);
                Thread Reseau = new Thread(Gestion_Reseau);
                Reseau.Start();
                tracereseau.Trace("INFO", "Thread Reseau lancé");
                return true;
            }
            catch
            {
                return false;
            }
        }

        static void Gestion_Reseau(object port)
        {
            while (Connecte)
            {
                // gestion des echanges avec le serveur
            }
        }

        public void Fermeture()
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("DECONNEXION");
            Message.Write(data, 0, data.Length);
        }

        public void Envoi_Message(string msg)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);
            Message.Write(data, 0, data.Length);
        }
    }
}
