CREATE TABLE [dbo].[IBInvoiceDetails] (
    [Group_Key]  NUMERIC (10)    NOT NULL,
    [SlNo]       INT             NOT NULL,
    [ServiceID]  VARCHAR (15)    NOT NULL,
    [Qty]        INT             DEFAULT ((1)) NULL,
    [Price]      NUMERIC (10, 2) NULL,
    [DiscPer]    NUMERIC (10, 2) NULL,
    [DiscAmt]    NUMERIC (10, 2) NULL,
    [VATPercent] NUMERIC (5, 2)  DEFAULT ((0)) NULL,
    [VATAmt]     NUMERIC (10, 2) DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_IBInvoiceDetails]
    ON [dbo].[IBInvoiceDetails]([Group_Key] ASC, [SlNo] ASC);

