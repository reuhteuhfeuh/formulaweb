using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Traceur;

namespace Gestion_BDD
{
    public class GestionBdd
    {
        private String Type_DD {get;set;}

        private static SqlConnection cnx;

        Traceur.Traceur Bdd_log;

        public bool Initialisation(string typo)
        {
            Bdd_log = new Traceur.Traceur();
            Bdd_log.Init("FormulaWebBdd.log", true);
            Bdd_log.Trace("Initialisation du serveur Bdd", "Log");

            

            // on initialise la connexion BDD en fonction du type
            switch (Type_DD)
            {
                case "SQLSERVEUR" :

                case "MYSQL" :

                case "MONGODB" :

                default : 
                    break ;


            }

            return true;
        }

            

            
            // connexion au serveur SQL
            /*
            cnx = new SqlConnection("Data Source=REUHTEUHFEUH\\FORMULAWEB;Initial Catalog=Formula_Web;Integrated Security=True;Pooling=False");
            try
            {
                //cnx.Open();
            }
            catch (SqlException)
            {

                Bdd_log.Trace("INFO", "Serveur SQL Inacessible depuis le serveur du jeu");
            }*/

        }

        
    }
}
