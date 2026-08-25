CREATE PROCEDURE [dbo].[InitializeMonthlyCloseChecklist]
    @FiscalYear int,
    @FiscalMonth int
AS
BEGIN
    SET NOCOUNT ON;
    IF @FiscalYear NOT BETWEEN 2000 AND 2099 THROW 52301, 'FiscalYear must be between 2000 and 2099.', 1;
    IF @FiscalMonth NOT BETWEEN 1 AND 12 THROW 52302, 'FiscalMonth must be between 1 and 12.', 1;

    INSERT INTO dbo.MonthlyClosePeriod (FiscalYear, FiscalMonth)
    SELECT @FiscalYear, @FiscalMonth
    WHERE NOT EXISTS (SELECT 1 FROM dbo.MonthlyClosePeriod WHERE FiscalYear = @FiscalYear AND FiscalMonth = @FiscalMonth);

    INSERT INTO dbo.MonthlyCloseChecklist (FiscalYear, FiscalMonth, ChecklistCode)
    SELECT @FiscalYear, @FiscalMonth, v.ChecklistCode
    FROM (VALUES ('AR_RECONCILED'), ('AP_RECONCILED'), ('BANK_RECONCILED'), ('INVENTORY_RECONCILED'), ('VAT_RECONCILED'), ('PAYROLL_REVIEWED'), ('ADJUSTMENTS_APPROVED'), ('TRIAL_BALANCE_REVIEWED')) v(ChecklistCode)
    WHERE NOT EXISTS (SELECT 1 FROM dbo.MonthlyCloseChecklist c WHERE c.FiscalYear = @FiscalYear AND c.FiscalMonth = @FiscalMonth AND c.ChecklistCode = v.ChecklistCode);

    SELECT p.FiscalYear, p.FiscalMonth, p.Status, c.ChecklistCode, c.Completed, c.CompletedBy, c.CompletedAt, c.Notes
    FROM dbo.MonthlyClosePeriod p INNER JOIN dbo.MonthlyCloseChecklist c ON c.FiscalYear = p.FiscalYear AND c.FiscalMonth = p.FiscalMonth
    WHERE p.FiscalYear = @FiscalYear AND p.FiscalMonth = @FiscalMonth ORDER BY c.ChecklistCode;
END;
