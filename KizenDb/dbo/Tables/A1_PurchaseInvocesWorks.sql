CREATE TABLE [dbo].[A1_PurchaseInvocesWorks] (
    [ID]                 INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]            INT             NULL,
    [Price]              FLOAT (53)      NULL,
    [Count]              FLOAT (53)      NULL,
    [Total]              FLOAT (53)      NULL,
    [Disc]               DECIMAL (19, 4) NULL,
    [DiscNet]            DECIMAL (19, 4) NULL,
    [Net]                DECIMAL (19, 4) NULL,
    [Note]               NVARCHAR (MAX)  NULL,
    [UserName]           NVARCHAR (50)   NULL,
    [Date]               DATE            NULL,
    [Time]               TIME (0)        NULL,
    [WorkID]             NVARCHAR (255)  NULL,
    [Name]               NVARCHAR (MAX)  NULL,
    [IsService]          BIT             NULL,
    [ExpierdDate]        DATE            NULL,
    [SourceBarCode]      NVARCHAR (MAX)  NULL,
    [VATPer]             DECIMAL (18, 2) NULL,
    [VatValue]           DECIMAL (19, 4) NULL,
    [TotalNoVAT]         DECIMAL (19, 4) NULL,
    [SellPrice]          DECIMAL (19, 4) NULL,
    [TotalSellPrice]     DECIMAL (19, 4) NULL,
    [ReturnID]           INT             NULL,
    [Cost]               DECIMAL (19, 4) NULL,
    [TotalCost]          DECIMAL (19, 4) NULL,
    [XtraCount]          DECIMAL (19, 4) NULL,
    [GTIN]               NVARCHAR (255)  NULL,
    [SN]                 NVARCHAR (255)  NULL,
    [BN]                 NVARCHAR (255)  NULL,
    [Rsd_NotificationID] NVARCHAR (255)  NULL,
    [Rsd_RC]             NVARCHAR (255)  NULL,
    [SecondDisc]         DECIMAL (19, 4) NULL,
    [SecondDiscNet]      DECIMAL (19, 4) NULL,
    [GeneralDiscount]    DECIMAL (19, 4) NULL,
    CONSTRAINT [PK_A1_PurchaseInvocesWorks] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvocesWorks_OrderID]
    ON [dbo].[A1_PurchaseInvocesWorks]([OrderID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvocesWorks_WorkID]
    ON [dbo].[A1_PurchaseInvocesWorks]([WorkID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvocesWorks_OrderID_Net]
    ON [dbo].[A1_PurchaseInvocesWorks]([OrderID] ASC, [Net] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_PurchaseInvocesWorks_Net]
    ON [dbo].[A1_PurchaseInvocesWorks]([Net] ASC);

