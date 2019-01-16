using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstASP.Models
{
    public class Orders
    {
        public int id { get; set; }
        public int good_id { get; set; }  
        public string FIO { get; set; }
        public string number { get; set; }
        public string adress { get; set; }
        public string email { get; set; }
        public DateTime date { get; set; }

    }
}