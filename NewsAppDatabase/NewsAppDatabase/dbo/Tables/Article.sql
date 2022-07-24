-- Model New Model
-- Updated 7/24/2022 2:14:38 PM
-- DDL Generated 7/24/2022 2:47:09 PM

--**********************************************************************
--	Tables
--**********************************************************************

-- Table dbo.Article
create table
	[dbo].[Article]
(
	[ArticleID] uniqueidentifier not null
	, [ArticleTitle] nvarchar(150) not null
	, [ArticleContent] nvarchar(max) not null
	, [CategoryID] uniqueidentifier not null
	, [UserID] uniqueidentifier not null
	, [Date] datetime2(7) not null
	, [ArticleRateing] int not null
	, [isDeleted] bit not null
	, [isEdited] bit not null
	, [isEditing] bit not null
,
constraint [Pk_Article_ArticleID] primary key clustered
(
	[ArticleID] asc
)
);
GO
--**********************************************************************
--	Data
--**********************************************************************
--**********************************************************************
--	Relationships
--**********************************************************************

-- Relationship Fk_Category_Article_CategoryID
alter table [dbo].[Article]
add constraint [Fk_Category_Article_CategoryID] foreign key ([CategoryID]) references [dbo].[Category] ([CategoryID]);
GO
-- Relationship Fk_User_Article_UserID
alter table [dbo].[Article]
add constraint [Fk_User_Article_UserID] foreign key ([UserID]) references [dbo].[User] ([UserID]);