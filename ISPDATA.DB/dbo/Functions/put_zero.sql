-- =============================================
-- Author:		Wael Refaat
-- Create date: 8-8-2007
-- Description:	take two number and return a number consists of
--				the first digit + Zeros as the count of the other digit
-- =============================================
CREATE FUNCTION [dbo].[put_zero] 
(
	@digit	VARCHAR(MAX),
	@NOZ	INT
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	-- Declarations
	DECLARE @len				INT
	SET @len = @NOZ+1
	DECLARE @digit_as_string	NVARCHAR(10)
	DECLARE	@string_length		INT
	DECLARE @count				INT
	DECLARE @final_number		INT

	-- Initialization
	SET @string_length = LEN(@digit_as_string)
	SET @count = 1
	SET	@digit_as_string = @digit

	WHILE(@count <= @NOZ)
	BEGIN
		SET @digit_as_string = @digit_as_string + '0'
		SET @count = @count + 1
	END
	SET @final_number = @digit_as_string
	
	RETURN 	@final_number
END


