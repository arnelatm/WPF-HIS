CREATE PROCEDURE dbo.FinalizeAccountReconciliation
    @ReconciliationIdNo int,
    @FinalizedBy nvarchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @Status varchar(20), @Posted bit;

        SELECT @Status = ISNULL(Status, 'Draft'),
               @Posted = ISNULL(Posted, 0)
        FROM dbo.AccountReconciliation WITH (UPDLOCK, HOLDLOCK)
        WHERE IdNo = @ReconciliationIdNo;

        IF @Status IS NULL
            THROW 51524, 'Account reconciliation was not found.', 1;

        IF @Posted = 1 OR @Status = 'Finalized'
            THROW 51525, 'The reconciliation is already finalized.', 1;

        IF @Status <> 'ReviewCompleted'
            THROW 51526, 'Complete the pre-post review before finalizing.', 1;

        EXEC dbo.ValidateAccountReconciliation
            @ReconciliationIdNo = @ReconciliationIdNo,
            @RequirePostedCleared = 1;

        -- Review completion normally created these reservations. This also
        -- repairs older ReviewCompleted rows created before this workflow.
        INSERT INTO dbo.Reconciled (JournalCode, JournalItemIdNo, ReconciliationIdNo)
        SELECT i.JournalCode, i.JournalItemIdNo, i.AccountReconciliationIdNo
        FROM dbo.AccountReconciliationItem AS i
        WHERE i.AccountReconciliationIdNo = @ReconciliationIdNo
          AND ISNULL(i.Cleared, 0) = 1
          AND NOT EXISTS (
              SELECT 1
              FROM dbo.Reconciled AS existing WITH (UPDLOCK, HOLDLOCK)
              WHERE existing.JournalCode = i.JournalCode
                AND existing.JournalItemIdNo = i.JournalItemIdNo
          );

        UPDATE dbo.AccountReconciliation
           SET Status = 'Finalized',
               Posted = 1,
               FinalizedBy = NULLIF(@FinalizedBy, N''),
               FinalizedAt = GETDATE()
         WHERE IdNo = @ReconciliationIdNo
           AND ISNULL(Posted, 0) = 0
           AND Status = 'ReviewCompleted';

        IF @@ROWCOUNT <> 1
            THROW 51529, 'The reconciliation could not be finalized.', 1;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        IF ERROR_NUMBER() IN (2601, 2627)
            THROW 51528, 'One or more cleared transactions are already reserved by another reconciliation.', 1;
        THROW;
    END CATCH;
END;
