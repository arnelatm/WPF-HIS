
CREATE FUNCTION [dbo].[arabic_convert_single] 
(
	@currency	VARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE	@number		NVARCHAR(MAX)
	SET @number =(SELECT [number_string] 
	FROM [currencies] 
	WHERE [number]=@currency)
	
	RETURN @number	
END