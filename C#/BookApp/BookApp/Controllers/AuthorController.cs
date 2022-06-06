using BookApp.Models;
using BookApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookApp.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult View()
        //{
        //    Author author = new Author(1, "Kamil", "Kucma");
        //    return View(author);
        //}
        public ActionResult View(int id)
        {
            Author author;

            using (DatabaseContext db = new DatabaseContext())
                author = db.Authors.FirstOrDefault(x => x.AuthorId == id);
            if (author == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            return View(author);
        }
        [HttpGet] //domyslnie
        public ActionResult Create()
        {
            return View(new Author());
        }
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    db.Authors.Add(author);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(author);
        }
        public ActionResult ViewAll()
        {
            List<Author> authors;
            using (DatabaseContext db = new DatabaseContext())
                authors = db.Authors.ToList();
            return View(authors);
        }
        public ActionResult Edit(int id)
        {
            Author author;
            using (DatabaseContext db = new DatabaseContext())
                author = db.Authors.FirstOrDefault(x => x.AuthorId == id);
            return View(author);
        }
        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (!ModelState.IsValid)
                return View(author);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
        public ActionResult Delete(int? id)
        {
            Author author;
            using (DatabaseContext db = new DatabaseContext())
                author = db.Authors.FirstOrDefault(x => x.AuthorId == id);
            return View(author);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Author author;
            using (DatabaseContext db = new DatabaseContext())
            {
                author = db.Authors.FirstOrDefault(x => x.AuthorId == id);
                db.Authors.Remove(author);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }

    }
}