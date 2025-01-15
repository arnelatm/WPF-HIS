CREATE FUNCTION [dbo].[ConvertDCAFToothNo](@Tooth NVARCHAR(1000))
RETURNS nvarchar(1000)
AS
BEGIN 

IF @Tooth is null return null;

DECLARE @NewTooth TABLE (Id NVARCHAR(1000) NULL);
DECLARE @list NVARCHAR(1000)
DECLARE @pos INT;
DECLARE @name NVARCHAR(1000)

SET @list = @Tooth + ';';

WHILE CHARINDEX(';', @list) > 0
BEGIN
 SELECT @pos  = CHARINDEX(';', @list)  
 SELECT @name = SUBSTRING(@list, 1, @pos-1)
 
 SET @name = CASE 
	WHEN @name = 't1' THEN '18'
	WHEN @name = 't2' THEN '17'
	WHEN @name = 't3' THEN '16'
	WHEN @name = 't4' THEN '15'
	WHEN @name = 't5' THEN '14'
	WHEN @name = 't6' THEN '13'
	WHEN @name = 't7' THEN '12'
	WHEN @name = 't8' THEN '11'
	
	WHEN @name = 't9' THEN '21'
	WHEN @name = 't10' THEN '22'
	WHEN @name = 't11' THEN '23'
	WHEN @name = 't12' THEN '24'
	WHEN @name = 't13' THEN '25'
	WHEN @name = 't14' THEN '26'
	WHEN @name = 't15' THEN '27'
	WHEN @name = 't16' THEN '28'
	
	WHEN @name = 't17' THEN '38'
	WHEN @name = 't18' THEN '37'
	WHEN @name = 't19' THEN '36'
	WHEN @name = 't20' THEN '35'
	WHEN @name = 't21' THEN '34'
	WHEN @name = 't22' THEN '33'
	WHEN @name = 't23' THEN '32'
	WHEN @name = 't24' THEN '31'
	
	WHEN @name = 't25' THEN '41'
	WHEN @name = 't26' THEN '42'
	WHEN @name = 't27' THEN '43'
	WHEN @name = 't28' THEN '44'
	WHEN @name = 't29' THEN '45'
	WHEN @name = 't30' THEN '46'
	WHEN @name = 't31' THEN '47'
	WHEN @name = 't32' THEN '48'

	WHEN @name = 's1' THEN '55'
	WHEN @name = 's2' THEN '54'
	WHEN @name = 's3' THEN '53'
	WHEN @name = 's4' THEN '52'
	WHEN @name = 's5' THEN '51'
	WHEN @name = 's6' THEN '61'
	WHEN @name = 's7' THEN '62'
	WHEN @name = 's8' THEN '63'
	WHEN @name = 's9' THEN '64'
	WHEN @name = 's10' THEN '65'
	WHEN @name = 's11' THEN '75'
	WHEN @name = 's12' THEN '74'
	WHEN @name = 's13' THEN '73'
	WHEN @name = 's14' THEN '72'
	WHEN @name = 's15' THEN '71'
	WHEN @name = 's16' THEN '81'
	WHEN @name = 's17' THEN '82'
	WHEN @name = 's18' THEN '83'
	WHEN @name = 's19' THEN '84'
	WHEN @name = 's20' THEN '85'	
 ELSE @name END;

 INSERT INTO @NewTooth 
 SELECT @name

 SELECT @list = SUBSTRING(@list, @pos+1, LEN(@list)-@pos)
 END


Return STUFF((SELECT ', ' + COALESCE(CONVERT(NVARCHAR(MAX), Id), 'NULL') 
              FROM @NewTooth
              ORDER BY Id
              FOR XML PATH(''), TYPE).value('.','NVARCHAR(MAX)')
              , 1, 1, '') ;
END