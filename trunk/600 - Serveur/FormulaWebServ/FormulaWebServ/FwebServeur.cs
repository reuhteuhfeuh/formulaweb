using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Traceur;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;


namespace FormulaWebServ
{
    class FwebServeur
    {
        private static Int32 port_reseau = 12546;
        private static Int32 port_param = 12590;
        private static string Version = "0.1";
        private static SqlConnection cnx;
        
 


        static void Main(string[] args)
        {           
            Traceur.Traceur Serv_log = new Traceur.Traceur();
            Serv_log.Init("FormulaWebServeur.log",true);
            Serv_log.Trace("Initialisation du serveur FWeb version "+Version,"Log");
            //cnx = new SqlConnection("Data Source=REUHTEUHFEUH\\FORMULAWEB;Initial Catalog=Formula_Web;Integrated Security=True;Pooling=False");
            try
            {
                //cnx.Open();
            }
            catch (SqlException)
            {

                Serv_log.Trace("INFO", "Serveur SQL Inacessible depuis le serveur du jeu");
            }

            Thread SFWEB = new Thread(new ParameterizedThreadStart (Ecoute_Reseau));
            Thread SFWEBPARAM = new Thread(new ParameterizedThreadStart (Ecoute_Reseau_parametrage));
            SFWEB.Start(port_reseau);
            SFWEBPARAM.Start(port_param);
        }

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
            while (true)
            {
                NetworkStream stream = Message.GetStream();
                int i;
                // Buffer for reading data
                byte[] bytes = new byte[1024];
                string data = "";

                // Loop to receive all the data sent by the client.
                i = stream.Read(bytes, 0, bytes.Length);

                while (i != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine(String.Format("Received: {0}", data));

                    // Process the data sent by the client.
                    data = data.ToUpper();

                    //byte[] string_msg = System.Text.Encoding.ASCII.GetBytes(data);

                    /*
                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine(String.Format("Sent: {0}", data));

                    i = stream.Read(bytes, 0, bytes.Length);
                    */
                }
                Console.WriteLine("Message reçu par le serveur : " +data);


            }
            
        }

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
    }
}
