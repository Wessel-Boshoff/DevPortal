create table [dbo].[PaymentStatuses]
(
	 [Id]			tinyint			not null	primary key identity(1,1)
	,[Value]		varchar(80)		not null	
	,[Description]	nvarchar(250)	null	
	,[DateCreated]	datetime		not null	default getdate(),
)
