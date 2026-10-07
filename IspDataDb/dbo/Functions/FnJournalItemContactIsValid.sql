CREATE FUNCTION [dbo].[FnJournalItemContactIsValid]
(
    @AccountIdNo int,
    @PayIdNo int,
    @Debit money,
    @Credit money
)
RETURNS bit
AS
BEGIN
    DECLARE @RequiredType char(1);

    IF @Debit = 0 AND @Credit = 0 RETURN 1;

    SELECT @RequiredType =
        CASE
            WHEN SpecialAccount IN ('AP', 'AS') THEN 'S'
            WHEN SpecialAccount IN ('AR', 'CA') THEN 'C'
            WHEN SpecialAccount = 'EL' THEN 'E'
        END
    FROM dbo.Account
    WHERE IdNo = @AccountIdNo;

    IF @RequiredType IS NULL RETURN 1;
    IF ISNULL(@PayIdNo, 0) <= 0 RETURN 0;

    IF EXISTS (
        SELECT 1
        FROM dbo.Contact AS c
        WHERE c.IdNo = @PayIdNo
          AND c.CSECode = @RequiredType
          AND ((@RequiredType = 'S' AND EXISTS (SELECT 1 FROM dbo.Supplier AS s WHERE s.IdNo = c.CSEIdNo))
            OR (@RequiredType = 'C' AND EXISTS (SELECT 1 FROM dbo.Customer AS cu WHERE cu.IdNo = c.CSEIdNo))
            OR (@RequiredType = 'E' AND EXISTS (SELECT 1 FROM dbo.Employee AS e WHERE e.IdNo = c.CSEIdNo)))
    ) RETURN 1;

    RETURN 0;
END;
GO
