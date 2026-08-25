CREATE PROCEDURE dbo.ValidateAccountReconciliation
    @ReconciliationIdNo int,
    @RequirePostedCleared bit = 0
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @AccountIdNo int;
    DECLARE @ReconciliationDate date;
    DECLARE @Balance decimal(19, 4);
    DECLARE @TotalDebitsNotCleared decimal(19, 4);
    DECLARE @TotalCreditsNotCleared decimal(19, 4);
    DECLARE @GlSystemBalance decimal(19, 4);
    DECLARE @Difference decimal(19, 4);

    SELECT
        @AccountIdNo = AccountIdNo,
        @ReconciliationDate = ReconciliationDate,
        @Balance = CONVERT(decimal(19, 4), Balance)
    FROM dbo.AccountReconciliation
    WHERE IdNo = @ReconciliationIdNo;

    IF @AccountIdNo IS NULL
        THROW 51531, 'Account reconciliation was not found.', 1;

    IF EXISTS (
        SELECT 1
        FROM dbo.AccountReconciliationItem
        WHERE AccountReconciliationIdNo = @ReconciliationIdNo
        GROUP BY JournalCode, JournalItemIdNo
        HAVING COUNT(*) > 1
    )
        THROW 51532, 'The reconciliation contains duplicate journal lines.', 1;

    IF EXISTS (
        SELECT 1
        FROM dbo.AccountReconciliationItem i
        LEFT JOIN dbo.GlReconciliation_View g
          ON g.JournalCode = i.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS
         AND g.IdNo = i.JournalItemIdNo
        WHERE i.AccountReconciliationIdNo = @ReconciliationIdNo
          AND (
                g.IdNo IS NULL
                OR ISNULL(g.AccountIdNo, -1) <> @AccountIdNo
                OR g.TransactionDate IS NULL
                OR g.TransactionDate > @ReconciliationDate
              )
    )
        THROW 51533, 'The reconciliation contains an invalid, cancelled, missing, or out-of-period journal line.', 1;

    IF EXISTS (
        SELECT 1
        FROM dbo.AccountReconciliationItem i
        INNER JOIN dbo.Reconciled r
          ON r.JournalCode = i.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS
         AND r.JournalItemIdNo = i.JournalItemIdNo
        WHERE i.AccountReconciliationIdNo = @ReconciliationIdNo
          AND r.ReconciliationIdNo <> @ReconciliationIdNo
    )
        THROW 51534, 'The reconciliation contains a journal line already reserved by another reconciliation.', 1;

    SELECT
        @TotalDebitsNotCleared = COALESCE(SUM(CASE WHEN ISNULL(i.Cleared, 0) = 0 THEN CONVERT(decimal(19, 4), ISNULL(g.Debit, 0)) ELSE 0 END), 0),
        @TotalCreditsNotCleared = COALESCE(SUM(CASE WHEN ISNULL(i.Cleared, 0) = 0 THEN CONVERT(decimal(19, 4), ISNULL(g.Credit, 0)) ELSE 0 END), 0)
    FROM dbo.AccountReconciliationItem i
    INNER JOIN dbo.GlReconciliation_View g
      ON g.JournalCode = i.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS
     AND g.IdNo = i.JournalItemIdNo
    WHERE i.AccountReconciliationIdNo = @ReconciliationIdNo;

    SET @GlSystemBalance = COALESCE(CONVERT(decimal(19, 4), dbo.FnGetAccountBalance(@AccountIdNo, @ReconciliationDate)), 0);
    SET @Difference = COALESCE(@Balance, 0) + @TotalDebitsNotCleared - @TotalCreditsNotCleared - @GlSystemBalance;

    IF ABS(@Difference) > CONVERT(decimal(19, 4), 0.01)
        THROW 51535, 'The reconciliation difference is not zero within the allowed tolerance.', 1;

    IF @RequirePostedCleared = 1 AND EXISTS (
        SELECT 1
        FROM dbo.AccountReconciliationItem i
        LEFT JOIN dbo.GlReconciliation_View g
          ON g.JournalCode = i.JournalCode COLLATE SQL_Latin1_General_CP1_CI_AS
         AND g.IdNo = i.JournalItemIdNo
        WHERE i.AccountReconciliationIdNo = @ReconciliationIdNo
          AND ISNULL(i.Cleared, 0) = 1
          AND (g.IdNo IS NULL OR ISNULL(g.Posted, 0) <> 1)
    )
        THROW 51536, 'All cleared transactions must be posted before finalization.', 1;
END;
