namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgPath = c.String(),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        MiddleName = c.String(),
                        Email = c.String(),
                        RegisteredDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImgPath = c.String(),
                        OriginalTitle = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Director = c.String(),
                        Description = c.String(),
                        Rating = c.String(),
                        Genre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");
        }
    }
}
