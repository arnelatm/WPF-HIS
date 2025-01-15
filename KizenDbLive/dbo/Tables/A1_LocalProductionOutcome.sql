CREATE TABLE [dbo].[A1_LocalProductionOutcome] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [WorkCode]          NVARCHAR (MAX) NULL,
    [WorkName]          NVARCHAR (MAX) NULL,
    [Count]             FLOAT (53)     NULL,
    [Note]              NVARCHAR (MAX) NULL,
    [ExpierdDate]       DATE           NULL,
    [LocalProductionID] INT            NULL,
    [IsService]         BIT            NULL,
    [PrushID]           INT            NULL,
    CONSTRAINT [PK_A1_LocalProductionOutcome] PRIMARY KEY CLUSTERED ([ID] ASC)
);

