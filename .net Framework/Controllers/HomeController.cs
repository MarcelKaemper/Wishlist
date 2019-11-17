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
        public ActionResult Index()
        {
            return View(new Home() {data=new GetData().data()});
        }
    }
}