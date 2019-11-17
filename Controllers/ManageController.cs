using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wishlist_core.Models;

namespace wishlist_core.Controllers
{
    public class ManageController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ManageModel());
        }

        [HttpPost]
        public IActionResult AddElement(ManageModel m)
        {
            return View("Index", new ManageModel() { values = m.name + m.url + m.comment });
        }
    }
}