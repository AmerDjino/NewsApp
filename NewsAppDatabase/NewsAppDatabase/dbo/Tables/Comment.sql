-- Table dbo.Comment
create table
	[dbo].[Comment]
(
	[CommentID] uniqueidentifier not null
	, [CommentContent] nvarchar(max) not null
	, [UpVoteCount] int not null
	, [DownVoteCount] int not null
	, [CommentIsDeleted] bit not null
	, [CommentDate] datetime2(7) not null
	, [ParentCommentID] uniqueidentifier null
,
constraint [Pk_Comment_CommentID] primary key clustered
(
	[CommentID] asc
)
);