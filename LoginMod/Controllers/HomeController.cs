using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        Database1 db = new Database1();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User us)
        {
            db.Users.Add(us);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User us)
        {
            var obj = db.Users.Where(x => x.User_Name.Equals(us.User_Name) && x.User_Password.Equals(us.User_Password)).FirstOrDefault();
            if(obj != null)
            {
                return RedirectToAction("Employee");
            }
            else if (us.User_Name == "admin" && us.User_Password == "admin")
            {
                return RedirectToAction("Admin");
            }
            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}