create table [dbo].[Payments]
(
	 [Id]				bigint			not null	primary key identity(1,1)
	,[OrderId]			bigint			not null	foreign key references [Orders](Id)
	,[PaymentStatusId]	tinyint			not null	foreign key references [PaymentStatuses](Id)
	,[Amount]			decimal(18,2)	not null    check ([Amount] >= 0)
	,[Date]				datetime		not null	default getdate()
	,[DateCreated]		datetime		not null	default getdate()
)
