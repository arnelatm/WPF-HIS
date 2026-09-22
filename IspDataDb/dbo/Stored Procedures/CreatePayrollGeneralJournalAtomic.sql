CREATE PROCEDURE [dbo].[CreatePayrollGeneralJournalAtomic]
    @PayrollIdNo SMALLINT,
    @Notes NVARCHAR(300),
    @JournalIdNo INT OUTPUT,
    @AlreadyExists BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    SET @JournalIdNo = 0;
    SET @AlreadyExists = 0;

    BEGIN TRANSACTION;
    BEGIN TRY
        DECLARE @TransactionDate DATE;
        DECLARE @LastGeneralJournalDate DATE;
        DECLARE @ClosedPeriodDate DATE;
        DECLARE @AccruedAccountIdNo SMALLINT;
        DECLARE @TotalDebit MONEY;
        DECLARE @TotalCredit MONEY;
        DECLARE @NetPay MONEY;
        DECLARE @ReportEarnings MONEY;
        DECLARE @ReportDeductions MONEY;
        DECLARE @ReportNetPay MONEY;

        SELECT @TransactionDate = EndDate
        FROM dbo.Payroll WITH (UPDLOCK, HOLDLOCK)
        WHERE IdNo = @PayrollIdNo;

        IF @TransactionDate IS NULL
            THROW 51801, 'Payroll record was not found or has no end date.', 1;

        SELECT @JournalIdNo = GeneralJournalIdNo
        FROM dbo.PayrollGeneralJournal WITH (UPDLOCK, HOLDLOCK)
        WHERE PayrollIdNo = @PayrollIdNo;

        IF @JournalIdNo > 0
        BEGIN
            SET @AlreadyExists = 1;
            COMMIT TRANSACTION;
            RETURN;
        END;

        SELECT @LastGeneralJournalDate = MAX(LastPostingDate)
        FROM dbo.LastPosting
        WHERE TransactionName = 'General Journal';

        SELECT @ClosedPeriodDate = MAX(LastPostingDate)
        FROM dbo.LastPosting
        WHERE TransactionName = 'Closed Period';

        IF @LastGeneralJournalDate IS NULL
            THROW 51802, 'The General Journal posting date is not configured.', 1;

        IF @TransactionDate < @LastGeneralJournalDate
            THROW 51803, 'Payroll date is outside the valid General Journal date range.', 1;

        IF @TransactionDate > CONVERT(DATE, GETDATE())
            THROW 51804, 'A General Journal cannot be created for a future date.', 1;

        IF @ClosedPeriodDate IS NOT NULL AND @TransactionDate <= @ClosedPeriodDate
            THROW 51805, 'Payroll date is in a closed accounting period.', 1;

        IF NULLIF(LTRIM(RTRIM(@Notes)), N'') IS NULL
            THROW 51806, 'Payroll General Journal notes are required.', 1;

        SELECT @AccruedAccountIdNo = IdNo
        FROM dbo.Account
        WHERE AccountCode = '213'
          AND DetailAccount = 1
          AND ISNULL(Active, 1) = 1;

        IF @AccruedAccountIdNo IS NULL
            THROW 51807, 'Active detail account 213 (Accrued Salaries & Wages) was not found.', 1;

        CREATE TABLE #PayrollLines (
            PostAccountIdNo SMALLINT NULL,
            Credit MONEY NOT NULL,
            Debit MONEY NOT NULL,
            EmployeeIdNo INT NULL,
            ContactIdNo INT NULL,
            RevCostCenterIdNo SMALLINT NULL,
            PostingType CHAR(1) NOT NULL
        );

        ;WITH PayrollComponents AS (
            SELECT
                p.PostAccountIdNo,
                CONVERT(CHAR(1), 'E') AS PostingType,
                SUM(ISNULL(p.TotalEarning, 0)) AS ComponentAmount,
                p.EmployeeIdNo,
                p.ContactIdNo,
                p.RevCostCenterIdNo,
                p.PayGroupIdNo,
                p.PayGroupName,
                p.EmployeeName
            FROM dbo.PayrollReportPosting_View AS p
            WHERE p.PayrollIdNo = @PayrollIdNo
            GROUP BY p.PayGroupIdNo, p.PayGroupName, p.RevCostCenterIdNo,
                     p.EmployeeIdNo, p.ContactIdNo, p.EmployeeName, p.PostAccountIdNo
            HAVING SUM(ISNULL(p.TotalEarning, 0)) <> 0

            UNION ALL

            SELECT
                p.PostAccountIdNo,
                CONVERT(CHAR(1), 'D') AS PostingType,
                SUM(ISNULL(p.TotalDeduction, 0)) AS ComponentAmount,
                p.EmployeeIdNo,
                p.ContactIdNo,
                p.RevCostCenterIdNo,
                p.PayGroupIdNo,
                p.PayGroupName,
                p.EmployeeName
            FROM dbo.PayrollReportPosting_View AS p
            WHERE p.PayrollIdNo = @PayrollIdNo
            GROUP BY p.PayGroupIdNo, p.PayGroupName, p.RevCostCenterIdNo,
                     p.EmployeeIdNo, p.ContactIdNo, p.EmployeeName, p.PostAccountIdNo
            HAVING SUM(ISNULL(p.TotalDeduction, 0)) <> 0
        )
        INSERT INTO #PayrollLines (PostAccountIdNo, Credit, Debit, EmployeeIdNo, ContactIdNo, RevCostCenterIdNo, PostingType)
        SELECT
            p.PostAccountIdNo,
            CASE
                WHEN p.PostingType = 'D' AND p.ComponentAmount > 0 THEN p.ComponentAmount
                WHEN p.PostingType = 'E' AND p.ComponentAmount < 0 THEN ABS(p.ComponentAmount)
                ELSE 0
            END,
            CASE
                WHEN p.PostingType = 'E' AND p.ComponentAmount > 0 THEN p.ComponentAmount
                WHEN p.PostingType = 'D' AND p.ComponentAmount < 0 THEN ABS(p.ComponentAmount)
                ELSE 0
            END,
            p.EmployeeIdNo,
            p.ContactIdNo,
            ISNULL(p.RevCostCenterIdNo, 0),
            p.PostingType
        FROM PayrollComponents AS p
        WHERE p.ComponentAmount <> 0;

        IF NOT EXISTS (
            SELECT 1
            FROM #PayrollLines
            WHERE Debit <> 0 OR Credit <> 0
        )
            THROW 51808, 'This payroll has no non-zero employee posting lines.', 1;

        IF EXISTS (
            SELECT 1
            FROM #PayrollLines
            WHERE (Debit <> 0 OR Credit <> 0)
              AND ContactIdNo IS NULL
        )
            THROW 51814, 'A payroll employee is missing its Contact mapping.', 1;

        IF EXISTS (
            SELECT 1
            FROM #PayrollLines AS p
            LEFT JOIN dbo.Account AS a ON a.IdNo = p.PostAccountIdNo
            WHERE (p.Debit <> 0 OR p.Credit <> 0)
              AND (p.PostAccountIdNo IS NULL OR p.PostAccountIdNo = 0
                   OR a.IdNo IS NULL OR ISNULL(a.DetailAccount, 0) = 0 OR ISNULL(a.Active, 1) = 0)
        )
            THROW 51809, 'A payroll earning or deduction has no active detail posting account.', 1;

        IF EXISTS (
            SELECT 1
            FROM #PayrollLines AS p
            INNER JOIN dbo.Account AS a ON a.IdNo = p.PostAccountIdNo
            WHERE (p.Debit <> 0 OR p.Credit <> 0)
              AND a.SpecialAccount IN ('AP', 'AR', 'AS', 'CA', 'PD', 'RD')
        )
            THROW 51810, 'A payroll posting account is restricted in General Journal entries.', 1;

        IF EXISTS (
            SELECT 1
            FROM dbo.Account
            WHERE IdNo = @AccruedAccountIdNo
              AND SpecialAccount IN ('AP', 'AR', 'AS', 'CA', 'PD', 'RD', 'EL')
        )
            THROW 51811, 'Account 213 is restricted in General Journal entries.', 1;

        CREATE TABLE #Items (
            AccountIdNo SMALLINT NOT NULL,
            Credit MONEY NOT NULL,
            Debit MONEY NOT NULL,
            Notes NVARCHAR(300) NULL,
            PayIdNo INT NULL,
            RevCostCenterIdNo SMALLINT NULL,
            Sequence SMALLINT NOT NULL
        );

        INSERT INTO #Items (AccountIdNo, Credit, Debit, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
        SELECT
            p.PostAccountIdNo,
            p.Credit,
            p.Debit,
            NULL,
            p.ContactIdNo,
            ISNULL(p.RevCostCenterIdNo, 0),
            CONVERT(SMALLINT, ROW_NUMBER() OVER (ORDER BY p.EmployeeIdNo, p.PostAccountIdNo, p.RevCostCenterIdNo, p.PostingType))
        FROM #PayrollLines AS p
        WHERE p.Debit <> 0 OR p.Credit <> 0;

        SELECT
            @TotalDebit = ISNULL(SUM(Debit), 0),
            @TotalCredit = ISNULL(SUM(Credit), 0)
        FROM #Items;

        SELECT
            @ReportEarnings = ISNULL(SUM(TotalEarning), 0),
            @ReportDeductions = ISNULL(SUM(TotalDeduction), 0),
            @ReportNetPay = ISNULL(SUM(TotalAmount), 0)
        FROM dbo.PayrollReportPosting_View
        WHERE PayrollIdNo = @PayrollIdNo;

        IF ABS(@TotalDebit - @ReportEarnings) > 0.00005
           OR ABS(@TotalCredit - @ReportDeductions) > 0.00005
            THROW 51815, 'Payroll General Journal earning and deduction lines do not match the payroll report.', 1;

        SET @NetPay = @TotalDebit - @TotalCredit;

        IF ABS(@NetPay - @ReportNetPay) > 0.00005
            THROW 51816, 'Payroll General Journal net pay does not match the payroll report.', 1;

        IF @NetPay < 0
            THROW 51812, 'Payroll net pay is negative; review the payroll deductions before creating a journal.', 1;

        IF @NetPay > 0
            INSERT INTO #Items (AccountIdNo, Credit, Debit, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
            VALUES (@AccruedAccountIdNo, @NetPay, 0, NULL, NULL, 0, CONVERT(SMALLINT, (SELECT COUNT(*) + 1 FROM #Items)));

        IF ABS((SELECT ISNULL(SUM(Debit), 0) FROM #Items) - (SELECT ISNULL(SUM(Credit), 0) FROM #Items)) > 0.00005
            THROW 51813, 'Payroll General Journal details are not balanced.', 1;

        INSERT INTO dbo.GeneralJournal (TransactionDate, ReferenceNo, Notes, Approved, Posted, ClosingJournal, Cancelled)
        VALUES (@TransactionDate, NULL, @Notes, 0, 0, 0, 0);

        SET @JournalIdNo = CONVERT(INT, SCOPE_IDENTITY());

        INSERT INTO dbo.GeneralJournalItem (AccountIdNo, Credit, Debit, JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence)
        SELECT AccountIdNo, Credit, Debit, @JournalIdNo, Notes, PayIdNo, RevCostCenterIdNo, Sequence
        FROM #Items;

        INSERT INTO dbo.PayrollGeneralJournal (PayrollIdNo, GeneralJournalIdNo)
        VALUES (@PayrollIdNo, @JournalIdNo);

        DECLARE @SeriesName VARCHAR(20) = 'GL' + CONVERT(VARCHAR(4), YEAR(@TransactionDate)) + RIGHT('0' + CONVERT(VARCHAR(2), MONTH(@TransactionDate)), 2);
        DECLARE @Prefix VARCHAR(10);
        DECLARE @MaxLength INT;
        DECLARE @SeriesValue INT;

        SELECT @SeriesValue = Value, @Prefix = Prefix, @MaxLength = MaxLength
        FROM dbo.Series WITH (UPDLOCK, HOLDLOCK)
        WHERE SeriesName = @SeriesName;

        IF @Prefix IS NULL
        BEGIN
            SET @Prefix = RIGHT('0' + CONVERT(VARCHAR(2), MONTH(@TransactionDate)), 2) + '-';
            SET @MaxLength = 3;
            SET @SeriesValue = 0;
            INSERT INTO dbo.Series (SeriesName, Value, MaxLength, Prefix, Description)
            VALUES (@SeriesName, 0, @MaxLength, @Prefix, 'GL Series for ' + @SeriesName);
        END;

        SET @SeriesValue = @SeriesValue + 1;
        UPDATE dbo.Series SET Value = @SeriesValue WHERE SeriesName = @SeriesName;
        UPDATE dbo.GeneralJournal
        SET ReferenceNo = @Prefix + RIGHT(REPLICATE('0', @MaxLength) + CONVERT(VARCHAR(20), @SeriesValue), @MaxLength)
        WHERE IdNo = @JournalIdNo;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        SET @JournalIdNo = 0;
        THROW;
    END CATCH;
END;
GO
