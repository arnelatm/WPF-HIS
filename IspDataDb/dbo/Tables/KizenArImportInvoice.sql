CREATE TABLE [dbo].[KizenArImportInvoice] (
    [IdNo]                  INT            IDENTITY (1, 1) NOT NULL,
    [InsuranceInvoiceID]    INT            NOT NULL,
    [JournalIdNo]           INT            NOT NULL,
    [ReferenceNo]           VARCHAR (15)   NOT NULL,
    [CompanyCode]           NVARCHAR (100) NOT NULL,
    [ZatcaNumber]           VARCHAR (15)   NOT NULL,
    [SupplyPeriodStart]     DATE           NOT NULL,
    [SupplyPeriodEnd]       DATE           NOT NULL,
    [SourceInvoiceCount]    INT            NOT NULL,
    [SourceDetailCount]     INT            NOT NULL,
    [SourceAmount]          MONEY          NOT NULL,
    [SourceVatAmount]       MONEY          NOT NULL,
    [CreatedBy]             NVARCHAR (128) NULL,
    [DateCreated]           DATETIME       CONSTRAINT [DF_KizenArImportInvoice_DateCreated] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_KizenArImportInvoice] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_KizenArImportInvoice_InsuranceInvoice] UNIQUE ([InsuranceInvoiceID])
);
