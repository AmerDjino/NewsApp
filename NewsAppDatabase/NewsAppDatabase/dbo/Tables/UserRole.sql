-- Table dbo.UserRole
create table
	[dbo].[UserRole]
(
	[UserID] uniqueidentifier not null
	, [RoleID] uniqueidentifier not null
,
constraint [Pk_UserRole_UserIDRoleID] primary key clustered
(
	[UserID] asc
	, [RoleID] asc
)
);
GO
-- Relationship Fk_User_UserRole_UserID
alter table [dbo].[UserRole]
add constraint [Fk_User_UserRole_UserID] foreign key ([UserID]) references [dbo].[User] ([UserID]);
GO
-- Relationship Fk_Role_UserRole_RoleID
alter table [dbo].[UserRole]
add constraint [Fk_Role_UserRole_RoleID] foreign key ([RoleID]) references [dbo].[Role] ([RoleID]);