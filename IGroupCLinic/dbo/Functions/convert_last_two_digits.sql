-- =============================================
-- Author:		Wael Refaat
-- Create date: 2007-08-07 -- last modification 13-8-2007
-- Description:	Decompose the last two digits and 
--				returns the right value for it
-- =============================================
CREATE FUNCTION [dbo].[convert_last_two_digits] 
(
	@decimal VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @decimal_string	VARCHAR(MAX)
	DECLARE @inirts			VARCHAR(MAX)
	DECLARE	@tens			VARCHAR(MAX)
	DECLARE	@final_value	VARCHAR(MAX)
	
	SET @decimal_string = @decimal
	SET	@tens =	SUBSTRING(@decimal_string,1,1)
	SET @inirts = SUBSTRING(@decimal_string,2,1)	
	
	IF(LEN(@decimal) = 1)
		BEGIN
			SET @final_value = dbo.arabic_convert_single(@decimal)
		END
	ELSE
	BEGIN
		IF(@tens = 1)
			BEGIN
				DECLARE @temp1	VARCHAR(MAX)
				SET @temp1 = dbo.arabic_convert_single(@decimal)
				SET @final_value = @temp1
			END
		ELSE IF (@tens >= 2 AND @tens<=9)
			BEGIN
				DECLARE @tens_int		INT
				DECLARE @tens_int_2		INT
				DECLARE @temp_2	VARCHAR(MAX)
				SET @tens_int = CAST(@tens AS INT)
				SET @tens_int_2 = [dbo].put_zero(@tens_int,1)
				
				IF(@inirts != '0')
					SET @temp_2 = dbo.arabic_convert_single(@inirts) + ' و ' + dbo.arabic_convert_single(@tens_int_2)
				ELSE
					SET @temp_2 = dbo.arabic_convert_single(@tens_int_2)

	--			DECLARE	@temp_3	VARCHAR(MAX)
	--			DECLARE @temp_4	INT
	--			SET @temp_4 = CAST(@tens AS INT)
	--			SET @tens = [dbo].put_zero(@temp_4,1)	
			
				SET @final_value = @temp_2
				
			END
		END

	RETURN @final_value
END





