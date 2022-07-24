-- Table dbo.RolePriviledge
create table
	[dbo].[RolePriviledge]
(
	[RoleID] uniqueidentifier not null
	, [PriviledgeID] uniqueidentifier not null
,
constraint [Pk_RolePriviledge_RoleIDPriviledgeID] primary key clustered
(
	[RoleID] asc
	, [PriviledgeID] asc
)
);
GO
-- Relationship Fk_Role_RolePriviledge_RoleID
alter table [dbo].[RolePriviledge]
add constraint [Fk_Role_RolePriviledge_RoleID] foreign key ([RoleID]) references [dbo].[Role] ([RoleID]);
GO
-- Relationship Fk_Priviledge_RolePriviledge_PriviledgeID
alter table [dbo].[RolePriviledge]
add constraint [Fk_Priviledge_RolePriviledge_PriviledgeID] foreign key ([PriviledgeID]) references [dbo].[Priviledge] ([PriviledgeID]);