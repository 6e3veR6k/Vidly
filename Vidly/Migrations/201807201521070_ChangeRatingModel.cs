namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRatingModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "Symbol", c => c.String(nullable: false, maxLength: 5));
            AddColumn("dbo.Ratings", "Level", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Ratings", "Type", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Type", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.Ratings", "Level");
            DropColumn("dbo.Ratings", "Symbol");
        }
    }
}
