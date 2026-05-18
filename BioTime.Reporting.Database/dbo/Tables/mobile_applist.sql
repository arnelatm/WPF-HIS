CREATE TABLE [dbo].[mobile_applist] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [username]        NVARCHAR (50)  NOT NULL,
    [login_time]      DATETIME2 (7)  NOT NULL,
    [last_active]     DATETIME2 (7)  NOT NULL,
    [token]           NVARCHAR (MAX) NOT NULL,
    [device_token]    NVARCHAR (MAX) NOT NULL,
    [client_id]       NVARCHAR (100) NOT NULL,
    [client_category] SMALLINT       NOT NULL,
    [active]          SMALLINT       NULL,
    [enable]          SMALLINT       NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

