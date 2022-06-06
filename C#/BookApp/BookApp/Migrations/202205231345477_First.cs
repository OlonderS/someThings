namespace BookApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BookType = c.Int(nullable: false),
                        Author_AuthorId = c.Int(),
                        Library_LibraryId = c.Int(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorId)
                .ForeignKey("dbo.Libraries", t => t.Library_LibraryId)
                .Index(t => t.Author_AuthorId)
                .Index(t => t.Library_LibraryId);
            
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        LibraryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LibraryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Library_LibraryId", "dbo.Libraries");
            DropForeignKey("dbo.Books", "Author_AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Library_LibraryId" });
            DropIndex("dbo.Books", new[] { "Author_AuthorId" });
            DropTable("dbo.Libraries");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
