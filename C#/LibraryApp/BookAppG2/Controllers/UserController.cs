using BookAppG2.Models;
using BookAppG2.Models.DbModels;
using BookAppG2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookAppG2.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Unlogged()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            if (Session["UserId"] != null)
            {
                List<RentedBook> rentedBooks = new List<RentedBook>();
                List<RentedBookViewModel> rentedBooksView = new List<RentedBookViewModel>();
                List<RentedBookViewModel> rentedBooksViewToReturn = new List<RentedBookViewModel>();
                using (DatabaseContext db = new DatabaseContext())
                {
                    int s = Convert.ToInt32(Session["UserId"]);
                    var rbt = db.RentedBooks
                        .Join(
                        db.Books,//tabela
                        rb => rb.BookId,//poprzednie tabele
                        b => b.BookId,//dokładana tabela
                        (rb, b) => new { rb, b }
                        )
                        .Join(
                        db.Users,
                        rbb => rbb.rb.UserId,
                        u => u.UserId,
                        (rbb, u) => new { rbb, u }
                        )

                        .Select(x => new RentedBookViewModel()
                        {
                            BookId = x.rbb.b.BookId,
                            Title = x.rbb.b.Title,
                            Author = x.rbb.b.Author,
                            UserId = x.u.UserId,
                            Name = x.u.Name,
                            RentedBookId = x.rbb.rb.RentedBookId
                        })
                        .Where(x => x.UserId == s)
                        .ToList();
                    return View(rbt);
                }  
            }
            return RedirectToAction("Unlogged");
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(new User());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new User());
        }
        public ActionResult Return(int? id)
        {
            RentedBook book;
            Book book1;      
            using (DatabaseContext db = new DatabaseContext())
            {
                book = db.RentedBooks.FirstOrDefault(x => x.RentedBookId == id);
                book1 = db.Books.FirstOrDefault(x => x.BookId == book.BookId);
                if (book1 != null)
                    book1.Available = true;
                db.RentedBooks.Remove(book);
                db.SaveChanges();
                return View(book);
            }
        }
    
    }
}