using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wishlist_core.Helpers;

namespace wishlist_core.Helpers
{
    public class DataGetter
    {
        private DBHandler dbh = new DBHandler();

        public List<List<string>> getData()
        {
            dbh.openConnection();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = dbh.con;
            cmd.CommandText = "SELECT id,name,url,comment,added_on FROM wishlist.data";

            MySqlDataReader reader = cmd.ExecuteReader();

            List<List<string>> data = new List<List<string>>();

            int row = 0;
            int count = reader.FieldCount;

            while (reader.Read())
            {
                List<string> dict = new List<string>();

                dict.Add(reader.GetValue(0).ToString());
                dict.Add(reader.GetValue(1).ToString());
                dict.Add(reader.GetValue(2).ToString());
                dict.Add(reader.GetValue(3).ToString());
                dict.Add(reader.GetValue(4).ToString());

                data.Add(dict);
            }

            reader.Close();

            return data;
        }
    }
}
