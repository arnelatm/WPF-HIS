CREATE TABLE [dbo].[A1_Store] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NULL,
    [Note]         NVARCHAR (MAX) NULL,
    [Code]         NVARCHAR (MAX) NULL,
    [Rsd_UserName] NVARCHAR (255) NULL,
    [Rsd_Password] NVARCHAR (255) NULL,
    [Rsd_GLN]      NVARCHAR (255) NULL,
    CONSTRAINT [PK_A1_Store] PRIMARY KEY CLUSTERED ([ID] ASC)
);

