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

        private GetData getData = new GetData();
        private DBHandler dbcon = new DBHandler();
        private string error = "";
        
        public ActionResult Index()
        {
            return View(new Manage() { data = getData.data() });
        }

        [HttpPost]
        public ActionResult Index(string name, string url, string comment, string id, string save, string delete)
        {
            if (!string.IsNullOrEmpty(save)) // Edit object
            {
                error = "save";
                dbcon.openConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbcon.connection;
                string sql = string.Format("UPDATE data SET name='{0}', comment='{1}', url='{2}' where id='{3}'", name,comment,url,id);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                dbcon.closeConnection();
            }
            else if (!string.IsNullOrEmpty(delete)) // Delete object
            {
                dbcon.openConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbcon.connection;
                string sql = string.Format("DELETE FROM data WHERE id='{0}'", id);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                dbcon.closeConnection();
            }
            else // Add new object
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
                }
                else
                {
                    error = "Name can't be empty";
                }
            }

            return View(new Manage() { error = error, data = getData.data() });
        }
    }
}