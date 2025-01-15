CREATE TABLE [dbo].[Clinics] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NULL,
    [Parent]       NVARCHAR (255) NULL,
    [FromStore]    INT            NULL,
    [ToStore]      INT            NULL,
    [Code]         NVARCHAR (255) NULL,
    [JZ_CompanyId] INT            NULL,
    CONSTRAINT [PK_Clinics] PRIMARY KEY CLUSTERED ([ID] ASC)
);

