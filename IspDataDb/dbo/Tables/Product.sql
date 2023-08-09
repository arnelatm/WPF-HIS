CREATE TABLE [dbo].[Product] (
    [IdNo]           INT            IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]     TINYINT        NOT NULL,
    [Primary_Key]    INT            NULL,
    [Barcode]        VARCHAR (15)   NULL,
    [BaseUnitIdNo]   TINYINT        NULL,
    [ProductCode]    VARCHAR (13)   NULL,
    [ProductName]    VARCHAR (50)   NOT NULL,
    [ProductNameAra] VARCHAR (50)   NULL,
    [ItemGroup]      VARCHAR (5)    NULL,
    [Category]       VARCHAR (5)    NULL,
    [CategoryIdNo]   SMALLINT       NULL,
    [SaleStrip]      CHAR (1)       NULL,
    [SalePcs]        CHAR (1)       NULL,
    [Price_Cash]     NUMERIC (7, 2) NULL,
    [GTIN]           VARCHAR (14)   NULL,
    [Active]         BIT            NULL,
    [UserIdNo]       SMALLINT       NULL,
    [DateCreated]    DATETIME       CONSTRAINT [DF_Product_DateCreated_1] DEFAULT (getdate()) NOT NULL,
    [DateTimeStamp]  ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ItemDetails] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_ProductBranchIdNoName] UNIQUE NONCLUSTERED ([BranchIdNo] ASC, [ProductCode] ASC)
);
















GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ProductName]
    ON [dbo].[Product]([ProductName] ASC);

