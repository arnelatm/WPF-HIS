CREATE TABLE [dbo].[mobile_appactionlog] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [user]           NVARCHAR (20)  NOT NULL,
    [client]         NVARCHAR (50)  NULL,
    [action]         NVARCHAR (50)  NULL,
    [params]         NVARCHAR (MAX) NULL,
    [describe]       NVARCHAR (MAX) NULL,
    [request_status] SMALLINT       NOT NULL,
    [action_time]    DATETIME2 (7)  NOT NULL,
    [remote_ip]      NVARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

