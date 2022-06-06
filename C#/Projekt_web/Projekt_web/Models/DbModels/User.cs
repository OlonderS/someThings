using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt_web.Models.DbModels
{
    public class User
    {
        public User()
        {
            RentedBooks = new List<RentedBook>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public List<RentedBook> RentedBooks { get; set; }





    }
}