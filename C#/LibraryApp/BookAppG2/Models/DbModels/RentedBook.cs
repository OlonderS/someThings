using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookAppG2.Models.DbModels
{
    public class RentedBook
    {
        public RentedBook() { }
        public RentedBook(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
        }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        public int RentedBookId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}