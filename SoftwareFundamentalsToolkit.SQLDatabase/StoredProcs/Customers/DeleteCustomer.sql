create proc [dbo].[DeleteCustomer]
	@id int
as
begin
	set nocount on;

	delete from [dbo].[customers]
	where [Id] = @id;
end