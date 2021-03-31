DECLARE @start_date AS DATE
DECLARE @end_date AS DATE
DECLARE @curr_date AS DATE
DECLARE @column_name AS CHAR(10)

SET @start_date = '2016-01-02'
SET @end_date = '2016-12-31'
SET @curr_date = @start_date

CREATE TABLE [dbo].[TableB](
	[IdNo] [int] NULLON [PRIMARY]
GO
WHILE @curr_date < @end_date

BEGIN
    DECLARE @SQL NVARCHAR(MAX)

    SET @curr_date = DATEADD(DD, 7, @curr_date)


    SET @SQL = 'ALTER TABLE TableB ADD [' + CAST(@curr_date AS VARCHAR(10)) + ']  FLOAT'

    --PRINT @SQL
    EXECUTE (@SQL)
END
