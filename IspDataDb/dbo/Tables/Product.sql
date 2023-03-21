CREATE TABLE [dbo].[Product] (
    [IdNo]           INT            IDENTITY (1, 1) NOT NULL,
    [CategoryIdNo]   SMALLINT       NULL,
    [Code]           VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Name]           VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [NameAra]        NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [BaseUnit]       SMALLINT       NULL,
    [VatPercent]     DECIMAL (5, 2) NULL,
    [GlAccountIdNo]  SMALLINT       NULL,
    [VatAccountIdNo] SMALLINT       NULL,
    [Active]         BIT            NULL,
    [DateCreated]    DATE           CONSTRAINT [DF_Product_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]  ROWVERSION     NULL,
    [CreatedByIdNo]  SMALLINT       NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

