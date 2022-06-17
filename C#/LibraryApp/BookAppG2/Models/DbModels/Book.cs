using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookAppG2.Models.DbModels
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public BookType Category { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public bool Available { get; set; }
    }
    public enum BookType { Fantasy, Other, Science, Sport, History }
}