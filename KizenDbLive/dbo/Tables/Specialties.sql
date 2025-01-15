CREATE TABLE [dbo].[Specialties] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NULL,
    [Type] NVARCHAR (255) NULL,
    CONSTRAINT [PK_Specialties] PRIMARY KEY CLUSTERED ([ID] ASC)
);

