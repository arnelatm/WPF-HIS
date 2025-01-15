CREATE TABLE [dbo].[UserSession] (
    [ID]                   INT            IDENTITY (1, 1) NOT NULL,
    [UserID]               INT            NULL,
    [UserName]             NVARCHAR (255) NULL,
    [StartDate]            DATETIME       NULL,
    [TimeOut]              DATETIME       NULL,
    [ComputerName]         NVARCHAR (255) NULL,
    [ComputerFriendlyName] NVARCHAR (255) NULL,
    [LocalIP]              NVARCHAR (255) NULL,
    [WindowsVersion]       NVARCHAR (255) NULL,
    [AppVersion]           NVARCHAR (10)  NULL,
    CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED ([ID] ASC)
);

