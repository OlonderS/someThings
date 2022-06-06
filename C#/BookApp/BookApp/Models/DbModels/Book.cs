using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookApp.Models.DbModels
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public BookType BookType { get; set; }
        public int AuthorId;
        public virtual Author Author { get; set; }
        public int LibraryId;
        public virtual Library Library { get; set; }
        public Book() {  }
        public Book(int bookId, string title, BookType bookType)
        {
            BookId = bookId;
            Title = title;
            BookType = bookType;
        }
        public override string ToString()
        {
            return $"BookID: {BookId}, Title: {Title}, Type: {BookType}";
        }
    }

    public enum BookType { Fantasy, Other }
}