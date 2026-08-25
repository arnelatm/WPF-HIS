CREATE TRIGGER dbo.ApOpenInvoice_DeleteGuard
ON dbo.ApOpenInvoice
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM deleted d
        WHERE EXISTS (SELECT 1 FROM dbo.CdOiItem c WHERE c.ApOpenInvoiceIdNo = d.IdNo)
           OR EXISTS (SELECT 1 FROM dbo.CkOiItem k WHERE k.ApOpenInvoiceIdNo = d.IdNo)
           OR EXISTS (SELECT 1 FROM dbo.PcOiItem p WHERE p.ApOpenInvoiceIdNo = d.IdNo)
    )
        THROW 51501, 'AP open invoices with payment allocations cannot be deleted.', 1;
END;
GO
