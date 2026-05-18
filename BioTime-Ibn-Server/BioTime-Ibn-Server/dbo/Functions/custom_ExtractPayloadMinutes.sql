CREATE FUNCTION dbo.custom_ExtractPayloadMinutes
(
    @payload NVARCHAR(MAX),
    @section NVARCHAR(100)
)
RETURNS DECIMAL(18,2)
AS
BEGIN
    DECLARE @sectionPattern NVARCHAR(200);
    DECLARE @minutesPattern NVARCHAR(50);
    DECLARE @sectionPos INT;
    DECLARE @minutesPos INT;
    DECLARE @colonPos INT;
    DECLARE @endPos INT;
    DECLARE @valueText NVARCHAR(100);
    DECLARE @result DECIMAL(18,2);

    SET @result = 0;
    SET @sectionPattern = '"' + @section + '"';
    SET @minutesPattern = '"minutes"';

    IF @payload IS NULL OR @section IS NULL
        RETURN 0;

    SET @sectionPos = CHARINDEX(@sectionPattern, @payload);

    IF @sectionPos = 0
        RETURN 0;

    SET @minutesPos = CHARINDEX(@minutesPattern, @payload, @sectionPos);

    IF @minutesPos = 0
        RETURN 0;

    SET @colonPos = CHARINDEX(':', @payload, @minutesPos);

    IF @colonPos = 0
        RETURN 0;

    SET @endPos = CHARINDEX('}', @payload, @colonPos);

    IF @endPos = 0
        SET @endPos = LEN(@payload) + 1;

    SET @valueText = LTRIM(RTRIM(SUBSTRING(@payload, @colonPos + 1, @endPos - @colonPos - 1)));

    IF RIGHT(@valueText, 1) = ','
        SET @valueText = LEFT(@valueText, LEN(@valueText) - 1);

    SET @result = TRY_CAST(@valueText AS DECIMAL(18,2));

    RETURN ISNULL(@result, 0);
END;
