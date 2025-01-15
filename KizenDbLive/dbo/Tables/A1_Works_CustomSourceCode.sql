CREATE TABLE [dbo].[A1_Works_CustomSourceCode] (
    [ID]     INT            IDENTITY (1, 1) NOT NULL,
    [WorkID] INT            NULL,
    [Code]   NVARCHAR (255) NULL,
    CONSTRAINT [PK_A1_Works_CustomSourceCode] PRIMARY KEY CLUSTERED ([ID] ASC)
);

