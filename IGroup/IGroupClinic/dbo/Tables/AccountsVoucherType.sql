CREATE TABLE [dbo].[AccountsVoucherType] (
    [VoucherID]         VARCHAR (3)     NOT NULL,
    [VoucherType]       VARCHAR (20)    NOT NULL,
    [ParentalType]      VARCHAR (3)     NOT NULL,
    [VoucherTypeArabic] NVARCHAR (20)   NULL,
    [Activate]          BIT             DEFAULT (1) NULL,
    [LastNo]            NUMERIC (10)    DEFAULT (1) NULL,
    [TotalVouchers]     NUMERIC (10)    DEFAULT (0) NULL,
    [Amount_Credit]     NUMERIC (12, 2) DEFAULT (0) NULL,
    [Amount_Debit]      NUMERIC (12, 2) DEFAULT (0) NULL,
    [AutoPrint]         BIT             DEFAULT (1) NULL,
    [CancelVoucher]     BIT             DEFAULT (0) NULL,
    [AffectedStock]     BIT             DEFAULT (0) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IX_AccountsVoucherType]
    ON [dbo].[AccountsVoucherType]([VoucherID] ASC);

