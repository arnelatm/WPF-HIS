CREATE TABLE [dbo].[iclock_shortmessage] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [message]    NVARCHAR (MAX) NOT NULL,
    [start_time] DATETIME2 (7)  NOT NULL,
    [duration]   INT            NOT NULL,
    [msg_type]   NVARCHAR (5)   NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

