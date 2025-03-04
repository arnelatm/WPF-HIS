

CREATE FUNCTION [dbo].[GetWorkStoreRequestIncomeCount]
(
@Code nvarchar(255), @Store int
)
RETURNS dec(18,2)
AS
BEGIN

Declare @Result decimal(18,2);	
Select @Result = Sum(TransferedCount) From A1_StoreRequest 
Left Join A1_StoreRequestWorks on A1_StoreRequest.ID = A1_StoreRequestWorks.OrderID
Where OrderStatu = 4 and (A1_StoreRequest.type = 0 or A1_StoreRequest.type = 1) 
 and Code = @Code And (@Store = 0 or ToStore = @Store )
Return @Result;

END