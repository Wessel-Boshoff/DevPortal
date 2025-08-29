create function [dbo].[GetCustomerFullName]
(
	@Id int
)
returns varchar(501)
as
begin
    declare @FullName varchar(501);

    select @FullName = FirstNames + ' ' + LastName
    from Customers
    where Id = @Id;

    return @FullName
end
