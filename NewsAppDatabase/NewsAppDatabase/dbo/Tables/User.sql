-- Table dbo.User
create table
	[dbo].[User]
(
	[UserID] uniqueidentifier not null
	, [Username] nvarchar(50) not null
	, [FirstName] nvarchar(50) not null
	, [LastName] nvarchar(50) not null
	, [Email] nvarchar(100) not null
,
constraint [Pk_User_UserID] primary key clustered
(
	[UserID] asc
)
);