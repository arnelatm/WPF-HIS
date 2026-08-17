CREATE TABLE [dbo].[Customer] (
    [IdNo]               INT            IDENTITY (1, 1) NOT NULL,
    [CustomerCode]       NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CustomerName]       NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [CustomerNameAra]    NVARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
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
    [ARAccountIdNo]      SMALLINT       NULL,
    [RevAccountIdNo]     SMALLINT       NULL,
    [DiscountSchemeIdNo] INT            NULL,
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
    [DateCreated]        DATETIME2 (7)  CONSTRAINT [DF_Customer_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]      ROWVERSION     NULL,
    CONSTRAINT [PK_CustomerIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_CustomerCode]
    ON [dbo].[Customer]([CustomerCode] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_CustomerName]
    ON [dbo].[Customer]([CustomerName] ASC);


GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_CustomerNameAra]
    ON [dbo].[Customer]([CustomerNameAra] ASC);


GO

CREATE TRIGGER [dbo].[TR_Customer_Add] ON [dbo].[Customer]
FOR INSERT
AS

INSERT INTO Contact
        (CSEIdNo, CSECode)
    SELECT
        IdNo, 'C'
        FROM inserted

GO

