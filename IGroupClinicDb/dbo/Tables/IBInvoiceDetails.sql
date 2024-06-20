CREATE TABLE [dbo].[IBInvoiceDetails] (
    [Group_Key]  NUMERIC (10)    NOT NULL,
    [SlNo]       INT             NOT NULL,
    [ServiceID]  VARCHAR (15)    NOT NULL,
    [Qty]        INT             CONSTRAINT [DF__IBInvoiceDe__Qty__036753BE] DEFAULT ((1)) NULL,
    [Price]      NUMERIC (10, 2) NULL,
    [DiscPer]    NUMERIC (10, 2) NULL,
    [DiscAmt]    NUMERIC (10, 2) NULL,
    [VATPercent] NUMERIC (5, 2)  CONSTRAINT [DF__IBInvoice__VATPe__47C76B03] DEFAULT ((0)) NULL,
    [VATAmt]     NUMERIC (10, 2) CONSTRAINT [DF__IBInvoice__VATAm__48BB8F3C] DEFAULT ((0)) NULL,
    [IdNo]       INT             IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_IBInvoiceDetails] PRIMARY KEY NONCLUSTERED ([IdNo] ASC)
);




GO
CREATE UNIQUE CLUSTERED INDEX [IDX_IBInvoiceDetails]
    ON [dbo].[IBInvoiceDetails]([Group_Key] ASC, [SlNo] ASC);

