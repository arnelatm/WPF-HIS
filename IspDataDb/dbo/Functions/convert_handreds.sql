CREATE FUNCTION [dbo].[convert_handreds] 
(
	@number		VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @number_string		VARCHAR(MAX)
	DECLARE @hundreds			INT
	DECLARE	@hundreds_string	VARCHAR(MAX)
	DECLARE @tens				INT
	DECLARE	@tens_string		VARCHAR(MAX)
	DECLARE @final_value		VARCHAR(MAX)
	DECLARE @temp01				VARCHAR(1)
	DECLARE @temp02				VARCHAR(2)
	
	SET @number_string = @number
	SET	@temp01 = SUBSTRING(@number_string,1,1)
	SET @temp02 = SUBSTRING(@number_string,2,2)
	SET @tens = CAST(@temp02 AS INT)
		
	------------ Special Case --------------------------------------------
	IF(LEN(@number_string) = 2)
	BEGIN
		SET @final_value = dbo.convert_last_two_digits(@number_string)
		GOTO FINAL
	END
	ELSE IF(LEN(@number_string) = 1)
	BEGIN
		SET @final_value = dbo.arabic_convert_single(@number_string)
		GOTO FINAL
	END
	----------------------------------------------------------------------
	ELSE IF(SUBSTRING(@number_string,2,1) = '0')
		BEGIN
			IF(SUBSTRING(@number_string,3,1) = '0')
			BEGIN
				SET @hundreds = dbo.put_zero(@temp01,2)
				SET	@hundreds_string = dbo.arabic_convert_single(@hundreds) + ' '
				SET @tens_string = ''
			END
			ELSE
			BEGIN
				SET @tens_string = [dbo].arabic_convert_single(CAST(SUBSTRING(@number_string,3,1) AS INT))
				SET @hundreds = dbo.put_zero(@temp01,2)
				SET	@hundreds_string = dbo.arabic_convert_single(@hundreds) 
			END
		END
	ELSE
		BEGIN
			SET @tens_string = dbo.convert_last_two_digits(@tens)
			SET @hundreds = dbo.put_zero(@temp01,2)
			SET	@hundreds_string = dbo.arabic_convert_single(@hundreds) 
		END
	IF(@tens =0 )
		SET @final_value = @hundreds_string --+ ' و ' + @tens_string
	ELSE
		SET @final_value = @hundreds_string + ' و ' + @tens_string

	FINAL:
	RETURN @final_value 

END




