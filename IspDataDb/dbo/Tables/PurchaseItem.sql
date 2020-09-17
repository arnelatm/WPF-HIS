CREATE TABLE [dbo].[PurchaseItem] (
    [IdNo]                INT            IDENTITY (1, 1) NOT NULL,
    [CategoryIdNo]        SMALLINT       NULL,
    [PurchaseitemCode]    VARCHAR (10)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [PurchaseitemName]    VARCHAR (50)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [PurchaseitemNameAra] NVARCHAR (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Unit1]               NVARCHAR (20)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Unit2]               NVARCHAR (20)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Unit3]               NVARCHAR (20)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Unit1Ara]            NVARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Unit2Ara]            NVARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Unit3Ara]            NVARCHAR (40)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [StdPrice1]           MONEY          NULL,
    [StdPrice2]           MONEY          NULL,
    [StdPrice3]           MONEY          NULL,
    [GlAccountIdNo]       SMALLINT       NULL,
    [VatAccountIdNo]      SMALLINT       NULL,
    [Active]              BIT            NULL,
    [DateCreated]         DATE           CONSTRAINT [DF_Purchaseitem_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]       ROWVERSION     NULL,
    [CreatedByIdNo]       SMALLINT       NULL,
    CONSTRAINT [PK_PurchaseItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



