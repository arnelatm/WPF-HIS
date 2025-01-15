
/****** Object:  StoredProcedure [dbo].[ThtEventsGetPatWTeeth]    Script Date: 02/10/2015 10:51:33 PM ******/
 
-- =============================================
Create FUNCTION [dbo].[GetInvoicePaidByDate]	
	(@OrderID as int ,
	@StartDate as DateTime,
	@EndDate as DateTime)
RETURNS dec(18,2)
AS
BEGIN
	 


DECLARE @Result as decimal(18, 2)
SELECT @Result =  Sum(a.Value) FROM A1_payments as a where a.OrderID  = @OrderID and a.Date between @StartDate and @EndDate
Return @Result ;

END