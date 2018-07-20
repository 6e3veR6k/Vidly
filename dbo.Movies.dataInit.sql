USE [Vidly]
GO

INSERT INTO [dbo].[Movies]
           ([ImgPath]
           ,[OriginalTitle]
           ,[ReleaseDate]
           ,[Director]
           ,[Description]
           ,[RatingId])
     VALUES
           (N'/Content/Images/diehard.jpg'
           ,N'Die Hard'
           ,'1988-07-20'
           ,N'John McTiernan'
           ,N'John McClane, officer of the NYPD, tries to save his wife Holly Gennaro and several others that were taken hostage by German terrorist Hans Gruber during a Christmas party at the Nakatomi Plaza in Los Angeles.'
           , 3),
           (N'/Content/Images/frozen.jpg'
           ,N'Frozen'
           ,'2013-12-12'
           ,N'Jennifer Lee'
           ,N'When the newly-crowned Queen Elsa accidentally uses her power to turn things into ice to curse her home in infinite winter, her sister Anna teams up with a mountain man, his playful reindeer, and a snowman to change the weather condition.'
           , 1),
		   (N'/Content/Images/redemption.jpg'
           ,N'The Shawshank Redemption'
           ,'1994-10-14'
           ,N'Frank Darabont'
           ,N'Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.'
           , 2),
		   	(N'/Content/Images/thedarkknight.jpg'
           ,N'The Dark Knight'
           ,'2008-10-14'
           ,N'Christopher Nolan'
           ,N'When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham. The Dark Knight must accept one of the greatest psychological and physical tests of his ability to fight injustice.'
           , 3),
		   	(N'/Content/Images/inception.jpg'
           ,N'Inception'
           ,'2010-07-22'
           ,N'Christopher Nolan'
           ,N'A thief, who steals corporate secrets through the use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO.'
           , 3),
		   	(N'/Content/Images/avangersinfinitywar.jpg'
           ,N'Avengers: Infinity War'
           ,'2018-04-26'
           ,N'Anthony Russo'
           ,N'The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.'
           , 2),
		   	(N'/Content/Images/lifeisbeautiful.jpg'
           ,N'La vita ? bella'
           ,'1997-12-20'
           ,N'Roberto Benigni'
           ,N'When an open-minded Jewish librarian and his son become victims of the Holocaust, he uses a perfect mixture of will, humor, and imagination to protect his son from the dangers around their camp.'
           , 3)
GO


