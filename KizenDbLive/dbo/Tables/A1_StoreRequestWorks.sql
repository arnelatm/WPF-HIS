CREATE TABLE [dbo].[A1_StoreRequestWorks] (
    [ID]              INT             IDENTITY (1, 1) NOT NULL,
    [OrderID]         INT             NULL,
    [Code]            NVARCHAR (255)  NULL,
    [SourceCode]      NVARCHAR (MAX)  NULL,
    [Name]            NVARCHAR (MAX)  NULL,
    [Count]           DECIMAL (18, 3) NULL,
    [Emp1Note]        NVARCHAR (MAX)  NULL,
    [Emp2Note]        NVARCHAR (MAX)  NULL,
    [TransferedCount] DECIMAL (18, 3) NULL,
    [PrushesID]       INT             NULL,
    [SellPrice]       DECIMAL (18, 2) NULL,
    [BuyPrice]        DECIMAL (19, 4) NULL,
    [ExpiredDate]     DATE            NULL,
    [AvailableCount]  DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_A1_StoreRequestWork] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_A1_StoreRequestWorks_Code]
    ON [dbo].[A1_StoreRequestWorks]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_StoreRequestWorks_OrderID]
    ON [dbo].[A1_StoreRequestWorks]([OrderID] ASC);

