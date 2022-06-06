using Projekt_web.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt_web.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Projekt_webConnectionString") { }
        public DbSet<Book> Books { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }

        public DbSet<Library> Libraries { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}