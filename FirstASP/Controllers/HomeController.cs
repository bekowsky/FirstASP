using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstASP.Models;
namespace FirstASP.Controllers
{
    public class HomeController : Controller
    {

        ShopContext db = new ShopContext();
        private static  Users User;

        public ActionResult Index()
        {    
          
          ViewBag.data = db.Types;
            ViewBag.Maket = User;
          return View();    
        }

        public ActionResult Contacts()
        {
           
                return PartialView("Contacts");
            
        }
        public ActionResult LogOut()
        {
            User = null;
            return RedirectToAction("Login");

        }
        public ActionResult Create(int num)
        {
            ViewBag.num = num;
            return PartialView("Create");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Goods good)
        {
            db.Goodss.Add(good);
            db.SaveChanges();
            return RedirectToAction("Goods",new { n = good.type_id});
        }

        public ActionResult Edit(int id, int num)
        {
            Goods goods = db.Goodss.Find(id);
            ViewBag.num = goods.type_id;
                return PartialView("Edit", goods);    
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Goods goods)
        {
            db.Entry(goods).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Goods", new {n = goods.type_id });
        }
        // Удаление
        public ActionResult Delete(int id, int num)
        {
            Goods goods = db.Goodss.Find(id);

            return PartialView("Delete", goods);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            Goods goods = db.Goodss.Find(id);

            
                db.Goodss.Remove(goods);
                db.SaveChanges();
           
            return RedirectToAction("Goods", new { n = goods.type_id });
        }

        [HttpGet]
        public ActionResult Goods(int n)
        {
            ViewBag.Maket = User;
            ViewBag.data = from good in db.Goodss
                           where good.type_id == n
                           select good;
            ViewBag.num = n;
            return View();
        }

        [HttpGet]
        public ActionResult FullInformation(int n)
        {
            ViewBag.n = n;
            ViewBag.Maket = User;
            ViewBag.data = from info in db.Infos
                           where info.constract == n
                           select info;
         
            
         
            return View();
        }

        public ActionResult Change(int id)
        {
            ViewBag.n = id;
            Info info = new Info();
            foreach (Info I in db.Infos)
                if (I.constract == id)
                    info = I;
            return PartialView("Change", info);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Change(Info inf, int golf)
        {
            string img = "/Images/" + inf.src;
            inf.id = golf;
            inf.src = img;
            db.Entry(inf).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction( "FullInformation", new { n = inf.constract } );
        }

        public ActionResult Add(int id)
        {
            ViewBag.n = id;
            return PartialView("Add");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Info inf)
        {
            db.Infos.Add(inf);
            db.SaveChanges();
            return RedirectToAction("FullInformation", new { n = inf.constract });
        }

        [HttpGet]
        public ActionResult Order(int n)
        {
            ViewBag.Maket = User;
            ViewBag.data = from good in db.Goodss
                           where good.type_id == n
                           select good;
            ViewBag.num = n;
            return View();
        }


        [HttpPost]
        public ActionResult Order(string num,string name, string number1,string street, string mail)
        {
            Orders orders = new Orders { good_id = Convert.ToInt32(num), FIO = name, number = number1, adress = street, email = mail, date = DateTime.Now };
            db.Entry(orders).State = EntityState.Added;
            db.SaveChanges();
            return PartialView("OrderPart");
        }
   

        [HttpGet]
        
        public ActionResult Login()
        {
            
            return View();
        }

         [HttpPost]
        
        public ActionResult Login(Users U)
        {
            foreach (Users users in db.Userss)
            {
                string text1 = users.login.Trim();
                string text2 = users.password.Trim();
                if (text1 == U.login && text2 == U.password)
                {
                    User = users;
                    if (text1 == "admin" && text2 == "admin")
                        User.admin = true;
                    return RedirectToAction("Index"); ;
                }
            }
            ModelState.AddModelError("InvalidValues", "Такого аккаунта не существует");
            return View(User);
        }

        public ActionResult OrderList()
        {
            ViewBag.Maket = User;
            if (User.admin == true)
                ViewBag.Data = db.Orderss; else
                ViewBag.Data = from order in db.Orderss
                               where order.email == User.email
                               select order;


            return View();
        }
    }
}