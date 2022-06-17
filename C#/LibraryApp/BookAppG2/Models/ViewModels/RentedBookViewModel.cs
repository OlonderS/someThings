using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAppG2.Models.ViewModels
{
    public class RentedBookViewModel
    {    
        public RentedBookViewModel() { }      
        public int BookId { get; set; }     
        public string Title { get; set; }
        public string Author { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int RentedBookId { get; set; }
    }
}