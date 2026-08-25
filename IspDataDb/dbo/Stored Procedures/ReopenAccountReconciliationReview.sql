CREATE PROCEDURE dbo.ReopenAccountReconciliationReview
    @ReconciliationIdNo int
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @Status varchar(20), @Posted bit;

        SELECT @Status = Status,
               @Posted = ISNULL(Posted, 0)
        FROM dbo.AccountReconciliation WITH (UPDLOCK, HOLDLOCK)
        WHERE IdNo = @ReconciliationIdNo;

        IF @Status IS NULL
            THROW 51525, 'Account reconciliation was not found.', 1;

        IF @Posted = 1 OR @Status <> 'ReviewCompleted'
            THROW 51526, 'Only a completed, unfinalized review can be reopened.', 1;

        -- Release this reconciliation's pending line reservations.
        DELETE FROM dbo.Reconciled
        WHERE ReconciliationIdNo = @ReconciliationIdNo;

        UPDATE dbo.AccountReconciliation
           SET Status = 'Draft',
               ReviewedBy = NULL,
               ReviewedAt = NULL
         WHERE IdNo = @ReconciliationIdNo
           AND ISNULL(Posted, 0) = 0
           AND Status = 'ReviewCompleted';

        IF @@ROWCOUNT <> 1
            THROW 51527, 'The reconciliation review could not be reopened.', 1;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
