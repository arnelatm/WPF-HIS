CREATE TABLE [dbo].[CashReceiptJournal] (
    [IdNo]                INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate]     DATE           NOT NULL,
    [ReferenceNo]         VARCHAR (15)   NULL,
    [Amount]              MONEY          NULL,
    [AccountIdNo]         SMALLINT       NOT NULL,
    [PayorType]           CHAR (1)       NULL,
    [ContactIdNo]         INT            NULL,
    [PayorIdNo]           INT            NULL,
    [CSEIdNo]             INT            NULL,
    [Payorname]           NVARCHAR (50)  NULL,
    [CheckNumber]         VARCHAR (10)   NULL,
    [CheckDate]           DATE           NULL,
    [ORNumber]            VARCHAR (15)   NULL,
    [DiscountTaken]       MONEY          NULL,
    [DiscountAccountIdNo] SMALLINT       NULL,
    [Applied]             MONEY          NULL,
    [UnApplied]           MONEY          NULL,
    [VatAmount]           MONEY          NULL,
    [VatNumber]           VARCHAR (15)   NULL,
    [Notes]               NVARCHAR (300) NULL,
    [Posted]              BIT            NULL,
    [Approved]            BIT            NULL,
    [DateCreated]         DATETIME       CONSTRAINT [DF_CashReceiptJournal_DateCreated] DEFAULT (getdate()) NULL,
    [Cancelled]           BIT            NULL,
    [DateTimeStamp]       ROWVERSION     NULL,
    CONSTRAINT [PK_CashReceiptJournal] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





















