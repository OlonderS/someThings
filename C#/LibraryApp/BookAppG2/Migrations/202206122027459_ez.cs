namespace BookAppG2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ez : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentedBooks", "RentDate");
            DropColumn("dbo.RentedBooks", "ReturnDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentedBooks", "ReturnDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.RentedBooks", "RentDate", c => c.DateTime(nullable: false));
        }
    }
}
