-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	return the position of '.' on a float number
-- =============================================
CREATE FUNCTION [dbo].[dot_position] 
(
	@number		VARCHAR(50)
)
RETURNS INT
AS
BEGIN
	DECLARE @position	INT
	DECLARE	@found		BIT
	DECLARE	@number_string	VARCHAR(50)
	DECLARE @steps		INT
	
	SET @position = -1
	SET @steps = 0
	SET @found = 0
	SET @number_string = @number 
	
	WHILE(@steps<=50 AND (@found = 0))
	BEGIN
		DECLARE @temp VARCHAR(1)
		SET @temp = SUBSTRING(@number_string,@steps,1)
		IF(@temp = '.')
		BEGIN
			SET @position = @steps
			SET @found = 1
		END
		ELSE
		BEGIN
			SET @steps = @steps + 1
		END
	END
	
	RETURN @position

END