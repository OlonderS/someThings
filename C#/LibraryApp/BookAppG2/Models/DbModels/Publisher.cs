using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookAppG2.Models.DbModels
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
