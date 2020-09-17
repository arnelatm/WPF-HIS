CREATE TABLE [dbo].[ReceiptDetails] (
    [IdNo]               INT          IDENTITY (1, 1) NOT NULL,
    [AccountIdNo]        SMALLINT     NULL,
    [CheckPayment]       BIT          NULL,
    [CheckReferenceNo]   VARCHAR (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [ORNumber]           VARCHAR (15) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DiscountTaken]      MONEY        NULL,
    [CheckReferenceDate] DATE         NULL,
    [Applied]            MONEY        NULL,
    [UnApplied]          MONEY        NULL,
    CONSTRAINT [PK_ReceiptDetails] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



