CREATE TABLE [dbo].[meeting_meetingroom] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [code]        NVARCHAR (32)  NOT NULL,
    [alias]       NVARCHAR (50)  NOT NULL,
    [capacity]    INT            NOT NULL,
    [location]    NVARCHAR (200) NOT NULL,
    [remark]      NVARCHAR (MAX) NULL,
    [state]       SMALLINT       NOT NULL,
    [enable_room] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([code] ASC)
);

