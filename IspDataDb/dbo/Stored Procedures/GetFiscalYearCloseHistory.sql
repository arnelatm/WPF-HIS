CREATE PROCEDURE [dbo].[GetFiscalYearCloseHistory]
    @FiscalYear int = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT RunId,
        FiscalYear,
        FiscalYearStart,
        FiscalYearEnd,
        OpeningYear,
        Status,
        FiscalResult,
        FiscalResultAmount,
        IncomeSummaryAccountIdNo,
        RetainedEarningsAccountIdNo,
        IncomeClosingJournalIdNo,
        RetainedEarningsJournalIdNo,
        OpeningRows,
        OpeningDebit,
        OpeningCredit,
        JanuaryBeginningInventory,
        DecemberEndingInventory,
        InventoryNetEffect,
        LegacyMonthsNormalized,
        ApplicationUser,
        SqlLogin,
        ApprovalNotes,
        FinalizedAt,
        ServerName,
        DatabaseName
    FROM dbo.FiscalYearCloseRun
    WHERE @FiscalYear IS NULL OR FiscalYear = @FiscalYear
    ORDER BY FiscalYear DESC, FinalizedAt DESC;
END;
