namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateNewPropertyMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "ImgPath", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "OriginalTitle", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "Director", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Movies", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Description", c => c.String());
            AlterColumn("dbo.Movies", "Director", c => c.String());
            AlterColumn("dbo.Movies", "OriginalTitle", c => c.String());
            AlterColumn("dbo.Movies", "ImgPath", c => c.String());
            DropColumn("dbo.Movies", "NumberInStock");
        }
    }
}
