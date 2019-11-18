using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wishlist_core.Models
{
    public class ManageModel
    {
        public string values { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string comment { get; set; }
        public string error { get; set; }
        public string addedOn { get; set; }
        public string ID { get; set; }
        public string save { get; set; }
        public string delete{ get; set; }

        public List<List<string>> data { get; set; }
    }
}
