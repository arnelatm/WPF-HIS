CREATE TABLE [dbo].[FileType] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (255) NULL,
    [CodeLength]   INT            NULL,
    [MaxNumber]    INT            NULL,
    [ForcedFields] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_FileType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

