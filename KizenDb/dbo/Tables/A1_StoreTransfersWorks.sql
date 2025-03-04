CREATE TABLE [dbo].[A1_StoreTransfersWorks] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [Code]       NVARCHAR (MAX) NULL,
    [SourceCode] NVARCHAR (MAX) NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [OrderID]    INT            NULL,
    CONSTRAINT [PK_A1_StoreTransfersWorks] PRIMARY KEY CLUSTERED ([ID] ASC)
);

