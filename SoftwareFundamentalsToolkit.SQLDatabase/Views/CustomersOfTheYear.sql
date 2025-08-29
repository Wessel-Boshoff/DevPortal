create view [dbo].[CustomersOfTheYear]
as
	select top 10 
		 c.[FirstNames] + ' ' + c.[LastName] 'Full Name'
		,count(*) 'Total Orders'
	from
		[Customers] c
	join
		[Orders] o
	on
		c.[Id] = o.[CustomerId]
	where
		year(o.[Date]) = year(getdate())
	group by
		c.[FirstNames], c.[LastName]
	order by 
		count(*) desc