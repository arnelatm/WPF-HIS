CREATE TABLE [dbo].[Account] (
    [IdNo]               SMALLINT      IDENTITY (1, 1) NOT NULL,
    [ParentIDNo]         SMALLINT      NULL,
    [AccountCode]        VARCHAR (5)   NOT NULL,
    [AccountName]        VARCHAR (50)  NOT NULL,
    [AccountNameAra]     NVARCHAR (50) NULL,
    [Notes]              VARCHAR (255) NULL,
    [DetailAccount]      BIT           NULL,
    [AccountGroup]       CHAR (1)      NULL,
    [BYDebit]            MONEY         NULL,
    [BYCredit]           MONEY         NULL,
    [Debit]              MONEY         NULL,
    [Credit]             MONEY         NULL,
    [NormalBalance]      CHAR (1)      NULL,
    [CloseDebit]         MONEY         NULL,
    [CloseCredit]        MONEY         NULL,
    [PayeeType]          CHAR (1)      NULL,
    [WithReconciliation] BIT           NULL,
    [IncomeExpSummary]   BIT           NULL,
    [Active]             BIT           NULL,
    [SpecialAccount]     CHAR (2)      NULL,
    [GroupSortOrder]     SMALLINT      NULL,
    [PurchaseAccount]    BIT           NULL,
    [CreateDate]         DATETIME2 (7) NULL,
    [DateTimeStamp]      ROWVERSION    NULL,
    CONSTRAINT [PK__AccountIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK__Account__ParentId] FOREIGN KEY ([ParentIDNo]) REFERENCES [dbo].[Account] ([IdNo]),
    CONSTRAINT [IX_AccountCode] UNIQUE NONCLUSTERED ([AccountCode] ASC),
    CONSTRAINT [IX_AccountName] UNIQUE NONCLUSTERED ([AccountName] ASC),
    CONSTRAINT [IX_AccountNameAra] UNIQUE NONCLUSTERED ([AccountNameAra] ASC)
);















