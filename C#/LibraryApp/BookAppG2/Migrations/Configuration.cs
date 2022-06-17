namespace BookAppG2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookAppG2.Models.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(BookAppG2.Models.DatabaseContext context)
        {
            context.Libraries.AddOrUpdate(x => x.LibraryId,
                   new Models.DbModels.Library() { LibraryId = 1, Name = "Biblioteka Wz" }
                   );

            context.Publishers.AddOrUpdate(x => x.PublisherId,
                new Models.DbModels.Publisher() { PublisherId = 1, Name = "Nowa Era" },
                new Models.DbModels.Publisher() { PublisherId = 2, Name = "Helion" }
                );

            context.Books.AddOrUpdate(x => x.BookId,
                new Models.DbModels.Book() { BookId = 1, Title = "Poradnik c#", Description = "Super książka o C#", PublisherId = 2, Category = Models.DbModels.BookType.Science, Available = true, Date = DateTime.Now, Author = "Jan Nowak" },
                new Models.DbModels.Book() { BookId = 2, Title = "Jak szybko biegać", Description = "Super książka o bieganiu", PublisherId = 1, Category = Models.DbModels.BookType.Sport, Available = true, Date = DateTime.Now, Author = "Jusajnt Bolt" },
                new Models.DbModels.Book() { BookId = 3, Title = "102 potrawy", Description = "Super książka o gotowaniu", PublisherId = 2, Category = Models.DbModels.BookType.Other, Available = true, Date = DateTime.Now, Author = "Siostra Faustyna" },
                new Models.DbModels.Book() { BookId = 4, Title = "Hello world", Description = "Super książka o programowaniu", PublisherId = 1, Category = Models.DbModels.BookType.Science, Available = true, Date = DateTime.Now, Author = "Jan Nowak" },
                new Models.DbModels.Book() { BookId = 5, Title = "Historia XX wieku", Description = "Super książka o historii XX wieku", PublisherId = 1, Category = Models.DbModels.BookType.History, Available = true, Date = DateTime.Now, Author = "Mieszko Koleżko" },
                new Models.DbModels.Book() { BookId = 6, Title = "Polska superpotęga", Description = "Super książka o Polsce superpotędze", PublisherId = 2, Category = Models.DbModels.BookType.Fantasy, Available = true, Date = DateTime.Now, Author = "Mateusz Morawiecki" }
            );
        }
    }
}
