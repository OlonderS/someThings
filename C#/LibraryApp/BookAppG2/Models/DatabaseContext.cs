using BookAppG2.Models.DbModels;
using System.Data.Entity;

namespace BookAppG2.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("BookAppConnectionString") {  }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<RentedBook> RentedBooks { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

