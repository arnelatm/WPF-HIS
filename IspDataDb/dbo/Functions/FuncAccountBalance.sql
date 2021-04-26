


CREATE FUNCTION [dbo].[FuncAccountBalance] (@IdNo Integer,@EndDate Date)
RETURNS Decimal(16,2)
Begin
	Declare @Balance Decimal(16,2)
	Set @Balance = (SELECT Sum(Debit-Credit) FROM  FuncGlAccountStatement3(@EndDate,@EndDate,@IdNo,@IdNo) )
	return @Balance
End