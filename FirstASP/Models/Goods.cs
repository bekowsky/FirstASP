using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstASP.Models
{
    public class Goods
    {
        public int id { get; set; }
        public int type_id { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public int price { get; set; }
       
    }
}