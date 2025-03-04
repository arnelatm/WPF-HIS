 
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE  [dbo].[SetCustIDToMinWithDelete]
 
AS
BEGIN	
delete from Customers 
 DBCC CHECKIDENT ('CUSTOMERS',RESEED,0)  
	 END