CREATE PROCEDURE dbo.DeleteAccountReconciliationAtomic
    @ReconciliationIdNo int
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (
        SELECT 1 FROM dbo.AccountReconciliation
        WHERE IdNo = @ReconciliationIdNo
    )
        RETURN 1;

    IF EXISTS (
        SELECT 1 FROM dbo.AccountReconciliation
        WHERE IdNo = @ReconciliationIdNo
          AND (ISNULL(Posted, 0) = 1 OR ISNULL(Status, 'Draft') <> 'Draft')
    )
        THROW 51500, 'Completed or finalized reconciliations cannot be deleted. Reopen the review first.', 1;

    BEGIN TRANSACTION;
    BEGIN TRY
        DELETE FROM dbo.Reconciled
        WHERE ReconciliationIdNo = @ReconciliationIdNo;

        DELETE FROM dbo.AccountReconciliationItem
        WHERE AccountReconciliationIdNo = @ReconciliationIdNo;

        DELETE FROM dbo.AccountReconciliation
        WHERE IdNo = @ReconciliationIdNo;

        IF @@ROWCOUNT <> 1
            THROW 51501, 'Account reconciliation deletion failed.', 1;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
