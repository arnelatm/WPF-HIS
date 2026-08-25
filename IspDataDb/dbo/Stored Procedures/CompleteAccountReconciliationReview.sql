CREATE PROCEDURE dbo.CompleteAccountReconciliationReview
    @ReconciliationIdNo int,
    @ReviewedBy nvarchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @Status varchar(20), @Posted bit;

        -- Lock the parent while cleared journal lines are reserved. The
        -- unique key on Reconciled prevents the same line being reserved by
        -- two reconciliations at the same time.
        SELECT @Status = ISNULL(Status, 'Draft'),
               @Posted = ISNULL(Posted, 0)
        FROM dbo.AccountReconciliation WITH (UPDLOCK, HOLDLOCK)
        WHERE IdNo = @ReconciliationIdNo;

        IF @Status IS NULL
            THROW 51520, 'Account reconciliation was not found.', 1;

        IF @Posted = 1 OR @Status = 'Finalized'
            THROW 51521, 'Finalized reconciliations cannot be reviewed again.', 1;

        EXEC dbo.ValidateAccountReconciliation
            @ReconciliationIdNo = @ReconciliationIdNo,
            @RequirePostedCleared = 0;

        -- Reconciled is the line-reservation table. A ReviewCompleted parent
        -- owns these rows temporarily; finalization keeps them and changes
        -- the parent to Finalized.
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

        IF @Status = 'Draft'
        BEGIN
            UPDATE dbo.AccountReconciliation
               SET Status = 'ReviewCompleted',
                   ReviewedBy = NULLIF(@ReviewedBy, N''),
                   ReviewedAt = GETDATE()
             WHERE IdNo = @ReconciliationIdNo
               AND ISNULL(Posted, 0) = 0
               AND ISNULL(Status, 'Draft') = 'Draft';

            IF @@ROWCOUNT <> 1
                THROW 51522, 'The reconciliation review could not be completed.', 1;
        END
        ELSE IF @Status <> 'ReviewCompleted'
            THROW 51523, 'Only draft reconciliations can be moved to review completed.', 1;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        IF ERROR_NUMBER() IN (2601, 2627)
            THROW 51524, 'One or more cleared transactions are already reserved by another reconciliation.', 1;
        THROW;
    END CATCH;
END;
