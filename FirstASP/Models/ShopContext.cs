using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Entity;

namespace FirstASP.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext() : base("SHOP")
        { }
        public DbSet<Type> Types { get; set; }
            public DbSet<Goods> Goodss { get; set; }
            public DbSet<Info> Infos { get; set; }
            public DbSet<Orders> Orderss { get; set; }
            public DbSet <Users> Userss { get; set; }
    }
}