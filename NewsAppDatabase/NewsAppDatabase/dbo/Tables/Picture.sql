-- Table dbo.Picture
create table
	[dbo].[Picture]
(
	[PictureID] uniqueidentifier not null
	, [PictureURL] nvarchar(max) not null
	, [PictureDescription] nvarchar(300) not null
,
constraint [Pk_Picture_PictureID] primary key clustered
(
	[PictureID] asc
)
);