CREATE TABLE [dbo].[AccountReconciliation] (
    [IdNo]               INT        IDENTITY (1, 1) NOT NULL,
    [AccountIdNo]        INT        NOT NULL,
    [ReconciliationDate] DATE       NOT NULL,
    [Balance]            MONEY      CONSTRAINT [DF_AccountReconciliation_Balance] DEFAULT ((0)) NOT NULL,
    [Posted]             BIT        NULL,
    [Status]             VARCHAR (20) CONSTRAINT [DF_AccountReconciliation_Status] DEFAULT ('Draft') NOT NULL,
    [ReviewedBy]         NVARCHAR (100) NULL,
    [ReviewedAt]         DATETIME NULL,
    [FinalizedBy]        NVARCHAR (100) NULL,
    [FinalizedAt]        DATETIME NULL,
    [DateCreated]        DATE       CONSTRAINT [DF_AccountReconciliation_DateCreated] DEFAULT (getdate()) NOT NULL,
    [DateTimeStamp]      ROWVERSION NULL,
    CONSTRAINT [PK_AccountReconciliation] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

