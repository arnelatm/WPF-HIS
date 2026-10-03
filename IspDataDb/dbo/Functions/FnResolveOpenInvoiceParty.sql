CREATE FUNCTION dbo.FnResolveOpenInvoiceParty
(
    @PayIdNo int,
    @PartyType char(1),
    @HeaderPartyIdNo int
)
RETURNS int
AS
BEGIN
    DECLARE @PartyIdNo int;

    -- PayIdNo is a Contact key, never a Customer/Supplier key.
    -- Header fallback is only for historical lines with no selected contact.
    IF ISNULL(@PayIdNo, 0) = 0
        SET @PartyIdNo = @HeaderPartyIdNo;
    ELSE
        SELECT @PartyIdNo = CSEIdNo
        FROM dbo.Contact
        WHERE IdNo = @PayIdNo AND CSECode = @PartyType;

    IF @PartyType = 'C' AND EXISTS (SELECT 1 FROM dbo.Customer WHERE IdNo = @PartyIdNo)
        RETURN @PartyIdNo;
    IF @PartyType = 'S' AND EXISTS (SELECT 1 FROM dbo.Supplier WHERE IdNo = @PartyIdNo)
        RETURN @PartyIdNo;

    RETURN NULL;
END;
GO
