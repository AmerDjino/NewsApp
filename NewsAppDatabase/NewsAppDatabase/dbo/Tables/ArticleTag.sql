-- Table dbo.ArticleTag
create table
	[dbo].[ArticleTag]
(
	[ArticleID] uniqueidentifier not null
	, [TagID] uniqueidentifier not null
,
constraint [Pk_ArticleTag_ArticleIDTagID] primary key clustered
(
	[ArticleID] asc
	, [TagID] asc
)
);
GO
-- Relationship Fk_Article_ArticleTag_ArticleID
alter table [dbo].[ArticleTag]
add constraint [Fk_Article_ArticleTag_ArticleID] foreign key ([ArticleID]) references [dbo].[Article] ([ArticleID]);
GO
-- Relationship Fk_Tag_ArticleTag_TagID
alter table [dbo].[ArticleTag]
add constraint [Fk_Tag_ArticleTag_TagID] foreign key ([TagID]) references [dbo].[Tag] ([TagID]);