using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace wishlist.Helpers
{
    public class DBHandler
    {
        public MySqlConnection connection { get; set; }

        public void openConnection()
        {
            connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString);
            connection.Open();
        }

        public void closeConnection()
        {
            connection.Close();
        }
    }
}