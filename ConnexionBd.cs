using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gestion_caise
{
    internal class ConnexionBd
    {

       public String chaine_de_connexion = "data source = localhost; database = gestion_caise; user id = root";
       public MySqlCommand command;
       public MySqlDataReader monreader;
       public MySqlConnection monconnection;

        public ConnexionBd() { }

        



       
        
       
             
       
    }
}
