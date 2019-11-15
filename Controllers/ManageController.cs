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
    public class ManageController : Controller
    {
        private DBHandler dbcon = new DBHandler();
        private string error = "";
        // GET: Manage
        public ActionResult Index()
        {
            return View(new Manage());
        }

        [HttpPost]
        public ActionResult Index(string name, string url, string comment)
        {
            if (!name.Equals(""))
            {
                if (!url.Equals(""))
                {
                    try
                    {
                        dbcon.openConnection();

                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = dbcon.connection;
                        string sql = "INSERT INTO data (name,url,comment) VALUES ('{0}', '{1}', '{2}')";
                        cmd.CommandText = string.Format(sql, name, url, comment);
                        cmd.ExecuteNonQuery();

                        dbcon.closeConnection();
                    }
                    catch (MySqlException e)
                    {
                        error = e.Message;
                    }
                }
                else
                {
                    error = "URL can't be empty";
                }
            } else
            {
                error = "Name can't be empty";
            }

            return View(new Manage() { error = error });

        }
    }
}