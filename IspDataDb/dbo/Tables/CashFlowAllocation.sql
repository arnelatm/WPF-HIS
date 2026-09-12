CREATE TABLE [dbo].[CashFlowAllocation] (
    [IdNo]               BIGINT         IDENTITY (1, 1) NOT NULL,
    [JournalCode]        CHAR (2)       NOT NULL,
    [JournalIdNo]        INT            NOT NULL,
    [ItemIdNo]           INT            NOT NULL,
    [CashAccountIdNo]    SMALLINT       NOT NULL,
    [ClassificationCode] VARCHAR (40)   NOT NULL,
    [CategoryCode]       VARCHAR (40)   NULL,
    [Amount]             MONEY          NOT NULL,
    [Status]             VARCHAR (20)   CONSTRAINT [DF_CashFlowAllocation_Status] DEFAULT ('Review') NOT NULL,
    [SourceFingerprint]  VARCHAR (64)   NULL,
    [Notes]              NVARCHAR (500) NULL,
    [ReviewedBy]         NVARCHAR (100) NULL,
    [ReviewedAt]         DATETIME       NULL,
    [CreatedBy]          NVARCHAR (100) NULL,
    [CreatedAt]          DATETIME       CONSTRAINT [DF_CashFlowAllocation_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [DateTimeStamp]      ROWVERSION     NULL,
    CONSTRAINT [PK_CashFlowAllocation] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK_CashFlowAllocation_CashAccount] FOREIGN KEY ([CashAccountIdNo]) REFERENCES [dbo].[Account] ([IdNo]),
    CONSTRAINT [FK_CashFlowAllocation_Classification] FOREIGN KEY ([ClassificationCode]) REFERENCES [dbo].[CashFlowClassification] ([Code]),
    CONSTRAINT [FK_CashFlowAllocation_Category] FOREIGN KEY ([CategoryCode]) REFERENCES [dbo].[CashFlowClassification] ([Code]),
    CONSTRAINT [CK_CashFlowAllocation_Status] CHECK ([Status] IN ('Review', 'Approved', 'Rejected'))
);

GO
CREATE NONCLUSTERED INDEX [IX_CashFlowAllocation_Source]
    ON [dbo].[CashFlowAllocation] ([JournalCode] ASC, [JournalIdNo] ASC, [ItemIdNo] ASC);
