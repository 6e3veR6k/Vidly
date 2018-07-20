namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRatings : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[Ratings] ([Id], [Type], [Description], [Symbol], [Level])
                VALUES
                (1, N'General Audiences', N'Nothing that would offend parents for viewing by children', N'G', N'All ages admited'),
                (2, N'Parental guidance suggested', N'Parents urged to give Parental guidance. May contain some material parents might not like for their young children.', N'PG', N'Some material may not be suitable for children'),
                (3, N'Parents strongly cautioned', N'Parents are urged to be cautious. Some material may be inappropriate for pre-tinagers.', N'PG-13', N'Some material may be inappropriate for children under 13'),
                (4, N'Restricted', N'Contain some adult material. Parents are urged to learn more about the film before taking their young children with them.', N'R', N'Under 17 requires accepting parent or adult guardian.'),
                (5, N'No one 17 and under admitted', N'Clearly adult. Children are not admitted.', N'NC-17', N'No one 17 and under admitted')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
