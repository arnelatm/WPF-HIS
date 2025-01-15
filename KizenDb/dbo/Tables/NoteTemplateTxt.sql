CREATE TABLE [dbo].[NoteTemplateTxt] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [UserID]     INT            NULL,
    [ParentName] NVARCHAR (MAX) NULL,
    [Txt]        NVARCHAR (MAX) NULL,
    [DateTime]   DATETIME       NULL,
    [Private]    BIT            NULL,
    [Location]   INT            NULL,
    CONSTRAINT [PK_NoteTemplateTxt] PRIMARY KEY CLUSTERED ([ID] ASC)
);

