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
        #region Variable
        private static Int32 port_reseau = 12546;
        //private static Int32 port_param = 12590;
        private static string Version = "0.1";

        private static Traceur.Traceur Serv_log ;
        private static Gestion_Metier Serveur;

        private static String[] separateur = new string []{"#;;#"};

        // private static List<Socket> Client_connecte = new List<Socket>();
        // private static List<Gestion_Partie> Partie_EnCours = new List<Gestion_Partie>();

        static List<Gestion_Connexion> Joueur_Connecte = new List<Gestion_Connexion>();
        
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Serveur = new Gestion_Metier();
            Serv_log = new Traceur.Traceur();
            Serv_log.Init("FormulaWebServeur.log",true);
            Serv_log.Trace("LOG","Initialisation du serveur FWeb version "+Version);            
            Thread Surveillance = new Thread(Surveillance_connexion);
            Thread SFWEB = new Thread(new ParameterizedThreadStart (Ecoute_Reseau));
            //Thread SFWEBPARAM = new Thread(new ParameterizedThreadStart (Ecoute_Reseau_parametrage));
            Surveillance.Start();
            SFWEB.Start(port_reseau);
            //SFWEBPARAM.Start(port_param);
            
        }

        #endregion



        #region Detection_Deconnexion

        static void Surveillance_connexion()
        {
            Serv_log.Trace("LOG", "Lancement tache surveillance connexion");
            Console.WriteLine("Lancement boucle de detection dc");
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                try
                {
                    if (Joueur_Connecte.Count > 0)
                    {
                        foreach ( Gestion_Connexion Joueur in Joueur_Connecte)
                        {
                            try
                            {
                                Joueur.socket_joueur.Send(ASCIIEncoding.ASCII.GetBytes("Test_dc"));
                            }
                            catch
                            {
                                Console.WriteLine("Detection deconnection du client : " + Joueur.socket_joueur.LocalEndPoint.ToString());
                                Joueur.deconnexion();
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

        #region ecoute_Client
        static void Ecoute_Reseau(object port)
        {
            Serv_log.Trace("LOG", "Lancement tache Ecoute Reseau");
            Int32 port_tcp_jeu = (Int32)port;
            Serv_log.Trace("LOG", "Le serveur se met en mode ecoute ... sur le port " + port_tcp_jeu.ToString());
            //Console.WriteLine("Le serveur se met en mode ecoute ... sur le port " + port_tcp_jeu.ToString());
            TcpListener SFWEBTCP = new TcpListener(IPAddress.Parse("127.0.0.1"),port_tcp_jeu);
            SFWEBTCP.Start();
            while (true)
            {
                // On test s'il y a un message en entrée
                Socket client_entree = SFWEBTCP.AcceptSocket();
                if (client_entree.Connected)
                {
                    Serv_log.Trace("INFO", "Connexion reçue depuis IP " + client_entree.RemoteEndPoint.ToString());
                    Console.WriteLine(" Une connexion en entrée ");
                    // On lance un thread sur la connexion
                    Thread connexion = new Thread(new ParameterizedThreadStart (Traitement_Connexion));
                    Gestion_Connexion Nouveau_Joueur = new Gestion_Connexion();
                    Nouveau_Joueur.socket_joueur = client_entree;
                    Joueur_Connecte.Add(Nouveau_Joueur);
                    connexion.Start(Nouveau_Joueur);
                }
            }
        }

        static void Traitement_Connexion(object msg)
        {
            Gestion_Connexion joueur_encours = (Gestion_Connexion)msg;
            Serv_log.Trace("INFO", "Connexion en cours");
            // Gestion de la connexion login // pass et partie en cours.
            if (Ecriture_Message_Socket(joueur_encours.socket_joueur, "DEMANDE_AUTHENTIFICATION"))
            {
                Serv_log.Trace("INFO", "Envoi demande authentification");
                bool cnx = true;
                Int16 nb_Tentative = 0 ;
                while (cnx)
                {
                    
                    // On a envoyé la demande au client on attend sa réponse
                    if (joueur_encours.socket_joueur.Available > 0)
                    {
                        string retour = Lecture_Message_Socket(joueur_encours.socket_joueur);
                        Console.WriteLine(retour);
                        Serv_log.Trace("INFO", "On a recu : " + retour);
                        String[] msgrcu = retour.Split(separateur, StringSplitOptions.None);
                        if (msgrcu[0] == "DEMANDE_AUTHENTIFICATION")
                        {
                            Serv_log.Trace("INFO", "Demande d'identification de " + msgrcu[1]);
                            if (Serveur.Verification_Connexion(msgrcu[1], msgrcu[2]))
                            {
                                Serv_log.Trace("INFO", "Identification de " + msgrcu[1] + " Valide");
                                Ecriture_Message_Socket(joueur_encours.socket_joueur, "AUTHENTIFICATION_OK");
                                cnx = false;
                            }
                            else
                            {
                                nb_Tentative++;
                                Serv_log.Trace("INFO", "Identification de " + msgrcu[1] + " Invalide");
                                Ecriture_Message_Socket(joueur_encours.socket_joueur, "AUTHENTIFICATION_NOK");
                                cnx = true;
                            }
                            /*
                            if (nb_Tentative == 3)
                            {
                                Serv_log.Trace("INFO", "Identification de " + msgrcu[1] + "Invalide, trois tentatives fermeture de la connexion");
                                Ecriture_Message_Socket(joueur_encours.socket_joueur, "AUTHENTIFICATION_NOK_DC");
                                joueur_encours.deconnexion();
                                Joueur_Connecte.Remove(joueur_encours);
                                Thread.CurrentThread.Abort();
                            }*/

                        }
                        //Ecriture_Message_Socket(joueur_encours.socket_joueur,"BANDE OF COUILLE");
                        cnx = false;
                    }
                    else
                    {
                        //Serv_log.Trace("INFO", "On a pas réussi");
                    }

                    // Donc c'est bien le joueur est connecté mais a-t-il une partie à rejoindre ??

                }
            }
            else
            {
                // On a envoyé et ca na pas marché on cloture la connexion
                Serv_log.Trace("INFO", "Ca Couille à l'envoi de connexion ....");
                joueur_encours.deconnexion();
                Thread.CurrentThread.Abort();
            }

            while (joueur_encours.socket_joueur.Connected)
            {
                string data = "";
                /*int i;
                byte[] bytes = new byte[1024];
                string data = "";
                string reception = "";*/
                if (joueur_encours.socket_joueur.Available > 0)
                {
                    data = Lecture_Message_Socket(joueur_encours.socket_joueur);
                    // Traitement du message

                    switch (data)
                    {
                        case "DECONNEXION" :
                            Console.WriteLine("Deconnexion propre du client");
                            joueur_encours.deconnexion();
                            Thread.CurrentThread.Abort();
                            break;
                        case "CONNEXION" :
                            Serv_log.Trace("INFO", "Connexion du jouer X");
                            break;
                    }
                    data = "";
                }
            }
            Console.WriteLine("Client perdu ... Message.Connected");
            Thread.CurrentThread.Abort();
        }

        #endregion ecouteclient

        #region ecoute_Admin

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

        #region Fonctions
            static string Lecture_Message_Socket(Socket Socket_a_lire)
            {
                int i;
                byte[] bytes = new byte[1024];
                string data = "";
                i = Socket_a_lire.Receive(bytes, bytes.Length, 0);
                data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine(String.Format("Received: {0}", data));
                return data;
            }

            static bool Ecriture_Message_Socket(Socket Socket_a_ecrire, string Message)
            {
                try
                {
                    Socket_a_ecrire.Send(ASCIIEncoding.ASCII.GetBytes(Message));
                    Console.Write("Envoi du message :" + Message);
                    return true;
                }
                catch
                {
                    Console.WriteLine("Impossible d'envoyer le message suivant : "+Message);
                    return false;
                }
            }
        #endregion
    }
}
