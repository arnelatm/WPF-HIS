CREATE TABLE [dbo].[CutTybe] (
    [CutTybeID]   INT           IDENTITY (1, 1) NOT NULL,
    [CutTybeName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_CutTybe] PRIMARY KEY CLUSTERED ([CutTybeID] ASC)
);

