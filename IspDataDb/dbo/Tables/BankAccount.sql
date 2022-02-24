CREATE TABLE [dbo].[BankAccount] (
    [IdNo]          SMALLINT      IDENTITY (1, 1) NOT NULL,
    [AccountIdNo]   INT           NOT NULL,
    [BankIdNo]      SMALLINT      NOT NULL,
    [BranchName]    NVARCHAR (50) NOT NULL,
    [AccountNumber] NVARCHAR (20) NULL,
    [IBAN]          VARCHAR (24)  NULL,
    CONSTRAINT [PK_BankAccount] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



