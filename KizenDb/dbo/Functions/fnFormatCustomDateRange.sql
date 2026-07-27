CREATE FUNCTION dbo.fnFormatCustomDateRange 
(
    @startDate DATE,
    @endDate DATE
)
RETURNS VARCHAR(100)
AS
BEGIN
    DECLARE @result VARCHAR(100)
    DECLARE @lastDayOfStartMonth INT

    -- Calculate last day of start month manually (SQL 2008 workaround for EOMONTH)
    SET @lastDayOfStartMonth = DAY(DATEADD(DAY, -DAY(DATEADD(MONTH, 1, @startDate)), DATEADD(MONTH, 1, @startDate)))

    -- Format based on date relationship
    SET @result = 
        CASE
            -- Case 1: Same month/year and full month
            WHEN MONTH(@startDate) = MONTH(@endDate) AND 
                 YEAR(@startDate) = YEAR(@endDate) AND
                 DAY(@startDate) = 1 AND 
                 DAY(@endDate) = @lastDayOfStartMonth
            THEN LEFT(DATENAME(month, @startDate), 3) + ' ' + CAST(YEAR(@startDate) AS VARCHAR)

            -- Case 2: Same month/year, partial span
            WHEN MONTH(@startDate) = MONTH(@endDate) AND 
                 YEAR(@startDate) = YEAR(@endDate)
            THEN CAST(DAY(@startDate) AS VARCHAR) + '-' + CAST(DAY(@endDate) AS VARCHAR) + ' ' +
                 DATENAME(month, @startDate) + ' ' + CAST(YEAR(@startDate) AS VARCHAR)

            -- Case 3: Different months, same year
            WHEN YEAR(@startDate) = YEAR(@endDate)
            THEN CAST(DAY(@startDate) AS VARCHAR) + ' ' + LEFT(DATENAME(month, @startDate), 3) + '-' +
                 CAST(DAY(@endDate) AS VARCHAR) + ' ' + LEFT(DATENAME(month, @endDate), 3) + ' ' +
                 CAST(YEAR(@startDate) AS VARCHAR)

            -- Case 4: Different years
            ELSE CAST(DAY(@startDate) AS VARCHAR) + ' ' + LEFT(DATENAME(month, @startDate), 3) + ' ' +
                 CAST(YEAR(@startDate) AS VARCHAR) + ' - ' +
                 CAST(DAY(@endDate) AS VARCHAR) + ' ' + LEFT(DATENAME(month, @endDate), 3) + ' ' +
                 CAST(YEAR(@endDate) AS VARCHAR)
        END

    RETURN @result
END