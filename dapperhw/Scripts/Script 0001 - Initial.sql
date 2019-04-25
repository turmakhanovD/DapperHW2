create table [dbo].[News]
(
id uniqueidentifier primary key,
article nvarchar(50) not null,
text nvarchar(max) not null,
PublishedDate datetime not null,
DeletedDate datetime
)

create table [dbo].[Comments]
(
id uniqueidentifier primary key,
text nvarchar(150) not null,
NewsId uniqueidentifier not null,
PublishedDate datetime not null,
DeletedDate datetime
)