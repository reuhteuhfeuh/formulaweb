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

        Traceur.Traceur Serv_log ;


        #region Initialisation

            public void Main(string[] args)
            {           
                Serv_log = new Traceur.Traceur();
                Serv_log.Init("FormulaWebServeur.log",true);
                Serv_log.Trace("Initialisation du serveur FWeb version "+Version,"Log");



                Thread SFWEB = new Thread(new ParameterizedThreadStart (Ecoute_Reseau));
                Thread SFWEBPARAM = new Thread(new ParameterizedThreadStart (Ecoute_Reseau_parametrage));
                SFWEB.Start(port_reseau);
                SFWEBPARAM.Start(port_param);
            }

        #endregion

        #region ecouteclient

            static void Ecoute_Reseau(object port)
            {
                Int32 port_tcp_jeu = (Int32)port;
                Console.WriteLine("Le serveur se met en mode ecoute ... sur le port " + port_tcp_jeu.ToString());

                TcpListener SFWEBTCP = new TcpListener(IPAddress.Any,port_tcp_jeu); //new TcpClient(port_udp_jeu);
                SFWEBTCP.Start();
                while (true)
                {
                    // On test s'il y a un message en entrée
                    if (SFWEBTCP.Pending())
                    {
                        // On lance un thread sur la connexion
                        Thread connexion = new Thread(new ParameterizedThreadStart (Traitement_Connexion));
                        connexion.Start(SFWEBTCP);
                    }
                }
            }

            static void Traitement_Connexion(object msg)
            {
                TcpListener MessageEnEntree = (TcpListener)msg;
                TcpClient Message = MessageEnEntree.AcceptTcpClient();
                //MessageEnEntree.AcceptTcpClient();
                //Message.C
                while (Message.Connected)
                {
                    NetworkStream stream = Message.GetStream();
                    int i;
                    // Buffer for reading data
                    byte[] bytes = new byte[1024];
                    string data = "";
                    string reception = "";

                    try
                    {
                        while (stream.DataAvailable)
                        {
                            i = stream.Read(bytes, 0, bytes.Length);
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine(String.Format("Received: {0}", data));
                            reception = data.ToUpper();
                            // Traitement du message

                            // Envoi message de retour
                        }
                    }
                    catch
                    {
                        // Connexion perdue !!!
                        Console.WriteLine("Client perdu ...");
                        MessageEnEntree.Stop();
                    }
                }
            }

        #endregion ecouteclient

        #region ecouteAdmin

            static void Ecoute_Reseau_parametrage(object port)
            {
                Int32 port_tcp_param = (Int32)port;
                Console.WriteLine("Le serveur parametrage se met en mode ecoute ... sur le port " + port_tcp_param.ToString());
                TcpListener SFWEBTCPPARAM = new TcpListener(IPAddress.Any, port_tcp_param);
                SFWEBTCPPARAM.Start();
                while (true)
                {
                
                }
            }

        #endregion ecouteAdmin
    }
}
