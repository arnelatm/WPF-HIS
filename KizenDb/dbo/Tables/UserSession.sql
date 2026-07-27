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


GO
CREATE NONCLUSTERED INDEX [IX_UserSession_UserID]
    ON [dbo].[UserSession]([UserID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserSession_TimeOut]
    ON [dbo].[UserSession]([TimeOut] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserSession_LocalIP]
    ON [dbo].[UserSession]([LocalIP] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserSession_ComputerName]
    ON [dbo].[UserSession]([ComputerName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserSession_ComputerFriendlyName]
    ON [dbo].[UserSession]([ComputerFriendlyName] ASC);

