using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wishlist_core.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using wishlist_core.Helpers;

namespace wishlist_core.Controllers
{
    public class ManageController : Controller
    {
        private string error = "";

        public DBHandler dbh = new DBHandler();
        private DataGetter dg = new DataGetter();

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ManageModel() { data = dg.getData() });
        }

        [HttpPost]
        public IActionResult AddElement(ManageModel m)
        {
            try
            {
                dbh.openConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbh.con;
                string sql = "INSERT INTO data (name, url, comment) VALUES ('{0}', '{1}', '{2}');";
                cmd.CommandText = string.Format(sql, m.name, m.url, m.comment);
                cmd.ExecuteNonQuery();

                dbh.closeConnection();
            } catch(Exception e)
            {
                error = e.Message;
            }

            if (string.IsNullOrEmpty(error))
            {
                return Redirect("/Manage");
            }else
            {
                return View("Index", new ManageModel() { error = error, data=dg.getData()});
            }
        }

        [HttpPost]
        public IActionResult ChangeElement(ManageModel m)
        {
            if (!string.IsNullOrEmpty(m.delete))
            {
                //Delete
                dbh.openConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbh.con;
                string sql = string.Format("DELETE FROM data WHERE id='{0}'", m.ID);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                dbh.closeConnection();

            }
            else
            {
                //Save
                dbh.openConnection();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbh.con;
                string sql = string.Format("UPDATE data SET name='{0}', comment='{1}', url='{2}' where id='{3}'", m.name, m.comment, m.url, m.ID);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();

                dbh.closeConnection();
            }
            //return View("Index", new ManageModel() { data=dg.getData()});
            return Redirect("/Manage");
        }
    }
}