-- Table dbo.Tag
create table
	[dbo].[Tag]
(
	[TagID] uniqueidentifier not null
	, [TagName] nvarchar(25) not null
,
constraint [Pk_Tag_TagID] primary key clustered
(
	[TagID] asc
)
);