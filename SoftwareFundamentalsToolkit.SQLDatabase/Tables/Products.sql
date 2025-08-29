create table [dbo].[Products]
(
	 [Id]			int				not null	primary key identity(1,1)
	,[CategoryId]	smallint		not null	foreign key references [Categories](Id)
	,[Name]			varchar(250)	not null	
	,[Description]	nvarchar(250)	null	
	,[Price]		decimal(18,2)	not null    check ([Price] >= 0)
	,[Stock]		int				not null	check ([Stock] > 0)
	,[DateCreated]	datetime		not null	default getdate(),

	
)
