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
        private static Int32 PortJeu;
        TcpClient ClientJeu;
        //TcpListener
        NetworkStream Message;
        static private Boolean Connecte;
        public Traceur.Traceur tracereseau { get; set; }

        /*Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
        static IPHostEntry iHost = Dns.GetHostEntry("localhost");
        //static IPAddress vjkdlb = iHost.
        static IPAddress[] addr = iHost.AddressList;
        IPEndPoint ipep = new IPEndPoint(addr[0] , PortJeu);*/
        Socket sock ;
        
        
        

        public Boolean Initialisation()
        {            
            tracereseau.Trace("INFO", "Initialisation Gestion Reseau");
            ServeurJeu = "localhost";
            PortJeu = 12546;
           
            try
            {
                //sock.Blocking = true;
                
                
                //sock.Connect(ipep);

                ClientJeu = new TcpClient(ServeurJeu, PortJeu);
                Message = ClientJeu.GetStream();
                sock = ClientJeu.Client ;
                // Message.
                ClientJeu.ReceiveTimeout = 5000;
                ClientJeu.SendTimeout = 5000;
                Ecriture_Message_Socket("CONNEXION_CLIENT");
                // boucle d'attente du message retour du serveur
                bool cnx_valide = true ;
                bool cnx_serveur = false ;
                string retour_connexion = "";
                tracereseau.Trace("INFO", "Entree dans la boucle de validation login/pass");
                while (cnx_valide)
                {
                    try
                    {
                        retour_connexion = Lecture_Message_Socket();
                        if (retour_connexion.Length > 0)
                        {
                            Console.WriteLine("C'est le bordel : " + retour_connexion);
                            tracereseau.Trace("INFO", "Sent from Serveur : " + retour_connexion);
                            //tracereseau.Trace("INFO", "Message du serveur : " + retour_connexion);
                            if (retour_connexion == "DEMANDE_AUTHENTIFICATION")
                            {
                                Ecriture_Message_Socket("LOGIN:RTF;PASS:prout");
                            }
                            if (retour_connexion == "AUTHEN_OK")
                            {
                                cnx_serveur = true;
                                cnx_valide = false;
                            }
                            if (retour_connexion == "AUTHEN_NOK")
                            {
                                cnx_serveur = false;
                                cnx_valide = false;
                            }
                        }
                    }
                    catch
                    {
                        tracereseau.Trace("INFO", "TIME OUT sur le serveur");
                    }

                }
                tracereseau.Trace("INFO", "Message du serveur : " + retour_connexion);
                Thread Reseau = new Thread(cnx_srv);
                Reseau.Start();
                tracereseau.Trace("INFO", "Thread Reseau lancé");
                return true;
            }
            catch
            {
                tracereseau.Trace("INFO", "A priori ca couille sur la connexion socket");
                return false;
            }
        }

        // Thread d'écoute réseau
        static void cnx_srv()
        {
            while (true)
            {


            }
        }

        public void Fermeture()
        {
            Ecriture_Message_Socket("DECONNEXION");
        }
        /*
        public void Envoi_Message(string msg)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(msg);
            Message.Write(data, 0, data.Length);
        }

        public string Lecture_Message()
        {
            int i;
            byte[] bytes = new byte[1024];
            string data = "";
            i = Message.Read(bytes, bytes.Length, 0);
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            //Console.WriteLine(String.Format("Received: {0}", data));
            return data.ToUpper();
        }*/

        string Lecture_Message_Socket()
        {
            int i;
            byte[] bytes = new byte[1024];
            string data = "";
            i = sock.Receive(bytes, bytes.Length, 0);
            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
            Console.WriteLine(String.Format("Received: {0}", data));
            return data.ToUpper();
        }

        public bool Ecriture_Message_Socket(string Message)
        {
            try
            {
                sock.Send(ASCIIEncoding.ASCII.GetBytes(Message));
                Console.Write("Envoi du message :" + Message);
                return true;
            }
            catch
            {
                Console.WriteLine("Impossible d'envoyer le message suivant : " + Message);
                return false;
            }
        }
    }
}
