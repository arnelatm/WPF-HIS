 
create proc [dbo].SetCustIDToMax

as
begin
Declare @MaxCust int
select @MaxCust = max(custId) from Customers
 DBCC CHECKIDENT ('CUSTOMERS',RESEED,@MaxCust)  
end