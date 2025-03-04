CREATE TABLE [dbo].[A1_Expenses] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [Date]              DATE            NULL,
    [Time]              TIME (0)        NULL,
    [To]                NVARCHAR (MAX)  NULL,
    [Value]             DECIMAL (18, 2) NULL,
    [Details]           NVARCHAR (MAX)  NULL,
    [Type]              NVARCHAR (50)   NULL,
    [Conver]            NVARCHAR (MAX)  NULL,
    [Bank]              INT             NULL,
    [Group]             NVARCHAR (MAX)  NULL,
    [Clinic]            NVARCHAR (MAX)  NULL,
    [User]              NVARCHAR (MAX)  NULL,
    [Accounting]        NVARCHAR (MAX)  NULL,
    [BankTranID]        INT             NULL,
    [PurchaseInvocesID] NVARCHAR (MAX)  NULL,
    [SourceType]        NVARCHAR (MAX)  NULL,
    [SourceID]          NVARCHAR (MAX)  NULL,
    [InvoiceNum]        NVARCHAR (MAX)  NULL,
    [VATEnb]            BIT             NULL,
    [VATValue]          DECIMAL (18, 2) NULL,
    [VATBefore]         DECIMAL (18, 2) NULL,
    [VATPer]            DECIMAL (18, 2) NULL,
    [VATNumberTo]       NVARCHAR (255)  NULL,
    [SalaryID]          INT             NULL,
    [DrID]              INT             NULL,
    [BoxID]             INT             NULL,
    CONSTRAINT [PK_A1_Expenses] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Expenses_Date]
    ON [dbo].[A1_Expenses]([Date] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Expenses_Time]
    ON [dbo].[A1_Expenses]([Time] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_Expenses_Type]
    ON [dbo].[A1_Expenses]([Type] ASC);

