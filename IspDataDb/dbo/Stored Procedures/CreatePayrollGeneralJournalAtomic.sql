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

        -- Check the source rows before the reporting view groups them. Use the same
        -- pay-group account and default-account fallback as the posting view.
        CREATE TABLE #PostingSetupIssues (
            EmployeeIdNo INT NULL,
            EmployeeName NVARCHAR(100) NOT NULL,
            PayElementName NVARCHAR(100) NOT NULL,
            Issue NVARCHAR(100) NOT NULL
        );

        INSERT INTO #PostingSetupIssues (EmployeeIdNo, EmployeeName, PayElementName, Issue)
        SELECT DISTINCT pd.EmployeeIdNo,
            COALESCE(NULLIF(e.EmployeeName, ''), N'Employee #' + COALESCE(CONVERT(NVARCHAR(20), pd.EmployeeIdNo), N'?')),
            COALESCE(NULLIF(pe.PayElementName, ''), N'Pay element #' + COALESCE(CONVERT(NVARCHAR(20), ppe.PayElementIdNo), N'?')),
            problem.Issue
        FROM dbo.PayrollDetail AS pd
        LEFT JOIN dbo.Employee AS e ON e.IdNo = pd.EmployeeIdNo
        LEFT JOIN dbo.PayrollPayElement AS ppe ON ppe.PayrollDetailIdNo = pd.IdNo AND ISNULL(ppe.Amount, 0) <> 0
        LEFT JOIN dbo.PayElement AS pe ON pe.IdNo = ppe.PayElementIdNo
        LEFT JOIN dbo.Department AS d ON d.IdNo = e.DepartmentIdNo
        LEFT JOIN dbo.PayGroup AS pg ON pg.IdNo = e.PayGroupIdNo
        LEFT JOIN dbo.RevCostCenter AS rc
            ON rc.IdNo = COALESCE(NULLIF(e.RevCostCenterIdNo, 0), NULLIF(pg.RevCostCenterIdNo, 0), NULLIF(d.RevCostCenterIdNo, 0), 0)
        OUTER APPLY (
            SELECT COUNT(*) AS MappingCount, MAX(pea.AccountIdNo) AS AccountIdNo
            FROM dbo.PayElementAccount AS pea
            WHERE pea.PayElementIdNo = pe.IdNo AND pea.PayGroupIdNo = e.PayGroupIdNo
        ) AS mapping
        OUTER APPLY (
            SELECT COUNT(*) AS ContactCount
            FROM dbo.Contact AS c
            WHERE c.CSEIdNo = e.IdNo AND c.CSECode = 'E'
        ) AS contactMapping
        CROSS APPLY (
            SELECT CASE WHEN pe.UsePayGroups = 1
                        THEN ISNULL(mapping.AccountIdNo, pe.AccountIdNo)
                        ELSE pe.AccountIdNo END AS AccountIdNo
        ) AS posting
        LEFT JOIN dbo.Account AS a
            ON a.IdNo = posting.AccountIdNo
        CROSS APPLY (VALUES
            (N'employee record missing', CASE WHEN e.IdNo IS NULL THEN 1 ELSE 0 END),
            (N'pay element missing', CASE WHEN ppe.IdNo IS NOT NULL AND pe.IdNo IS NULL THEN 1 ELSE 0 END),
            (N'pay element kind missing', CASE WHEN pe.IdNo IS NOT NULL AND (pe.PayElementKind IS NULL OR pe.PayElementKind NOT IN ('E', 'D')) THEN 1 ELSE 0 END),
            (N'pay group missing', CASE WHEN pe.UsePayGroups = 1 AND pg.IdNo IS NULL THEN 1 ELSE 0 END),
            (N'multiple pay-group account mappings', CASE WHEN pe.UsePayGroups = 1 AND mapping.MappingCount > 1 THEN 1 ELSE 0 END),
            (N'posting account missing from pay group and default setup', CASE WHEN pe.IdNo IS NOT NULL AND (posting.AccountIdNo IS NULL OR posting.AccountIdNo = 0) THEN 1 ELSE 0 END),
            (N'posting account inactive or not a detail account', CASE WHEN pe.IdNo IS NOT NULL AND a.IdNo IS NOT NULL AND (ISNULL(a.Active, 1) = 0 OR ISNULL(a.DetailAccount, 0) = 0) THEN 1 ELSE 0 END),
            (N'posting account not found', CASE WHEN pe.IdNo IS NOT NULL AND a.IdNo IS NULL AND posting.AccountIdNo > 0 THEN 1 ELSE 0 END),
            (N'posting account restricted in General Journal', CASE WHEN a.SpecialAccount IN ('AP', 'AR', 'AS', 'CA', 'PD', 'RD') THEN 1 ELSE 0 END),
            (N'revenue cost center missing or invalid', CASE WHEN e.IdNo IS NOT NULL AND (rc.IdNo IS NULL OR rc.IdNo = 0) THEN 1 ELSE 0 END),
            (N'employee Contact mapping missing', CASE WHEN e.IdNo IS NOT NULL AND contactMapping.ContactCount = 0 THEN 1 ELSE 0 END),
            (N'multiple employee Contact mappings', CASE WHEN contactMapping.ContactCount > 1 THEN 1 ELSE 0 END)
        ) AS problem(Issue, IsInvalid)
        WHERE pd.PayrollIdNo = @PayrollIdNo
          AND ppe.IdNo IS NOT NULL
          AND problem.IsInvalid = 1;

        IF EXISTS (SELECT 1 FROM #PostingSetupIssues)
        BEGIN
            DECLARE @IssueCount INT = (SELECT COUNT(DISTINCT ISNULL(EmployeeIdNo, -1)) FROM #PostingSetupIssues);
            DECLARE @TotalIssues INT = (SELECT COUNT(*) FROM #PostingSetupIssues);
            DECLARE @IssueDetails NVARCHAR(MAX);
            DECLARE @IssueMessage NVARCHAR(2048);

            SELECT @IssueDetails = STUFF((
                SELECT CHAR(13) + CHAR(10) + N'- ' + LEFT(x.EmployeeName, 60)
                    + N' / ' + LEFT(x.PayElementName, 45) + N': ' + LEFT(x.Issue, 70)
                FROM (SELECT TOP (10) EmployeeName, PayElementName, Issue
                      FROM #PostingSetupIssues
                      ORDER BY EmployeeName, PayElementName, Issue) AS x
                FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)'), 1, 2, N'');

            SET @IssueMessage = N'Payroll posting setup is incomplete for '
                + CONVERT(NVARCHAR(20), @IssueCount) + N' employee(s).'
                + CHAR(13) + CHAR(10) + @IssueDetails
                + CASE WHEN @TotalIssues > 10 THEN CHAR(13) + CHAR(10) + N'Additional issues omitted (' + CONVERT(NVARCHAR(20), @TotalIssues - 10) + N' more).' ELSE N'' END;
            THROW 51817, @IssueMessage, 1;
        END;

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
