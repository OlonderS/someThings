using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public string Hello()
        {
            return "No hejka co tam";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tu jest niby opis";
            // uzywa cookies wiec nie zawsze dzialaTempData["Wakcje"] = "lala"; 
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Tu jest niby mail czy cos";

            return View();
        }
    }
}