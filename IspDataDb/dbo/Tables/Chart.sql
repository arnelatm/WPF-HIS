CREATE TABLE [dbo].[Chart] (
    [IdNo]               INT           IDENTITY (1, 1) NOT NULL,
    [ParentIDNo]         INT           NULL,
    [AccountCode]        VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [AccountName]        VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [AccountNameAra]     NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Notes]              VARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DetailAccount]      BIT           NULL,
    [AccountGroup]       CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BYDebit]            MONEY         NULL,
    [BYCredit]           MONEY         NULL,
    [Debit]              MONEY         NULL,
    [Credit]             MONEY         NULL,
    [NormalBalance]      CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CloseDebit]         MONEY         NULL,
    [CloseCredit]        MONEY         NULL,
    [PayeeType]          CHAR (1)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [WithReconciliation] BIT           NULL,
    [IncomeExpSummary]   BIT           NULL,
    [Active]             BIT           NULL,
    [SpecialAccount]     CHAR (2)      COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [GroupSortOrder]     INT           NULL,
    [CreateDate]         DATETIME2 (7) NULL,
    [DateTimeStamp]      ROWVERSION    NULL,
    CONSTRAINT [PK__ChartIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK__Chart__ParentId] FOREIGN KEY ([ParentIDNo]) REFERENCES [dbo].[Chart] ([IdNo]),
    CONSTRAINT [IX_ChartCode] UNIQUE NONCLUSTERED ([AccountCode] ASC),
    CONSTRAINT [IX_ChartName] UNIQUE NONCLUSTERED ([AccountName] ASC),
    CONSTRAINT [IX_ChartNameAra] UNIQUE NONCLUSTERED ([AccountNameAra] ASC)
);









