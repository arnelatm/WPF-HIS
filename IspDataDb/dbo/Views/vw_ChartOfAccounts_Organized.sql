CREATE VIEW dbo.vw_ChartOfAccounts_Organized
AS
SELECT
    CAST(AccountCode AS varchar(20)) AS AccountCode,
    AccountName,
    CASE AccountGroup
        WHEN 'A' THEN 'A - Assets'
        WHEN 'L' THEN 'L - Liabilities'
        WHEN 'E' THEN 'E - Equity'
        WHEN 'X' THEN 'X - Expenses'
        WHEN 'R' THEN 'R - Revenue'
        ELSE AccountGroup
    END AS AccountGroup
FROM dbo.Account
WHERE
    DetailAccount = 1
    AND ISNULL(Active, 1) = 1
    AND AccountGroup IN ('A','L','E','X','R');

GO

