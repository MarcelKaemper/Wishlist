using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_core.Helpers;

namespace wishlist_core.Helpers
{
    public class DBHandler
    {
        public MySqlConnection con = new MySqlConnection(Storage.connectionString);

        public void openConnection()
        {
            con.Open();
        }

        public void closeConnection()
        {
            con.Close();
        }
    }
}
