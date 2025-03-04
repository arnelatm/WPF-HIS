
/****** Object:  StoredProcedure [dbo].[ThtEventsGetPatWTeeth]    Script Date: 02/10/2015 10:51:33 PM ******/
 
-- =============================================
CREATE PROCEDURE [dbo].[InvoicesWorksName]
	-- Add the parameters for the stored procedure here
	@OrderID as int 
	 
AS
BEGIN
	 


DECLARE @Names nvarchar(max) 
SELECT @Names =  COALESCe(@Names + ', ',  '') +  ISNULL(a.name, '') FROM A1_OrderWorks as a where a.OrderID  = @OrderID and a.Net > 0 
SELECT @Names 

END