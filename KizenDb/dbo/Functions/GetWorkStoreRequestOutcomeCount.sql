

CREATE FUNCTION [dbo].[GetWorkStoreRequestOutcomeCount]
(
@Code nvarchar(255), @Store int
)
RETURNS dec(18,2)
AS
BEGIN

Declare @Result decimal(18,2);	
Select @Result = Sum(TransferedCount) From A1_StoreRequest 
Left Join A1_StoreRequestWorks on A1_StoreRequest.ID = A1_StoreRequestWorks.OrderID
Where OrderStatu = 4
 and Code = @Code And (@Store = 0 or FromStore = @Store )
Return @Result;

END