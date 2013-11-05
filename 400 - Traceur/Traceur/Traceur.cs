using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace Traceur
{
    public class Traceur
    {
        StreamWriter Gestion_Traceur ;
        public string level { get; set; }
        public string destination { get; set; }
        public bool SQL = true;
        private static SqlConnection cnx ;

        public bool Init()
        {
            Gestion_Traceur = new StreamWriter("FormulaWeb.log");
            Gestion_Traceur.AutoFlush = true;
            return true;
        }

        public bool Init(string Nom_Fichier)
        {
            Gestion_Traceur = new StreamWriter(Nom_Fichier);
            Gestion_Traceur.AutoFlush = true;
            return true;
        }

        public bool Init(string Nom_Fichier, bool BDD)
        {
            Init(Nom_Fichier);
            cnx = new SqlConnection("Data Source=REUHTEUHFEUH\\FORMULAWEB;Initial Catalog=Formula_Web;Integrated Security=True;Pooling=False");
            // Tentative connexion au serveur SQL
            try
            {
                cnx.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Fweb_Log (Log_Level,Log_Commentaire,Log_Date) VALUES ('INFO','Serveur en mode ecoute',GETDATE())", cnx);
                cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                SQL = false;
                Trace("INFO", "Serveur SQL Inacessible passage au log sur fichier");
            }
            return true;
        }

        public bool Trace(string Level, string Message)
        {
            if (destination == "SQL" & SQL)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Fweb_Log (Log_Level,Log_Commentaire,Log_Date) VALUES ("+Level+","+Message+",GETDATE())", cnx);
                cmd.ExecuteNonQuery();
            }

            // pour le moment on garde toujours une trace sur fichier
            Gestion_Traceur.WriteLine(DateTime.Now + " : " + Level + " : " + Message);
            return true;
        }

    }
}
