-- Table dbo.Role
create table
	[dbo].[Role]
(
	[RoleID] uniqueidentifier not null
	, [RoleName] int not null
	, [RoleDesription] nvarchar(50) null
,
constraint [Pk_Role_RoleID] primary key clustered
(
	[RoleID] asc
)
);