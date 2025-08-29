print 'Merge [dbo].[PaymentStatuses]'
set identity_insert [dbo].[PaymentStatuses] on
merge into [dbo].[PaymentStatuses] as target
using
(
    values
	 (1		,'PS01'		,'Pending'		,getdate())
	,(2		,'PS02'		,'Successful'	,getdate())
	,(3		,'PS03'		,'Failed'		,getdate())
)
as source
(
	 [Id]			
	,[Value]		
	,[Description]
	,[DateCreated]
)
on
(
    source.[Id] = target.[Id]
)
when not matched then
insert
(
	 [Id]			
	,[Value]		
	,[Description]
	,[DateCreated]
)
values
(
	 [Id]			
	,[Value]		
	,[Description]
	,[DateCreated]
)
when matched then
update
set
	 target.[Description]	= source.[Description]
	,target.[Value]			= source.[Value]
when not matched by source then delete;

set identity_insert [dbo].[PaymentStatuses] off




print 'Merge [dbo].[OrderStatuses]'
set identity_insert [dbo].[OrderStatuses] on
merge into [dbo].[OrderStatuses] as target
using
(
    values
	 (1		,'OS01'		,'Pending'		,getdate())
	,(2		,'OS02'		,'Placed'		,getdate())
	,(3		,'OS03'		,'Delivery'		,getdate())
	,(4		,'OS04'		,'Completed'	,getdate())
)
as source
(
	 [Id]			
	,[Value]		
	,[Description]
	,[DateCreated]
)
on
(
    source.[Id] = target.[Id]
)
when not matched then
insert
(
	 [Id]			
	,[Value]		
	,[Description]
	,[DateCreated]
)
values
(
	 [Id]			
	,[Value]		
	,[Description]
	,[DateCreated]
)
when matched then
update
set
	 target.[Description]	= source.[Description]
	,target.[Value]			= source.[Value]
when not matched by source then delete;

set identity_insert [dbo].[OrderStatuses] off



------------------------
-- Test dummy data
------------------------
print 'Merge [dbo].[Categories]'
set identity_insert [dbo].[Categories] on
merge into [dbo].[Categories] as target
using
(
    values
	 (1		,'CA01'		,'Electronics'		,getdate())
	,(2		,'CA02'		,'Home Appliances'	,getdate())
	,(3		,'CA03'		,'Books'			,getdate())
	,(4		,'CA04'		,'Clothing'			,getdate())
)
as source
(
	  [Id]
	 ,[Code]
	 ,[Description]
	 ,[DateCreated]
)
on source.[Id] = target.[Id]
when not matched then
insert 
(
	 [Id]
	,[Code]
	,[Description]
	,[DateCreated]
)
values 
(
	 [Id]
	,[Code]
	,[Description]
	,[DateCreated]
)
when matched then
update 
set 
	 target.[Code]			= source.[Code]
	,target.[Description]	= source.[Description];
set identity_insert [dbo].[Categories] off
go

------------------------
-- Test dummy data
------------------------
print 'Merge [dbo].[Customers]'
set identity_insert [dbo].[Customers] on
merge into [dbo].[Customers] as target
using
(
    values
	 (1		,'Garry'	,'Doe'			,'doe@example.com'		,'1234567890'	, getdate())
	,(2		,'Smith'	,'Johnson'		,'smj@example.com'		,'1234567890'	, getdate())
	,(3		,'Terry'	,'Brown'		,'tbrown@example.com'	,'1234567890'	, getdate())
	,(4		,'Piet'		,'Pompies'		,'pp@example.com'		,'1234567890'	, getdate())
)
as source
(
	  [Id]
	 ,[FirstNames]
	 ,[LastName]
	 ,[Email]
	 ,[PhoneNumber]
	 ,[DateCreated]
)
on source.[Id] = target.[Id]
when not matched then
insert 
(	
	 [Id]
	,[FirstNames]
	,[LastName]
	,[Email]
	,[PhoneNumber]
	,[DateCreated]
)
values 
(
	 [Id]
	,[FirstNames]
	,[LastName]
	,[Email]
	,[PhoneNumber]
	,[DateCreated]
)
when matched then
update 
set 
	 target.[FirstNames] = source.[FirstNames]
	,target.[LastName] = source.[LastName]
	,target.[Email] = source.[Email]
	,target.[PhoneNumber] = source.[PhoneNumber];
set identity_insert [dbo].[Customers] off
go

------------------------
-- Test dummy data
------------------------
print 'Merge [dbo].[Products]'
set identity_insert [dbo].[Products] on
merge into [dbo].[Products] as target
using
(
    values
	 (1		,1, 'Smartphone'	,'Latest Android smartphone'	,599.99		, 50	, getdate())
	,(2		,1, 'Laptop'		,'15 inch business laptop'		,899.99		, 30	, getdate())
	,(3		,2, 'Microwave'		,'700W Microwave Oven'			,120.00		, 20	, getdate())
	,(4		,3, 'Novel'			,'Best-selling fiction'			,15.00		, 100	, getdate())
	,(5		,4, 'T-Shirt'		,'Cotton round neck'			,12.50		, 200	, getdate())
)
as source
(
	  [Id]
	 ,[CategoryId]
	 ,[Name]
	 ,[Description]
	 ,[Price]
	 ,[Stock]
	 ,[DateCreated]
)
on source.[Id] = target.[Id]
when not matched then
insert 
(
	  [Id]
	 ,[CategoryId]
	 ,[Name]
	 ,[Description]
	 ,[Price]
	 ,[Stock]
	 ,[DateCreated]
)
values 
(
	  [Id]
	 ,[CategoryId]
	 ,[Name]
	 ,[Description]
	 ,[Price]
	 ,[Stock]
	 ,[DateCreated]
)
when matched then
update 
set 
	 target.[Name] = source.[Name]
	,target.[Description] = source.[Description]
	,target.[Price] = source.[Price]
	,target.[Stock] = source.[Stock];
set identity_insert [dbo].[Products] off
go


------------------------
-- Test dummy data
------------------------
print 'Merge [dbo].[Orders]'
set identity_insert [dbo].[Orders] on
merge into [dbo].[Orders] as target
using
(
    values
	 (1		,1	,2	,getdate()	,getdate())
	,(2		,2	,3	,getdate()	,getdate())
	,(3		,1	,4	,getdate()	,getdate())
	,(4		,3	,1	,getdate()	,getdate())
)
as source
(
	  [Id]
	 ,[CustomerId]
	 ,[OrderStatusId]
	 ,[Date]
	 ,[DateCreated]
)
on source.[Id] = target.[Id]
when not matched then
insert 
(
	  [Id]
	 ,[CustomerId]
	 ,[OrderStatusId]
	 ,[Date]
	 ,[DateCreated]
)
values 
(
	  [Id]
	 ,[CustomerId]
	 ,[OrderStatusId]
	 ,[Date]
	 ,[DateCreated]
)
when matched then
update 
set 
	 target.[OrderStatusId] = source.[OrderStatusId]
	,target.[CustomerId] = source.[CustomerId];
set identity_insert [dbo].[Orders] off
go

------------------------
-- Test dummy data
------------------------
print 'Merge [dbo].[OrderItems]'
set identity_insert [dbo].[OrderItems] on
merge into [dbo].[OrderItems] as target
using
(
    values
	 (1		,1	,1	,1	,599.99	,getdate()	,getdate())
	,(2		,1	,5	,2	,12.50	,getdate()	,getdate())
	,(3		,2	,2	,1	,899.99	,getdate()	,getdate())
	,(4		,3	,4	,3	,15.00	,getdate()	,getdate())
)
as source
(
	  [Id]
	 ,[OrderId]
	 ,[ProductId]
	 ,[Quantity]
	 ,[Price]
	 ,[Date]
	 ,[DateCreated]
)
on source.[Id] = target.[Id]
when not matched then
insert 
(
	  [Id]
	 ,[OrderId]
	 ,[ProductId]
	 ,[Quantity]
	 ,[Price]
	 ,[Date]
	 ,[DateCreated]
)
values 
(
	  [Id]
	 ,[OrderId]
	 ,[ProductId]
	 ,[Quantity]
	 ,[Price]
	 ,[Date]
	 ,[DateCreated]
)
when matched then
update 
set 
	 target.[Quantity] = source.[Quantity]
	,target.[Price] = source.[Price];
set identity_insert [dbo].[OrderItems] off
go

------------------------
-- Test dummy data
------------------------
print 'Merge [dbo].[Payments]'
set identity_insert [dbo].[Payments] on
merge into [dbo].[Payments] as target
using
(
    values
	 (1	,1	,2	,599.99		,getdate()	,getdate())
	,(2	,1	,2	,25.00		,getdate()	,getdate())
	,(3	,2	,2	,899.99		,getdate()	,getdate())
	,(4	,3	,1	,45.00		,getdate()	,getdate())
)
as source
(
	  [Id]
	 ,[OrderId]
	 ,[PaymentStatusId]
	 ,[Amount]
	 ,[Date]
	 ,[DateCreated]
)
on source.[Id] = target.[Id]
when not matched then
insert 
(
	  [Id]
	 ,[OrderId]
	 ,[PaymentStatusId]
	 ,[Amount]
	 ,[Date]
	 ,[DateCreated]
)
values 
(
	  [Id]
	 ,[OrderId]
	 ,[PaymentStatusId]
	 ,[Amount]
	 ,[Date]
	 ,[DateCreated]
)
when matched then
update 
set 
	 target.[PaymentStatusId] = source.[PaymentStatusId]
	,target.[Amount] = source.[Amount];
set identity_insert [dbo].[Payments] off
go
