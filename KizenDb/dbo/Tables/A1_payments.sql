CREATE TABLE [dbo].[A1_payments] (
    [ID]               INT             IDENTITY (1, 1) NOT NULL,
    [Date]             DATETIME        NULL,
    [Type]             NVARCHAR (50)   NULL,
    [Value]            DECIMAL (18, 2) NULL,
    [OrderID]          INT             NULL,
    [Time]             TIME (0)        NULL,
    [UserName]         NVARCHAR (255)  NULL,
    [Note]             NVARCHAR (MAX)  NULL,
    [CustName]         NVARCHAR (255)  NULL,
    [CustId]           INT             NULL,
    [Declare]          NVARCHAR (MAX)  NULL,
    [Bank]             INT             NULL,
    [ATM]              NVARCHAR (MAX)  NULL,
    [Vendor]           NVARCHAR (255)  NULL,
    [Box]              NVARCHAR (255)  NULL,
    [VendorPercent]    INT             NULL,
    [DrName]           NVARCHAR (255)  NULL,
    [DrID]             INT             NULL,
    [Details]          NVARCHAR (MAX)  NULL,
    [DeviceName]       NVARCHAR (MAX)  NULL,
    [BankTranID]       INT             NULL,
    [VATPer]           DECIMAL (18, 2) NULL,
    [BoxID]            INT             NULL,
    [ChangeDrManually] BIT             NULL,
    [CashPaid]         DECIMAL (18, 2) NULL,
    [CashReturned]     DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_A1_payments] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_A1_payments_Date]
    ON [dbo].[A1_payments]([Date] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_payments_Date_DESC]
    ON [dbo].[A1_payments]([Date] DESC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_payments_Date_OrderID]
    ON [dbo].[A1_payments]([Date] ASC, [OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_payments_OrderID]
    ON [dbo].[A1_payments]([OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_payments_Type]
    ON [dbo].[A1_payments]([Type] ASC);

