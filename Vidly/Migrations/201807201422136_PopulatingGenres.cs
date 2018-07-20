namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenres : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[Genres]([Id], [Type], [Description]) 
                VALUES 
                (1, N'Action',N'Action films usually include high energy, big-budget physical stunts and chases, possibly with rescues, battles, fights, escapes, destructive crises (floods, explosions, natural disasters, fires, etc.), non-stop motion, spectacular rhythm and pacing, and adventurous, often two-dimensional ''good-guy'' heroes (or recently, heroines) battling ''bad guys'' - all designed for pure audience escapism.'),
                (2, N'Adventure', N'Adventure films are usually exciting stories, with new experiences or exotic locales, very similar to or often paired with the action film genre. They can include traditional swashbucklers or pirate films, serialized films, and historical spectacles (similar to the epics film genre), searches or expeditions for lost continents, ""jungle"" and ""desert"" epics, treasure hunts, disaster films, or searches for the unknown.'),
                (3, N'Comedy', N'Comedies are light-hearted plots consistently and deliberately designed to amuse and provoke laughter (with one-liners, jokes, etc.) by exaggerating the situation, the language, action, relationships and characters.'),
                (4, N'Crime', N'Crime (gangster) films are developed around the sinister actions of criminals or mobsters, particularly bankrobbers, underworld figures, or ruthless hoodlums who operate outside the law, stealing and murdering their way through life. The criminals or gangsters are often counteracted by a detective-protagonist with a who-dun-it plot.'),
                (5, N'Drama', N'Dramas are serious, plot-driven presentations, portraying realistic characters, settings, life situations, and stories involving intense character development and interaction. Usually, they are not focused on special-effects, comedy, or action, Dramatic films are probably the largest film genre, with many subsets.'),
                (6, N'Epic', N'Epics include costume dramas, historical dramas, war films, medieval romps, or ''period pictures'' that often cover a large expanse of time set against a vast, panoramic backdrop. Epics often share elements of the elaborate adventure films genre. Epics take an historical or imagined event, mythic, legendary, or heroic figure, and add an extravagant setting or period, lavish costumes, and accompany everything with grandeur and spectacle, dramatic scope, high production values, and a sweeping musical score.'),
                (7, N'Horror', N'Horror films are designed to frighten and to invoke our hidden worst fears, often in a terrifying, shocking finale, while captivating and entertaining us at the same time in a cathartic experience. Horror films feature a wide range of styles, from the earliest silent Nosferatu classic, to today''s CGI monsters and deranged humans. They are often combined with science fiction when the menace or monster is related to a corruption of technology, or when Earth is threatened by aliens.'),
                (8, N'Musicals', N'Musical/dance films are cinematic forms that emphasize full-scale scores or song and dance routines in a significant way (usually with a musical or dance performance integrated as part of the film narrative), or they are films that are centered on combinations of music, dance, song or choreography. Major subgenres include the musical comedy or the concert film.'),
                (9, N'Science fiction', N'Sci-fi films are often quasi-scientific, visionary and imaginative - complete with heroes, aliens, distant planets, impossible quests, improbable settings, fantastic places, great dark and shadowy villains, futuristic technology, unknown and unknowable forces, and extraordinary monsters (''things or creatures from space''), either created by mad scientists or by nuclear havoc. They are sometimes an offshoot of the more mystical fantasy films (or superhero films), or they share some similarities with action/adventure films.'),
                (10, N'War', N'War (and anti-war) films acknowledge the horror and heartbreak of war, letting the actual combat fighting (against nations or humankind) on land, sea, or in the air provide the primary plot or background for the action of the film. War films are often paired with other genres, such as action, adventure, drama, romance, comedy (black), suspense, and even historical epics and westerns, and they often take a denunciatory approach toward warfare.'),
                (11, N'Westerns', N'Westerns are the major defining genre of the American film industry - a eulogy to the early days of the expansive American frontier. They are one of the oldest, most enduring genres with very recognizable plots, elements, and characters (six-guns, horses, dusty towns and trails, cowboys, Indians, etc.). They have evolved over time, however, and have often been re-defined, re-invented and expanded, dismissed, re-discovered, and spoofed.');
                ");
        }
        
        public override void Down()
        {
        }
    }
}
