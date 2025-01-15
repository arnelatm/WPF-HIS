 
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE  [dbo].[SetA1_WorksIDToMinWithDelete]
 
AS
BEGIN	
delete from A1_Works  
 DBCC CHECKIDENT ('A1_Works',RESEED,0)  
	 END