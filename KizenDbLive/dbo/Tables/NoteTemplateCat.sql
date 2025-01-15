CREATE TABLE [dbo].[NoteTemplateCat] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [Parent]   NVARCHAR (MAX) NULL,
    [UserID]   INT            NULL,
    [Private]  BIT            NULL,
    [Location] INT            NULL,
    CONSTRAINT [PK_NoteTemplteCat] PRIMARY KEY CLUSTERED ([ID] ASC)
);

