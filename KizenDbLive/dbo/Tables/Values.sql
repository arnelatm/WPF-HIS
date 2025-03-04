CREATE TABLE [dbo].[Values] (
    [ID]    INT            IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (255) NULL,
    [Value] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Values] PRIMARY KEY CLUSTERED ([ID] ASC)
);

