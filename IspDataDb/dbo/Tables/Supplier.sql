CREATE TABLE [dbo].[Supplier] (
    [IdNo]               INT            IDENTITY (1, 1) NOT NULL,
    [SupplierCode]       VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [SupplierName]       VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [SupplierNameAra]    NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ContactPerson]      NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ContactDesignation] NVARCHAR (15)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Street]             NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [District]           NVARCHAR (35)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [TownCity]           NVARCHAR (35)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ProvinceState]      NVARCHAR (35)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CountryCode]        CHAR (2)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [POBox]              VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ZipCode]            VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Phone1]             VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Phone2]             VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Mobile]             VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Fax]                VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Email]              VARCHAR (254)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Website]            VARCHAR (254)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [VATNumber]          VARCHAR (15)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CRNumber]           VARCHAR (20)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [AccountStatus]      CHAR (1)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [APAccountIdNo]      SMALLINT       NULL,
    [ExpAccountIdNo]     SMALLINT       NULL,
    [CreditLimit]        MONEY          NULL,
    [SettlementDueDays]  SMALLINT       NULL,
    [SettlementDiscount] DECIMAL (5, 2) NULL,
    [PaymentDueDays]     SMALLINT       NULL,
    [DateAccountOpen]    DATETIME       NULL,
    [BankAccountName]    NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BankAccountNo]      VARCHAR (20)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BankIdNo]           SMALLINT       NULL,
    [IBAN]               VARCHAR (35)   COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [PaymentMethod]      CHAR (2)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Notes]              NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [OpeningBalance]     MONEY          NULL,
    [Active]             BIT            NULL,
    [DateCreated]        DATETIME2 (7)  CONSTRAINT [DF_Supplier_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]      ROWVERSION     NULL,
    CONSTRAINT [PK_SupplierIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);






















GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SupplierName]
    ON [dbo].[Supplier]([SupplierName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SupplierCode]
    ON [dbo].[Supplier]([SupplierCode] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SupplierNameAra]
    ON [dbo].[Supplier]([SupplierNameAra] ASC);


GO
CREATE TRIGGER [dbo].[TR_Supplier_Add] ON [dbo].[Supplier]
FOR INSERT
AS

INSERT INTO Contact
        (CSEIdNo, CSECode)
    SELECT
        IdNo, 'S'
        FROM inserted