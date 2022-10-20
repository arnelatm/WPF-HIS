CREATE FUNCTION [dbo].[uFnStringToBase64]
(
    @InputString VARCHAR(MAX)
)
RETURNS VARCHAR(MAX)
AS
BEGIN
    RETURN (
		SELECT
			CAST(N'' AS XML).value(
                  'xs:base64Binary(xs:hexBinary(sql:column("bin")))'
                , 'VARCHAR(MAX)'
            )
        FROM (
            SELECT CAST(@InputString AS VARBINARY(MAX)) AS bin
        ) AS RetVal
    )
END;