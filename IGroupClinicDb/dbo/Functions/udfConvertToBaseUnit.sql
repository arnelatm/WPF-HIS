-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[udfConvertToBaseUnit]
(
	-- Add the parameters for the function here
	@p1 decimal(20,9),
	@p2 int,
	@p3 int,
	@p4 int
)
RETURNS decimal(12,4)
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result decimal(12,4)

	-- Add the T-SQL statements to compute the return value here
	if @p2 = @p3
		Set @Result = Round(Round(@p1*@p4,0)/@p4,4)
	else if @p2 < @p3
		Set @Result = Round(Round(@p1*@p3*@p4,0)/@p4,4)
	else
		Set @Result = Round(Round((@p1/@p3)*@p3,0) / @p3,4)
	-- Return the result of the function
	RETURN @Result

END