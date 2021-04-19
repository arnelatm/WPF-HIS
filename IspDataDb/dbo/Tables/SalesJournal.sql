CREATE TABLE [dbo].[SalesJournal] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [TransactionDate] DATE           NOT NULL,
    [AccountIdNo]     SMALLINT       NOT NULL,
    [ReferenceNo]     VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]           NVARCHAR (300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Posted]          BIT            NOT NULL,
    [Cancelled]       BIT            NOT NULL,
    [DateCreated]     DATETIME       CONSTRAINT [DF_SalesJournal_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_SalesJournal] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







