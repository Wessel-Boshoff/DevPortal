create proc [dbo].[AddCategory]
	@firstnames		varchar(250),
	@lastname		varchar(250),
	@email			varchar(255),
	@phonenumber	varchar(20) = null
as
begin
	set nocount on;

	insert into [dbo].[Customers] 
	(
		 [FirstNames]
		,[LastName]
		,[Email]
		,[PhoneNumber]
	)
	values 
	(
		 @firstnames
		,@lastname
		,@email
		,@phonenumber
	);

	select scope_identity() as [id];
end