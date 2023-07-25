CREATE TABLE [dbo].[Purchase] (
    [IdNo]            INT          IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]      TINYINT      NULL,
    [SupplierIdNo]    INT          NOT NULL,
    [TransactionDate] DATE         NULL,
    [ReferenceNo]     VARCHAR (15) NULL,
    [Amount]          MONEY        NOT NULL,
    [DueDate]         DATE         NULL,
    [InvoiceNo]       VARCHAR (20) NOT NULL,
    [InvoiceDate]     DATE         NULL,
    [VatNumber]       VARCHAR (50) NULL,
    [VatAmount]       MONEY        NULL,
    [WarehouseIdNo]   SMALLINT     NULL,
    [Posted]          BIT          NULL,
    [Cancelled]       BIT          NULL,
    [DateCreated]     DATETIME     CONSTRAINT [DF_PurchaseJournal_DateCreated] DEFAULT (getdate()) NOT NULL,
    [UserIdNo]        SMALLINT     NULL,
    [DateTimeStamp]   ROWVERSION   NOT NULL,
    CONSTRAINT [PK_PurchaseIdNo] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);










GO



GO


