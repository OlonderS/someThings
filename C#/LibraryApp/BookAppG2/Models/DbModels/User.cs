using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookAppG2.Models.DbModels
{
    public class User
    {
        public User()
        {
            RentedBooks = new List<RentedBook>();
        }
        public int UserId { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Surname { get; set; }
        public string Password { get; set; }
        public List<RentedBook> RentedBooks { get; set; }
    }
}