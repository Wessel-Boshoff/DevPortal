create proc [dbo].[GetCustomerById]
	@id int
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
	from [dbo].[Customers]
	where
		[Id] = @id;
end
go
