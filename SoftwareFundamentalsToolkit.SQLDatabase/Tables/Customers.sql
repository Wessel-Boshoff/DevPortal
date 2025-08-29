create table [dbo].[Customers]
(
	 [Id]			int				not null	primary key identity(1,1)
	,[FirstNames]	varchar(250)	not null	
	,[LastName]		varchar(250)	not null	
	,[Email]		varchar(255)	not null	unique NONCLUSTERED INDEX Email
	,[PhoneNumber]	varchar(20)		null
	,[DateCreated]	datetime		null		default getdate()			
)
