using Projekt_web.Models;
using Projekt_web.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekt_web.Controllers
{
    public class LibraryController : Controller
    {
        public ActionResult View(int id)
        {
            Library library;
            using (DatabaseContext db = new DatabaseContext())
                library = db.Libraries.FirstOrDefault(a => Library.LibraryId == 1);
            return View(library);
        }
    }
}