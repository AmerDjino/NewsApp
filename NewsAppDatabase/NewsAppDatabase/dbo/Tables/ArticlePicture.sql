-- Table dbo.ArticlePicture
create table
	[dbo].[ArticlePicture]
(
	[ArticleID] uniqueidentifier not null
	, [PictureID] uniqueidentifier not null
,
constraint [Pk_ArticlePicture_ArticleIDPictureID] primary key clustered
(
	[ArticleID] asc
	, [PictureID] asc
)
);
GO
-- Relationship Fk_Article_ArticlePicture_ArticleID
alter table [dbo].[ArticlePicture]
add constraint [Fk_Article_ArticlePicture_ArticleID] foreign key ([ArticleID]) references [dbo].[Article] ([ArticleID]);
GO
-- Relationship Fk_Picture_ArticlePicture_PictureID
alter table [dbo].[ArticlePicture]
add constraint [Fk_Picture_ArticlePicture_PictureID] foreign key ([PictureID]) references [dbo].[Picture] ([PictureID]);