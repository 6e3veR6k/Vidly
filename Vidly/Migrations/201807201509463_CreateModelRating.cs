namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateModelRating : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Type = c.String(nullable: false, maxLength: 10),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "RatingId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "RatingId");
            AddForeignKey("dbo.Movies", "RatingId", "dbo.Ratings", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Rating", c => c.String());
            DropForeignKey("dbo.Movies", "RatingId", "dbo.Ratings");
            DropIndex("dbo.Movies", new[] { "RatingId" });
            DropColumn("dbo.Movies", "RatingId");
            DropTable("dbo.Ratings");
        }
    }
}
