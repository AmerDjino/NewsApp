-- Table dbo.Category
create table
	[dbo].[Category]
(
	[CategoryID] uniqueidentifier not null
	, [CategoryName] nvarchar(50) not null
	, [CategoryDescription] nvarchar(max) null
,
constraint [Pk_Category_CategoryID] primary key clustered
(
	[CategoryID] asc
)
);