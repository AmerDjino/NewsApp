-- Table dbo.Priviledge
create table
	[dbo].[Priviledge]
(
	[PriviledgeID] uniqueidentifier not null
	, [PriviledgeName] nvarchar(50) not null
	, [PriviledgeDescription] nvarchar(max) null
,
constraint [Pk_Priviledge_PriviledgeID] primary key clustered
(
	[PriviledgeID] asc
)
);