CREATE TABLE [dbo].[AccountsDailyCollectionGroup] (
    [BranchID]       VARCHAR (15)    NOT NULL,
    [Trans_Key]      NUMERIC (10)    NOT NULL,
    [TransSeries]    VARCHAR (10)    NOT NULL,
    [TransNo]        NUMERIC (10)    NOT NULL,
    [TransDate]      VARCHAR (10)    NULL,
    [BillType]       VARCHAR (10)    NULL,
    [LedgerID]       VARCHAR (15)    NULL,
    [LedgerDate]     VARCHAR (10)    NULL,
    [DebitAmt]       NUMERIC (10, 2) NULL,
    [CreditAmt]      NUMERIC (10, 2) NULL,
    [Remarks]        VARCHAR (100)   NULL,
    [UserID]         VARCHAR (15)    NULL,
    [Create_Date]    DATETIME        NULL,
    [MachineID]      VARCHAR (20)    NOT NULL,
    [CollectionType] CHAR (1)        DEFAULT ('C') NULL,
    [Ac_TransKey]    INT             NULL,
    [Apply]          INT             NULL,
    [VATAmt]         NUMERIC (10, 2) DEFAULT ((0)) NULL
);

