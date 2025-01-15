

CREATE FUNCTION [dbo].[GetWorkSaleCount]
(
@Code nvarchar(255), @Store int
)
RETURNS dec(18,2)
AS
BEGIN

Declare @Result decimal(18,2);	
Select @Result = Sum(A1_OrderWorks.Count) From A1_Invoces 
Left Join A1_OrderWorks on A1_Invoces.ID = A1_OrderWorks.OrderID
Where A1_OrderWorks.WorkID = @Code And (@Store = 0 or Store = @Store )
and  (A1_OrderWorks.IsService = 0 or A1_OrderWorks.IsService is Null)
Return @Result;

END