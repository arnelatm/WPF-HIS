CREATE TABLE [dbo].[Product] (
    [IdNo]           INT            IDENTITY (1, 1) NOT NULL,
    [CategoryIdNo]   SMALLINT       NULL,
    [ProductCode]    VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProductName]    VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProductNameAra] NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Barcode]        VARCHAR (13)   NULL,
    [GTIN]           VARCHAR (14)   NULL,
    [BaseUnitIdNo]   SMALLINT       NULL,
    [Active]         BIT            NULL,
    [DateCreated]    DATE           CONSTRAINT [DF_Product_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]  ROWVERSION     NULL,
    [CreatedByIdNo]  SMALLINT       NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



