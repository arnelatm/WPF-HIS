CREATE TABLE [dbo].[BankAccount] (
    [IdNo]        SMALLINT      IDENTITY (1, 1) NOT NULL,
    [AccountIdNo] INT           NOT NULL,
    [BankIdNo]    SMALLINT      NOT NULL,
    [BranchName]  NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

