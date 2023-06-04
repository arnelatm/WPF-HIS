CREATE TABLE [dbo].[Product] (
    [IdNo]           INT            IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]     TINYINT        NOT NULL,
    [Primary_Key]    INT            NULL,
    [Barcode]        VARCHAR (15)   NULL,
    [BaseUnitIdNo]   TINYINT        NULL,
    [ProductCode]    VARCHAR (13)   NOT NULL,
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
    [CreatedByIdNo]  INT            NULL,
    [DateCreated]    DATE           NULL,
    [DateTimeStamp]  ROWVERSION     NOT NULL,
    CONSTRAINT [PK_ItemDetails] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_Product] UNIQUE NONCLUSTERED ([BranchIdNo] ASC, [ProductCode] ASC)
);







