-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	Analysis the given number, and convert
--				it in strig format
-- =============================================
CREATE FUNCTION [dbo].[number_conversation] 
(
	@currency	FLOAT
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	------ Declarations ----------------------
	DECLARE @dot_position			INT
	DECLARE @currency_string		VARCHAR(12)
	DECLARE	@final_outpot_number	VARCHAR(MAX)
	DECLARE	@number_length			INT
	DECLARE @right_number_length	INT
	DECLARE	@fraction_number_length	INT
	DECLARE @right_number			VARCHAR(6)
	DECLARE @fraction_number		VARCHAR(6)
	DECLARE @right_number_simple	INT					-- divided into 3 nubers groups
	DECLARE @right_number_simple_No	INT					-- Number of digits of the simple right digit
	DECLARE @fraction_number_simple	INT					-- divided into 3 nubers groups
	DECLARE @fraction_number_simple_No	INT				-- Number of digits of the simple fraction digit
	DECLARE @right_number_front		NVARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE @fraction_number_front	NVARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE	@right_number_digit		INT
	DECLARE @fraction_number_digit	INT
	DECLARE @temp_1					FLOAT
	DECLARE @right_division			INT
	DECLARE @fraction_division		INT
	DECLARE @right_remainder		INT
	DECLARE @fraction_remainder		INT
	DECLARE @right_steps			INT
	DECLARE	@fraction_steps			INT	
	----------- Initialization --------------
	SET @temp_1 = @currency
	SET @dot_position = dbo.dot_position(@temp_1)
	SET @number_length = LEN(@currency)
	SET @fraction_number_length = @number_length - @dot_position
	SET @right_number_length = @number_length - @fraction_number_length - 1
	SET @currency_string = CAST(@currency AS VARCHAR(12))
	SET @right_number = SUBSTRING(@currency_string,0,@right_number_length)
	SET @fraction_number = SUBSTRING(@currency_string,@dot_position+1,@fraction_number_length)
	SET @right_number_digit = CAST(@right_number AS INT)
	SET	@fraction_number_digit = CAST(@fraction_number_digit AS INT)
	SET @right_division = @right_number_length/3 
	SET @right_remainder = @right_number_length%3
	SET @fraction_division = @fraction_number_length/3
	SET @fraction_remainder = @fraction_number_length%3	
	SET @right_number_front = ''
	SET @fraction_number_front = ''

			----------- divide the right numbers ----------
	IF(@right_remainder = 1)
	BEGIN
		DECLARE @temp01 NVARCHAR(1)
		DECLARE @temp02 NVARCHAR(MAX)
		DECLARE @temp03	INT
		
		SET @temp01 = SUBSTRING(@currency_string,0,1)
		SET @temp02 = SUBSTRING(@currency_string,1,@right_number_length-1)
		SET @temp03 = CAST(@temp01 AS INT)		
		SET @right_number_simple = CAST(@temp02 AS INT)
		SET @right_number_front = dbo.arabic_convert_single(@temp03)
	END
	ELSE IF(@right_remainder = 2)
	BEGIN
		DECLARE @temp04 NVARCHAR(1)
		DECLARE @temp05 NVARCHAR(MAX)
		DECLARE @temp06	INT
		
		SET @temp04 = SUBSTRING(@currency_string,0,2)
		SET @temp05 = SUBSTRING(@currency_string,2,@right_number_length-2)
		SET @temp06 = CAST(@temp04 AS INT)		
		SET @right_number_simple = CAST(@temp05 AS INT)
		SET @right_number_front = dbo.convert_last_two_digits(@temp06)
	END
	ELSE
	BEGIN
		SET @right_number_simple = @currency_string
	END
				----------- divide the right numbers ----------
	IF(@fraction_remainder = 1)
	BEGIN
		DECLARE @temp07 NVARCHAR(1)
		DECLARE @temp08 NVARCHAR(MAX)
		DECLARE @temp09	INT
		
		SET @temp07 = SUBSTRING(@currency_string,0,1)
		SET @temp08 = SUBSTRING(@currency_string,1,@fraction_number_length -1)
		SET @temp09 = CAST(@temp07 AS INT)		
		SET @fraction_number_simple = CAST(@temp08 AS INT)
		SET @fraction_number_simple = dbo.arabic_convert_single(@temp09)
	END
	ELSE IF(@right_remainder = 2)
	BEGIN
		DECLARE @temp10 NVARCHAR(1)
		DECLARE @temp11 NVARCHAR(MAX)
		DECLARE @temp12	INT
		
		SET @temp10 = SUBSTRING(@currency_string,0,2)
		SET @temp11 = SUBSTRING(@currency_string,2,@fraction_number_length -2)
		SET @temp12 = CAST(@temp10 AS INT)		
		SET @fraction_number_simple = CAST(@temp11 AS INT)
		SET @fraction_number_simple = dbo.convert_last_two_digits(@temp12)
	END
	ELSE
	BEGIN
		SET @fraction_number_simple = @currency_string
	END

				------------- Start ---------------------------
	DECLARE @right_string	VARCHAR(MAX)
	DECLARE @fraction_string	VARCHAR(MAX)
	SET @right_string = CAST(@right_number_simple AS VARCHAR(MAX))
	SET @fraction_string = CAST(@fraction_number_simple AS VARCHAR(MAX))
	SET @right_number_simple_No = LEN(@right_string)
	SET @fraction_number_simple_No = LEN(@fraction_string)
	SET @right_steps = 0
	SET @fraction_steps = 0
	IF (@final_outpot_number != '')
		SET @final_outpot_number = @right_number_front + ' و '
	
				------------ Brgin Iteration -----------------
		------------ Right Numbers -------------------
--	WHILE(@right_steps < (@right_number_simple_No/3) - 1)
--	BEGIN
--		DECLARE @temp13		VARCHAR(1)
--		DECLARE	@temp14		VARCHAR(2)
--		DECLARE @temp15		VARCHAR(MAX)
--		SET @temp13 = SUBSTRING(CAST(@right_number_simple AS VARCHAR(MAX)), (@right_steps * 3),1)
--		SET @temp14 = SUBSTRING(CAST(@right_number_simple AS VARCHAR(MAX)), (@right_steps * 3) +1 ,2)
--		SET @temp15 = dbo.arabic_convert_single(CAST(@temp13 AS INT)) + ' و ' + dbo.convert_last_two_digits(CAST(@temp14 AS INT))
--		SET @final_outpot_number = @final_outpot_number + ' و ' + @temp15
--	END
	
	




	RETURN @final_outpot_number
END