CREATE FUNCTION dbo.udf_ConvertDecimalPartToFraction
(
     @NumToConvert DECIMAL(25, 10)
)

RETURNS VARCHAR(75) AS


BEGIN
	DECLARE @output VARCHAR(75)
	DECLARE @wholenumber INT
	DECLARE @DECIMAL DECIMAL (25, 10)
	DECLARE @num INT
	DECLARE @denom INT
	DECLARE @multiple INT
	SET @wholenumber = CAST(@NumToConvert AS INT)
	SET @decimal = @NumToConvert - @wholenumber
	SET @multiple = CAST( '1' + REPLICATE('0',LEN(CAST(CAST(REVERSE(SUBSTRING(CAST(@decimal AS VARCHAR),
							CHARINDEX('.',CAST(@decimal AS VARCHAR))+1, LEN(CAST(@decimal AS VARCHAR)))) AS INT) AS VARCHAR(10))))
					AS INT)
	SET @num = @multiple * @decimal
	SET @denom = @multiple
	IF @num > 0
		BEGIN
			--calculate the greatest common factor
			--AS long AS both numbers are even numbers, keep reducing them.
			WHILE ((@num % 2) + (@denom % 2)) = 0
				BEGIN
					SET @denom = @denom / 2       
					SET @num = @num / 2
				END
			--continue reducing numerator and denominator until one
			--is no longer evenly divisible by 5
		    WHILE ((@num % 5) + (@denom % 5)) = 0
				BEGIN
					SET @denom = @denom / 5
					SET @num = @num / 5
				END
			SET @output = CONVERT(VARCHAR, @num) + '/' + CONVERT(VARCHAR, @denom)
		END
	ELSE
		BEGIN
			SET @output = ''
		END
	RETURN (@output)
END