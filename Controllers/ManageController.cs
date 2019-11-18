using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wishlist_core.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace wishlist_core.Controllers
{
    public class ManageController : Controller
    {
        private IConfiguration configuration;

        public ManageController(IConfiguration config)
        {
            configuration = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new ManageModel());
        }

        [HttpPost]
        public IActionResult AddElement(ManageModel m)
        {
            string error = "None";
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = configuration.GetConnectionString("DefaultConnection");
                con.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string sql = "INSERT INTO data (name, url, comment) VALUES ('{0}', '{1}', '{2}');";
                cmd.CommandText = string.Format(sql, m.name, m.url, m.comment);
                cmd.ExecuteNonQuery();

                con.Close();
            } catch(Exception e)
            {
                error = e.ToString();
            }
            return View("Index", new ManageModel() { values = error});
        }
    }
}