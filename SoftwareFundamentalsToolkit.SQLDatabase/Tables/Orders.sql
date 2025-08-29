create table [dbo].[Orders]
(
	 [Id]				bigint			not null	primary key identity(1,1)
	,[CustomerId]		int				not null	foreign key references [Customers](Id)
	,[OrderStatusId]	tinyint			not null	foreign key references [OrderStatuses](Id)
	,[Date]				datetime		not null	default getdate()
	,[DateCreated]		datetime		not null	default getdate()
)
