




CREATE VIEW [dbo].[vw_ChartOfAccounts_ReportTree]
AS
WITH AccountTree AS
(
    SELECT
        a.IDNo,
        a.ParentIDNo,
        a.AccountCode,
        a.AccountName,
		a.AccountNameAra,
        a.AccountGroup,
        a.GroupSortOrder,
        a.DetailAccount,
        0 AS LevelNo,
		a.Active,

        CAST(
            RIGHT('000000' + CAST(ISNULL(a.GroupSortOrder, a.IDNo) AS varchar(10)), 6)
            + '-' +
            RIGHT('000000' + CAST(a.IDNo AS varchar(10)), 6)
            AS varchar(2000)
        ) AS SortPath
    FROM dbo.Account a
    WHERE a.ParentIDNo IS NULL

    UNION ALL

    SELECT
        c.IDNo,
        c.ParentIDNo,
        c.AccountCode,
        c.AccountName,
		c.AccountNameAra,
        c.AccountGroup,
        c.GroupSortOrder,
        c.DetailAccount,
        p.LevelNo + 1 AS LevelNo,
		c.Active,

        CAST(
            p.SortPath
            + '-' +
            RIGHT('000000' + CAST(ISNULL(c.GroupSortOrder, c.IDNo) AS varchar(10)), 6)
            + '-' +
            RIGHT('000000' + CAST(c.IDNo AS varchar(10)), 6)
            AS varchar(2000)
        ) AS SortPath
    FROM dbo.Account c
    INNER JOIN AccountTree p
        ON c.ParentIDNo = p.IDNo
)
SELECT
    IdNo,
    AccountCode,
    AccountName,
	AccountNameAra,
    AccountGroup,
    ParentIDNo,
    DetailAccount,
    LevelNo,
    SortPath,

    REPLICATE('    ', LevelNo)
        + CAST(AccountCode AS varchar(20))
        + '-'
        + AccountName AS DisplayAccountName,
	REPLICATE('    ', LevelNo)
        + CAST(AccountCode AS varchar(20))
        + '-'
        + AccountNameAra AS DisplayAccountNameAra

FROM AccountTree
WHERE AccountGroup IN ('A','L','E','X','R','S') and active = 1;

GO

