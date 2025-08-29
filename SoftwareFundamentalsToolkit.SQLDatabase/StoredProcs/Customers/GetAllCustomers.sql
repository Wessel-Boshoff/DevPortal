create proc [dbo].[GetAllCustomers]
as
begin
	set nocount on;
	
	select 
		 [Id]
		,[FirstNames]
		,[LastName]
		,[Email]
		,[PhoneNumber]
		,[DateCreated]
	from [dbo].[Customers];
end
go
