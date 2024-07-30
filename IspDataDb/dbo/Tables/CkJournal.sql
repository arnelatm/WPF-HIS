CREATE TABLE [dbo].[CkJournal] (
    [IdNo]                INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate]     DATE           NOT NULL,
    [ReferenceNo]         VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Amount]              MONEY          NOT NULL,
    [AccountIdNo]         SMALLINT       NOT NULL,
    [PaymentType]         CHAR (1)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ContactIdNo]         INT            NULL,
    [PayeeIdNo]           INT            NULL,
    [CSEIdNo]             INT            NULL,
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
    [Notes]               NVARCHAR (254) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Approved]            BIT            NULL,
    [Posted]              BIT            NULL,
    [DateCreated]         DATETIME       CONSTRAINT [DF_ChequeDisbursementJournal1_DateAdded] DEFAULT (getdate()) NULL,
    [Cancelled]           BIT            NULL,
    [DateTimeStamp]       ROWVERSION     NULL,
    CONSTRAINT [PK_ChequeDisbursementJournal1] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





