-- Table dbo.ArticleComment
create table
	[dbo].[ArticleComment]
(
	[ArticleID] uniqueidentifier not null
	, [UserID] uniqueidentifier not null
	, [CommentID] uniqueidentifier not null
,
constraint [Pk_ArticleComment_ArticleIDUserIDCommentID] primary key clustered
(
	[ArticleID] asc
	, [UserID] asc
	, [CommentID] asc
)
);
GO
-- Relationship Fk_Article_ArticleComment_ArticleID
alter table [dbo].[ArticleComment]
add constraint [Fk_Article_ArticleComment_ArticleID] foreign key ([ArticleID]) references [dbo].[Article] ([ArticleID]);
GO
-- Relationship Fk_User_ArticleComment_UserID
alter table [dbo].[ArticleComment]
add constraint [Fk_User_ArticleComment_UserID] foreign key ([UserID]) references [dbo].[User] ([UserID]);
GO
-- Relationship Fk_Comment_ArticleComment_CommentID
alter table [dbo].[ArticleComment]
add constraint [Fk_Comment_ArticleComment_CommentID] foreign key ([CommentID]) references [dbo].[Comment] ([CommentID]);