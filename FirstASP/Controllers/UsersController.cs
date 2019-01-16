
using System.Web.Mvc;
using FirstASP.Models;

namespace FirstASP.Controllers
{
    public class UsersController : Controller
    {
        private ShopContext db = new ShopContext();

      
      
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FIO,login,password,email,admin")] Users users)
        {
            if (ModelState.IsValid)
            {
                foreach (Users U in db.Userss)
                {
                    string text = U.login.Trim();
                    if (text == users.login)
                    {
                        ModelState.AddModelError("Error", "Такой логин уже занят");
                        return View(users);
                    }
                }

                db.Userss.Add(users);
                db.SaveChanges();
                return RedirectToAction("Login","Home",new Users { admin = false, email = users.email, password = users.password, login = users.login, FIO = users.FIO });
            }

            return View(users);
        }

    
    }

}
