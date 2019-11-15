using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wishlist.Helpers;
using wishlist.Models;

namespace wishlist.Controllers
{
    public class HomeController : Controller
    {
        private DBHandler dbcon = new DBHandler();
        private string error = "";
        public ActionResult Index()
        {
            dbcon.openConnection();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = dbcon.connection;
            cmd.CommandText = string.Format("SELECT name,url,comment,added_on FROM wishlist.data");

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

                data.Add(dict);
            }

            reader.Close();

            return View(new Home() {data=data});
        }
    }
}