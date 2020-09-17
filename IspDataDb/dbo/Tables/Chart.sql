CREATE TABLE [dbo].[Chart] (
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
    [CreateDate]         DATETIME2 (7) NULL,
    [DateTimeStamp]      ROWVERSION    NULL,
    CONSTRAINT [PK__ChartIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK__Chart__ParentId] FOREIGN KEY ([ParentIDNo]) REFERENCES [dbo].[Chart] ([IdNo]),
    CONSTRAINT [IX_ChartCode] UNIQUE NONCLUSTERED ([AccountCode] ASC),
    CONSTRAINT [IX_ChartName] UNIQUE NONCLUSTERED ([AccountName] ASC),
    CONSTRAINT [IX_ChartNameAra] UNIQUE NONCLUSTERED ([AccountNameAra] ASC)
);













