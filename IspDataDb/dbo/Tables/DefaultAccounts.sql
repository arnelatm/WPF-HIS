CREATE TABLE [dbo].[DefaultAccounts] (
    [IdNo]           SMALLINT IDENTITY (1, 1) NOT NULL,
    [AccountIdNo]    SMALLINT NULL,
    [SpecialAccount] CHAR (2) NULL,
    CONSTRAINT [PK_DefaultAccounts] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DefaultAccountsSpecialAccount]
    ON [dbo].[DefaultAccounts]([SpecialAccount] ASC);

