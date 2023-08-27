CREATE TABLE [dbo].[PurchaseOrder] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]      TINYINT        NOT NULL,
    [SupplierIdNo]    INT            NULL,
    [ReferenceNo]     VARCHAR (10)   NULL,
    [TransactionDate] DATE           NULL,
    [WarehouseIdNo]   SMALLINT       NOT NULL,
    [Amount]          DECIMAL (9, 2) NULL,
    [Cancelled]       BIT            NULL,
    [Notes]           NVARCHAR (100) NOT NULL,
    [Posted]          BIT            NULL,
    [DateCreated]     DATE           CONSTRAINT [DF_PurchaseOrder_DateCreated] DEFAULT (getdate()) NULL,
    [UserIdNo]        SMALLINT       NOT NULL,
    [DateTimeStamp]   ROWVERSION     NULL,
    CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

