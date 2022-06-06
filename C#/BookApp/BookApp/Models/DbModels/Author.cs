using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BookApp.Models.DbModels
{
    public class Author
    {
        public int AuthorId { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> Books { get; set; }
        public Author()  
        {
            List<Book> Books = new List<Book>();
        } 

        public Author(int authorId, string name, string surname)
        {
            List<Book> Books = new List<Book>();
            AuthorId = authorId;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"ID: {AuthorId}, Name: {Name}, Surname: {Surname}\nList of books:");
            Books.ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString();
        }
    }
}