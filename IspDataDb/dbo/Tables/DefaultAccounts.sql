CREATE TABLE [dbo].[DefaultAccounts] (
    [IdNo]           INT      IDENTITY (1, 1) NOT NULL,
    [AccountIdNo]    INT      NULL,
    [SpecialAccount] CHAR (2) NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DefaultAccountsSpecialAccount]
    ON [dbo].[DefaultAccounts]([SpecialAccount] ASC);

