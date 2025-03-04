CREATE TABLE [dbo].[ErrorViewer] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Type]            NVARCHAR (MAX) NULL,
    [Message]         NVARCHAR (MAX) NULL,
    [StackTrace]      NVARCHAR (MAX) NULL,
    [User]            NVARCHAR (50)  NULL,
    [Date]            DATE           NULL,
    [Time]            TIME (7)       NULL,
    [Device]          NVARCHAR (50)  NULL,
    [LoadedAssembly]  NVARCHAR (MAX) NULL,
    [CheckedEnb]      BIT            NULL,
    [CheckedDateTime] DATETIME       NULL,
    [CheckedUserName] NVARCHAR (255) NULL,
    [CheckedNote]     NVARCHAR (MAX) NULL,
    [AppVersion]      NVARCHAR (50)  NULL,
    CONSTRAINT [PK_ErrorViewer] PRIMARY KEY CLUSTERED ([ID] ASC)
);

