 
CREATE proc [dbo].[SetCustIDToZero]
as
begin
 DBCC CHECKIDENT ('CUSTOMERS',RESEED,0)  
end