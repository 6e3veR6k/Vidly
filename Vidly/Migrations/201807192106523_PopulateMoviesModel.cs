namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMoviesModel : DbMigration
    {
        public override void Up()
        {
            //todo complete statements
            Sql("INSERT INTO dbo.Movies (Id, )");
        }
        
        public override void Down()
        {
        }
    }
}
