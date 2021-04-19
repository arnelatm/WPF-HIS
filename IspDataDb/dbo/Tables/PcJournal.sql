CREATE TABLE [dbo].[PcJournal] (
    [IdNo]                INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate]     DATE           NOT NULL,
    [ReferenceNo]         VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Amount]              MONEY          NOT NULL,
    [AccountIdNo]         SMALLINT       NOT NULL,
    [PaymentType]         CHAR (1)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [PayType]             CHAR (1)       NULL,
    [PayeeIdNo]           INT            NULL,
    [PayeeName]           NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CheckNumber]         VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CheckDate]           DATE           NULL,
    [ORNumber]            VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DiscountTaken]       MONEY          NULL,
    [DiscountAccountIdNo] SMALLINT       NULL,
    [Applied]             MONEY          NULL,
    [UnApplied]           MONEY          NULL,
    [VatNumber]           VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [VatAmount]           MONEY          NULL,
    [Notes]               NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [PcClosed]            BIT            NULL,
    [CdJournalIdNo]       INT            NULL,
    [Posted]              BIT            NULL,
    [DateCreated]         DATETIME       CONSTRAINT [DF_PcJournal_DateCreated] DEFAULT (getdate()) NULL,
    [Cancelled]           BIT            NULL,
    [DateTimeStamp]       ROWVERSION     NULL,
    CONSTRAINT [PK_PcJournal1] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









