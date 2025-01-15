CREATE TABLE [dbo].[GrowthChart] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [DateTime]  DATETIME       NULL,
    [PatID]     INT            NULL,
    [PatName]   NVARCHAR (255) NULL,
    [DrID]      INT            NULL,
    [DrName]    NVARCHAR (255) NULL,
    [InputType] NVARCHAR (255) NULL,
    [Comment]   NVARCHAR (MAX) NULL,
    [LocationX] INT            NULL,
    [LocationY] INT            NULL,
    [UserName]  NVARCHAR (255) NULL,
    CONSTRAINT [PK_GrowthChart] PRIMARY KEY CLUSTERED ([ID] ASC)
);

