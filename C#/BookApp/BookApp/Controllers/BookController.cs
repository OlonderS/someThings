
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using BookApp.Models;
using BookApp.Models.DbModels;

namespace BookApp.Controllers
{
    public class BookController : Controller
    {
        public ActionResult ViewAll()
        {
            List<Book> bookies;
            using (DatabaseContext db = new DatabaseContext())
                bookies = db.Books.ToList();

            return View(bookies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }

            return View(book);
        }

        public ActionResult View(int id)
        {
            Book book;
            using (DatabaseContext db = new DatabaseContext())
                book = db.Books.FirstOrDefault(a => a.BookId == id);

            return View(book);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book book;
            using (DatabaseContext db = new DatabaseContext())
                book = db.Books.FirstOrDefault(l => l.BookId == id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Book book;
            using (DatabaseContext db = new DatabaseContext())
                book = db.Books.FirstOrDefault(x => x.BookId == id);

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Book book = db.Books.FirstOrDefault(x => x.BookId == id);
                db.Books.Remove(book);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
    }
}