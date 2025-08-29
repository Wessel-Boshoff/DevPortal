create table [dbo].[OrderItems]
(
	 [Id]				bigint			not null	primary key identity(1,1)
	,[OrderId]			bigint			not null	foreign key references [Orders](Id)
	,[ProductId]		int				not null	foreign key references [Products](Id)
	,[Quantity]			smallint		not null	check([Quantity] > 0)
	,[Price]			decimal(18,2)	not null	check([Price] >= 0)
	,[Date]				datetime		not null	default getdate()
	,[DateCreated]		datetime		not null	default getdate()
)
