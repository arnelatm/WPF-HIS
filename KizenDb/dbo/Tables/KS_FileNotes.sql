CREATE TABLE [dbo].[KS_FileNotes] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [DateTime] DATETIME       NULL,
    [UserName] NVARCHAR (255) NULL,
    [PatID]    INT            NULL,
    [Txt]      NVARCHAR (MAX) NULL,
    [Type]     NVARCHAR (50)  NULL,
    CONSTRAINT [PK_KS_FileNotes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

