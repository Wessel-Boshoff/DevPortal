create table [dbo].[Categories]
(
	 [Id]			smallint		not null	primary key identity(1,1)
	,[Code]			varchar(4)		not null	unique
	,[Description]	nvarchar(250)	not null	
	,[DateCreated]	datetime		not null	default getdate()			
)
