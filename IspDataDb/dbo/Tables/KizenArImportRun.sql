CREATE TABLE [dbo].[KizenArImportRun] (
    [IdNo]               INT            IDENTITY (1, 1) NOT NULL,
    [SourcePeriodStart]  DATE           NOT NULL,
    [SourcePeriodEnd]    DATE           NOT NULL,
    [SeriesName]         VARCHAR (20)   NOT NULL,
    [ReferenceNo]        VARCHAR (15)   NOT NULL,
    [SourceInvoiceCount] INT            NOT NULL,
    [SourceDetailCount]  INT            NOT NULL,
    [SourceAmount]       MONEY          NOT NULL,
    [CreatedBy]          NVARCHAR (128) NULL,
    [DateCreated]        DATETIME       CONSTRAINT [DF_KizenArImportRun_DateCreated] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_KizenArImportRun] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_KizenArImportRun_Period] UNIQUE ([SourcePeriodStart], [SourcePeriodEnd])
);
