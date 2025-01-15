CREATE TABLE [dbo].[EventViewer] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NULL,
    [Type]          NVARCHAR (MAX) NULL,
    [DateTime]      DATETIME       NULL,
    [DeviceName]    NVARCHAR (MAX) NULL,
    [LoginUserName] NVARCHAR (MAX) NULL,
    [LoginUserID]   INT            NULL,
    [Comment]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_EventViewer] PRIMARY KEY CLUSTERED ([ID] ASC)
);

