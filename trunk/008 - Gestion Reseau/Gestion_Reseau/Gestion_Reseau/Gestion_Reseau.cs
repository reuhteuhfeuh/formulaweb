﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Gestion_Reseau
{
    public class Gestion_Reseau
    {
        private String ServeurJeu;
        private Int16 PortJeu;
        TcpClient ClientJeu;
        NetworkStream Message;
        public Boolean Initialisation()
        {
            ServeurJeu = "Localhost";
            PortJeu = 12546;

            try
            {
                ClientJeu = new TcpClient(ServeurJeu, PortJeu);
                Message = ClientJeu.GetStream();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("PREMIERE CONNEXION !!!!");
                Message.Write(data, 0, data.Length);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Fermeture()
        {
            ClientJeu.Close();
        }

        public void Envoi_Message(string msg)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);
            Message.Write(data, 0, data.Length);
        }
    }
}
