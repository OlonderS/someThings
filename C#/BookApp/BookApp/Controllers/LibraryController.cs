using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using BookApp.Models;
using BookApp.Models.DbModels;

namespace BookApp.Controllers
{
    public class LibraryController : Controller
    {
        public ActionResult ViewAll()
        {
            List<Library> librarys;
            using (DatabaseContext db = new DatabaseContext())
                librarys = db.Libraries.ToList();

            return View(librarys);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Library());
        }

        [HttpPost]
        public ActionResult Create(Library library)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Libraries.Add(library);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }

            return View(library);
        }

        public ActionResult View(int id)
        {
            Library library;
            using (DatabaseContext db = new DatabaseContext())
                library = db.Libraries.FirstOrDefault(a => a.LibraryId == id);

            return View(library);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Library library;
            using (DatabaseContext db = new DatabaseContext())
                library = db.Libraries.FirstOrDefault(l => l.LibraryId == id);

            return View(library);
        }

        [HttpPost]
        public ActionResult Edit(Library library)
        {
            if (!ModelState.IsValid)
                return View(library);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(library).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Library library;
            using (DatabaseContext db = new DatabaseContext())
                library = db.Libraries.FirstOrDefault(x => x.LibraryId == id);

            return View(library);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Library library = db.Libraries.FirstOrDefault(x => x.LibraryId == id);
                db.Libraries.Remove(library);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
    }
}