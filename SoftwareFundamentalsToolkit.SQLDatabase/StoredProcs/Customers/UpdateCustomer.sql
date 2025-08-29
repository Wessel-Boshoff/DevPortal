create proc [dbo].[UpdateCustomer]
	@id				int,
	@firstnames		varchar(250),
	@lastname		varchar(250),
	@email			varchar(255),
	@phonenumber	varchar(20) = null
as
begin
	set nocount on;

	update [dbo].[Customers]
	set  [FirstNames]  = @firstnames
		,[LastName]    = @lastname
		,[Email]       = @email
		,[PhoneNumber] = @phonenumber
	where [Id] = @id;
end