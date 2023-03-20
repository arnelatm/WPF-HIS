

-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	convert the given number to string
-- =============================================
CREATE FUNCTION [dbo].[numberToArabicWord]
(
	@inputNumber	 Decimal(25,10)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
	----------------Declaration--------------
	DECLARE @inputNumber_string		VARCHAR(MAX)
	DECLARE	@final_output_number		VARCHAR(MAX)
	DECLARE	@number_length				INT
	DECLARE @right_number_length		INT
	DECLARE	@fraction_number_length		INT
	DECLARE @right_number				VARCHAR(MAX)
	DECLARE @fraction_number			VARCHAR(MAX)
	DECLARE @right_number_simple		VARCHAR(MAX)		-- divided into 3 numbers groups
	DECLARE @right_number_simple_no		INT					-- Number of digits of the simple right digit
	DECLARE @fraction_number_simple		VARCHAR(MAX)		-- divided into 3 numbers groups
	DECLARE @fraction_number_simple_no	INT					-- Number of digits of the simple fraction digit
	DECLARE @right_number_front			VARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE @fraction_number_front		VARCHAR(MAX)		-- The first number on the most left of the number
	DECLARE	@right_number_digit			INT
	DECLARE @fraction_number_digit		INT
	DECLARE @right_division				INT
	DECLARE @fraction_division			INT
	DECLARE @right_remainder			INT
	DECLARE @fraction_remainder			INT
	DECLARE @right_steps				INT
	DECLARE	@fraction_steps				INT
	DECLARE @test						VARCHAR(MAX)		-- Test Value to retrieve it in any time
	DECLARE @fractionText				VARCHAR(100)
	DECLARE @wholeNumber                BIGINT
	DECLARE @decimalPart				Decimal(25,10)
	-----------------Initialization----------------

	SET @inputNumber_string = CONVERT(VARCHAR(MAX) ,@inputNumber)	-- Initialize the input to a variable to be used during the function
	SET @number_length = LEN(@inputNumber)							-- The length of th input number
		
	SET @wholeNumber = Cast(@inputNumber as bigint)
	SET @decimalPart = @inputNumber - @wholeNumber
	IF @wholeNumber > 0 
		BEGIN
			-- whole number
			SET @right_number_length = @number_length
			SET @right_number = @inputNumber_string
			SET @fraction_number = 0
			SET @fraction_number_length = 0
			
			SET @right_division = @right_number_length/3 
			SET @right_remainder = @right_number_length%3
			SET @fraction_division = 0
			SET @fraction_remainder = 0
		END
	ELSE 
		BEGIN
			Set @fractionText = dbo.udfConvertDecimalPartToFraction(@inputNumber)
		END	
	
	
	----------- divide the right numbers ----------
	IF(@right_remainder = 1)
	BEGIN
		DECLARE @temp01 VARCHAR(1)
		DECLARE @temp02 VARCHAR(MAX)
		DECLARE @temp03	VARCHAR(MAX)
		
		SET @temp01 = SUBSTRING(@right_number,1,1)
		SET @temp02 = SUBSTRING(@right_number,2,@right_number_length-1)
		SET @temp03 = dbo.put_zero(@temp01,(3*@right_division))
		SET @right_number_simple = @temp02 
		SET @right_number_front = dbo.arabic_convert_single(@temp01) 
		IF(@right_division = 1)
		BEGIN
			SET @right_number_front = @right_number_front + ' الاف و '
		END
		ELSE IF(@right_division = 2)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليون و '
		END
		ELSE IF(@right_division = 3)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليار و ' 
		END
	END
	ELSE IF(@right_remainder = 2)
	BEGIN
		DECLARE @temp04 VARCHAR(2)
		DECLARE @temp05 VARCHAR(MAX)
		DECLARE @temp06	INT
		
		SET @temp04 = SUBSTRING(@right_number,1,2)
		SET @temp05 = SUBSTRING(@right_number,3,@right_number_length-2)
		--SET @temp06 = CAST(@temp04 AS INT)		
		SET @right_number_simple = @temp05
		SET @right_number_front = dbo.convert_last_two_digits(@temp04) --+  ' الف و '
		IF(@right_division = 1)
		BEGIN
			SET @right_number_front = @right_number_front + ' الف و '
		END
		ELSE IF(@right_division = 2)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليون و '
		END
		ELSE IF(@right_division = 3)
		BEGIN
			SET @right_number_front = @right_number_front + ' مليار و ' 
		END
	END
	ELSE
	BEGIN
		SET @right_number_simple = @right_number
	END
	
	IF(@right_number_simple = '' OR @right_number_simple = NULL)
	BEGIN
		SET @right_number_simple = @right_number
	END
	
	SET @right_number_simple_no = LEN(@right_number_simple)
				----------- Divide The Fraction Numbers ----------
		IF(@fraction_remainder = 1)
		BEGIN
			DECLARE @temp07 VARCHAR(1)
			DECLARE @temp08 VARCHAR(MAX)
			DECLARE @temp09	INT
			
			SET @temp07 = SUBSTRING(@fraction_number,1,1)
			SET @temp08 = SUBSTRING(@fraction_number,2,@fraction_number_length -1)
			--SET @temp09 = CAST(@temp07 AS INT)		
			SET @fraction_number_simple = @temp08 
			
			SET @fraction_number_front = dbo.arabic_convert_single(@temp07)
		END
		ELSE IF(@fraction_remainder = 2)
		BEGIN
			DECLARE @temp10 VARCHAR(2)
			DECLARE @temp11 VARCHAR(MAX)
			DECLARE @temp12	INT
			
			SET @temp10 = SUBSTRING(@fraction_number,1,2)
			SET @temp11 = SUBSTRING(@fraction_number,3,@fraction_number_length -2)
			--SET @temp12 = CAST(@temp10 AS INT)		
			SET @fraction_number_simple = @temp11 
			SET @fraction_number_front = dbo.convert_last_two_digits(@temp10)
		END
		ELSE
		BEGIN
			SET @fraction_number_simple = @fraction_number
		END
	

	IF(@fraction_number_simple = '' OR @fraction_number_simple = NULL)
	BEGIN
		SET @fraction_number_simple = @fraction_number
	END
	
	SET @fraction_number_simple_no = LEN(@fraction_number_simple)
		---------------- Last Number ---------------------
	SET @final_output_number = @right_number_front
	DECLARE @i INT
	SET @i = 0
	WHILE(@i < @right_division AND @right_division > 0)
	BEGIN
		DECLARE @temp15		VARCHAR(MAX)
		DECLARE @temp16		VARCHAR(MAX)
		SET @temp15 = SUBSTRING(@right_number_simple, (3 * @i)+1 ,3)
		SET @temp16 = dbo.convert_handreds(@temp15)
		SET @final_output_number = @final_output_number + @temp16 + ' '
		--SET @test = (@i-@right_division)
		IF((@right_division-@i-1)=1)
		BEGIN			
			SET @final_output_number = @final_output_number + ' الف '
		END
		ELSE IF(((@right_division-@i-1) = 2))
		BEGIN
			SET @final_output_number = @final_output_number + ' مليون '
		END
		ELSE IF(((@right_division-@i-1) = 3))
		BEGIN
			SET @final_output_number = @final_output_number + ' مليار '
		END
		SET @i = @i + 1
	END
	--SET @final_output_number = @final_output_number + ' ريال '
	SET @final_output_number = @final_output_number 
				-------- Piastres --------
	IF(@fraction_number_simple !='0' OR @fraction_number_simple != NULL)
	BEGIN
		DECLARE @temp20		VARCHAR(MAX)
		SET @temp20 = dbo.convert_last_two_digits(@fraction_number_simple)
		IF(@temp20 IS NULL)
			SET @temp20 = dbo.arabic_convert_single(SUBSTRING(@fraction_number_simple,2,1))
		SET @final_output_number = @final_output_number +  ' و '  + @temp20 + ' المئات‎ '
	END
	--SET @test = @right_number
	------------------------------- Special Case -----------------------------------------------
	IF(@right_remainder = 0 )																----
	BEGIN																					----				
		SET @final_output_number =''
		DECLARE @j INT																		----
		SET @j = 0																			----
		WHILE(@j < @right_division)															----
		BEGIN																				----
			DECLARE @temp22		VARCHAR(MAX)												----
			DECLARE @temp23		VARCHAR(MAX)												----
			SET @temp22 = SUBSTRING(@right_number, (3 * @j)+1 ,3)							----
			SET @test = @temp22
			SET @temp23 = dbo.convert_handreds(@temp22)										----
			SET @final_output_number = @final_output_number + @temp23 + ' '					----
			--SET @test = (@j-@right_division)												----
			IF((@right_division-@j-1)=1)													----
			BEGIN																			----
				SET @final_output_number = @final_output_number + ' الف '					----
			END																				----
			ELSE IF(((@right_division-@j-1) = 2))											----
			BEGIN																			----	
				SET @final_output_number = @final_output_number + ' مليون '					----
			END																				----
			ELSE IF(((@right_division-@j-1) = 3))											----
			BEGIN																			----	
				SET @final_output_number = @final_output_number + ' مليار '					----
			END		
			SET @j = @j + 1																	----
			--SET @final_output_number = 'Second Check'										----
			--SET @test = @j													     		----
		END																					----
		SET @final_output_number = @final_output_number 									----
																							----
		IF(@fraction_number_simple !=0 OR @fraction_number_simple != NULL)					----
		BEGIN																				----
			DECLARE @temp25		VARCHAR(MAX)												----
			SET @temp25 = dbo.convert_last_two_digits(@fraction_number_simple)				----
			SET @final_output_number = @final_output_number +  ' و '  + @temp25 + ' هللة‎ '	----
		END																					----
	END																						----
	--------------------------------------------------------------------------------------------
	-- Return the result of the function
	
	RETURN	@final_output_number   --@test	--@final_output_number  --CAST(@right_division AS VARCHAR(MAX)) + ' ' + CAST(@right_remainder AS VARCHAR(MAX)) + ' ' + CAST(@fraction_division AS VARCHAR(MAX)) + ' ' +	CAST(@fraction_remainder AS VARCHAR(MAX))

END