namespace BookAppG2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentedBooks", "RentDate");
            DropColumn("dbo.RentedBooks", "Penalty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentedBooks", "Penalty", c => c.Int(nullable: false));
            AddColumn("dbo.RentedBooks", "RentDate", c => c.DateTime(nullable: false));
        }
    }
}
