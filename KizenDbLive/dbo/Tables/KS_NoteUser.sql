CREATE TABLE [dbo].[KS_NoteUser] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [Title]             NVARCHAR (MAX) NULL,
    [Txt]               NVARCHAR (MAX) NULL,
    [Type]              NVARCHAR (MAX) NULL,
    [Importance]        INT            NULL,
    [DateTime]          DATETIME       NULL,
    [EditDateTime]      DATETIME       NULL,
    [UserID]            INT            NULL,
    [EditUser]          INT            NULL,
    [IsSharedNoteEnb]   BIT            NULL,
    [IsSharedNoteUsers] NVARCHAR (MAX) NULL,
    [Color]             INT            NULL,
    [AlarmMe]           BIT            NULL,
    [AlarmDate]         DATE           NULL,
    CONSTRAINT [PK_KS_NoteUser] PRIMARY KEY CLUSTERED ([ID] ASC)
);

