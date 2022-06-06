using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookApp.Models.DbModels
{
    public class Library
    {
        public int LibraryId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }

        public Library()
        {
            List<Book> Books = new List<Book>();
        }

        public Library(int libraryId, string name, List<Book> books)
        {
            List<Book> Books = new List<Book>();
            LibraryId = libraryId;
            Name = name;
            Books = books;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"ID: {LibraryId}, Name: {Name}\nList of books:");
            Books.ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString();
        }
    }
}