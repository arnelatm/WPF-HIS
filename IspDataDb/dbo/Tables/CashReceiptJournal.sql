CREATE TABLE [dbo].[CashReceiptJournal] (
    [IdNo]                INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate]     DATE           NOT NULL,
    [ReferenceNo]         VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Amount]              MONEY          NULL,
    [AccountIdNo]         INT            NOT NULL,
    [PayorType]           CHAR (1)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [PayorIdNo]           INT            NULL,
    [Payorname]           NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CheckNumber]         VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CheckDate]           DATE           NULL,
    [ORNumber]            VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DiscountTaken]       MONEY          NULL,
    [DiscountAccountIdNo] INT            NULL,
    [Applied]             MONEY          NULL,
    [UnApplied]           MONEY          NULL,
    [Notes]               NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Posted]              BIT            NULL,
    [DateCreated]         DATETIME       CONSTRAINT [DF_CashReceiptJournal_DateCreated] DEFAULT (getdate()) NULL,
    [Cancelled]           BIT            NULL,
    [DateTimeStamp]       ROWVERSION     NULL,
    CONSTRAINT [PK_CashReceiptJournal] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





