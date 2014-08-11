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
    public static class FwebServeur
    {
        private static Int32 port_reseau = 12546;
        //private static Int32 port_param = 12590;
        private static string Version = "0.1";

        private static Traceur.Traceur Serv_log ;

        private static List<Socket> Client_connecte = new List<Socket>();


        static void Main(string[] args)
        {           
            Serv_log = new Traceur.Traceur();
            Serv_log.Init("FormulaWebServeur.log",true);
            Serv_log.Trace("Initialisation du serveur FWeb version "+Version,"Log");
            Serv_log.Trace("Lancement tache surveillance deco", "Log");
            Thread Surveillance = new Thread(Surveillance_connexion);
            Thread SFWEB = new Thread(new ParameterizedThreadStart (Ecoute_Reseau));
            //Thread SFWEBPARAM = new Thread(new ParameterizedThreadStart (Ecoute_Reseau_parametrage));
            Surveillance.Start();
            SFWEB.Start(port_reseau);
            //SFWEBPARAM.Start(port_param);
        }


        #region Initialisation


        #endregion

        #region Detection_Deconnexion

        static void Surveillance_connexion()
        {
            Console.WriteLine("Lancement boucle de detection dc");
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                try
                {
                    if (Client_connecte.Count > 0)
                    {
                        foreach (Socket surveillance_socket in Client_connecte)
                        {
                            try
                            {
                                surveillance_socket.Send(ASCIIEncoding.ASCII.GetBytes("Test_dc"));
                            }
                            catch
                            {
                                Console.WriteLine("Detection deconnection du client : " + surveillance_socket.LocalEndPoint.ToString());
                                surveillance_socket.Close();
                                Client_connecte.Remove(surveillance_socket);
                            }
                        }
                    }
                }
                catch
                {

                }

            }
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
                    Socket client_entree = SFWEBTCP.AcceptSocket();
                    //if (SFWEBTCP.Pending())
                    if (client_entree.Connected)
                    {
                        Console.WriteLine(" Une connexion en entrée ");
                        // On lance un thread sur la connexion
                        Thread connexion = new Thread(new ParameterizedThreadStart (Traitement_Connexion));
                        Client_connecte.Add(client_entree);
                        connexion.Start(client_entree);
                    }
                }
            }

            static void Traitement_Connexion(object msg)
            {
                //TcpListener MessageEnEntree = (TcpListener)msg;
                //TcpClient Message = MessageEnEntree.AcceptTcpClient();
                Socket client_encours = (Socket)msg;

                while (client_encours.Connected)
                {
                    //NetworkStream stream = Message.GetStream();
                    int i;
                    // Buffer for reading data
                    byte[] bytes = new byte[1024];
                    string data = "";
                    string reception = "";

                    //try
                    //{
                    if (client_encours.Available > 0)
                    {
                        i = client_encours.Receive(bytes, bytes.Length, 0);
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine(String.Format("Received: {0}", data));
                        reception = data.ToUpper();
                        // Traitement du message

                        switch (data)
                        {
                            case "DECONNEXION" :
                                Console.WriteLine("Deconnexion propre du client");
                                Client_connecte.Remove(client_encours);
                                Thread.CurrentThread.Abort();
                                break;



                        }
                        

                        data = "";
                    }
                    // Envoi message de retour
                    /*try
                    {
                        //client_encours.Send( byte[]envoi = new byte {0,0,0},0,3);
                        client_encours.Send(ASCIIEncoding.ASCII.GetBytes("OK"));
                    }
                    catch
                    {
                        Console.WriteLine("Ca a merdé !");
                    }*/
                }
                Console.WriteLine("Client perdu ... Message.Connected");
                //Client_connecte.Remove(client_encours);
                Thread.CurrentThread.Abort();
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
