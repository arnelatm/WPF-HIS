

Create FUNCTION [dbo].[GetWorkPurchaseCount]
(
@Code nvarchar(255), @Store int
)
RETURNS dec(18,2)
AS
BEGIN

Declare @Result decimal(18,2);	
Select @Result = Sum(Count) From A1_PurchaseInvoces 
Left Join A1_PurchaseInvocesWorks on A1_PurchaseInvoces.ID = A1_PurchaseInvocesWorks.OrderID
Where WorkID = @Code And (@Store = 0 or StoreID = @Store )
Return @Result;

END