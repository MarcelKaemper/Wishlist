using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wishlist.Models
{
    public class Home
    {
        public string error { get; set; }
        public List<List<string>> data { get; set; }
    }
}