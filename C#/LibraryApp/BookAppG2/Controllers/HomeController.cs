using BookAppG2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookAppG2.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string name, string password)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    var data1 = db.Users.Where(s => s.Name.Equals(name));
                    var data = data1.Where(s => s.Password.Equals(password));
                    if (data.Count() > 0)
                    {
                        Session["FullName"] = data.FirstOrDefault().Name;
                        Session["UserId"] = data.FirstOrDefault().UserId;
                        return RedirectToAction("Logged");
                    }
                    else
                    {
                        ViewBag.error = "Login failed";
                        return RedirectToAction("Login");
                    }
                }
            }
            return View();
        }
        public ActionResult Logged()
        {
            if (Session["UserId"] != null)
                return View();
            return RedirectToAction("Login");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        { 
            if (Session["UserId"] != null)
                Session["UserId"] = null;
            return RedirectToAction("Logouted");        
        }

        public ActionResult Logouted()
        {
            return View();
        }
    }
}