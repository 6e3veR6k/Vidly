namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GenreMovies", newName: "MovieGenres");
            DropPrimaryKey("dbo.MovieGenres");
            AddPrimaryKey("dbo.MovieGenres", new[] { "Movie_Id", "Genre_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MovieGenres");
            AddPrimaryKey("dbo.MovieGenres", new[] { "Genre_Id", "Movie_Id" });
            RenameTable(name: "dbo.MovieGenres", newName: "GenreMovies");
        }
    }
}
