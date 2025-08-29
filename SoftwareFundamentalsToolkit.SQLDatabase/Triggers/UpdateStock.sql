create trigger [UpdateStock]
on [OrderItems]
after insert
as
begin
	set nocount on
    update p
    set 
        p.Stock = p.Stock - i.Quantity
    from 
        Products p
    join 
        inserted i 
    on p.Id = i.ProductId;
end
