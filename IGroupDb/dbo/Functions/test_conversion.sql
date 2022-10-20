-- =============================================
-- Author:		Wael Refaat
-- Create date: 13-8-2007
-- Description:	Test conversion
-- =============================================
CREATE FUNCTION [dbo].[test_conversion] 
(
	@no1	INT
)
RETURNS  VARCHAR(MAX)
AS
BEGIN
	DECLARE		@no2	VARCHAR(MAX)
	DECLARE		@temp1	VARCHAR(1)
	DECLARE		@temp2	VARCHAR(1)
	--SET @no2 = CAST(@no1 AS VARCHAR(MAX))  (working)
	--SET @no2 = @no1	(working)
	SET @no2 = CONVERT(VARCHAR(2),@no1)
	SET @temp1 = (SELECT DISTINCT SUBSTRING(@no2,1,1) FROM [currencies])
	SET @temp2 = SUBSTRING(@no2,2,1)
	SET @no2 = @temp1 + ' test ' + @temp2
	RETURN @no2
END