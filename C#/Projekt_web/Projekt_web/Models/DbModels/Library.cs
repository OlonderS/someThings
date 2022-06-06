using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Projekt_web.Models.DbModels
{
    public class Library
    {
        public static int LibraryId;
        public static string Name;
        public static List<Book> Books;
        public static List<User> Users;

        static Library()
        {
            List<Book> Books = new List<Book>();
            Name = "Biblioteka";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"ID: {LibraryId}, Name: {Name}\nList of books:");
            Books.ForEach(x => sb.AppendLine(x.ToString()));
            return sb.ToString();
        }
    }
}