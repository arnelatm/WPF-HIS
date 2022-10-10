




CREATE FUNCTION [dbo].[FnGetAccountBalance](@IdNo Integer,@EndDate Date)
RETURNS Decimal(16,2)
Begin
	Declare @Balance Decimal(16,2)
	Declare @EndAcctCode Varchar(10)
	Set @EndAcctCode = (Select AccountCode from Account where IdNo = @IdNo)
	Set @Balance =  (Select Sum(debit-Credit) from [fnGetAcctActivityStatement](@EndDate,@EndDate,@EndAcctCode,@EndAcctCode))
	return @Balance
End
