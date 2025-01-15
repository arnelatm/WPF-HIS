CREATE FUNCTION [dbo].[GetPurchaseInvocesReturn]
(
@Id int
)
RETURNS dec(18,2)
AS
BEGIN

Declare @Result decimal(18,2);	
Select @Result = Sum(Count) From A1_PurchaseInvocesWorks 
Where ReturnID = @Id
Return -@Result;

END