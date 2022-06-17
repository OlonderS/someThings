using BookAppG2.Models;
using BookAppG2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookAppG2.Controllers
{
    public class BookController : Controller
    {
        public ActionResult View(int id)
        {
            Book book;
            using (DatabaseContext db = new DatabaseContext())
                book = db.Books.FirstOrDefault(a => a.BookId == id);
            return View(book);
        }
        public ActionResult Unlogged()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            if (Session["UserId"] != null)
            {
                List<Book> books;
                using (DatabaseContext db = new DatabaseContext())
                {      
                    books = db.Books.Include(b => b.Publisher).ToList();
                }
                return View(books);
            }
            return RedirectToAction("Unlogged");
        }


        public ActionResult Rent(int? id)
        {
            Book book;
            User user;
            int s = (int)Session["UserId"];
            using (DatabaseContext db = new DatabaseContext())
            {
                book = db.Books.FirstOrDefault(x => x.BookId == id);
                user = db.Users.FirstOrDefault(x => x.UserId == s);
                db.RentedBooks.Add(new RentedBook((int)id, (int)Session["UserId"]));
                book.Available = false;
                db.SaveChanges();
            }
            return View(book);
        }

        [HttpPost, ActionName("Rent")]
        public ActionResult RentConfirm(int? id)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Book book = db.Books.FirstOrDefault(x => x.BookId == id);
                User user = db.Users.FirstOrDefault(x => x.UserId == (int)Session["UserId"]);
            }
            return RedirectToAction("ViewAll");
        }
    }
}