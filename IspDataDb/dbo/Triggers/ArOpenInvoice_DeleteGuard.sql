CREATE TRIGGER dbo.ArOpenInvoice_DeleteGuard
ON dbo.ArOpenInvoice
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM deleted d
        WHERE EXISTS (SELECT 1 FROM dbo.CsrOiItem c WHERE c.ArOpenInvoiceIdNo = d.IdNo)
    )
        THROW 51502, 'AR open invoices with collection allocations cannot be deleted.', 1;
END;
GO
