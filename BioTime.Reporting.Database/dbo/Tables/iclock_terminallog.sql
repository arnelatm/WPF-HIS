CREATE TABLE [dbo].[iclock_terminallog] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [terminal_tz] SMALLINT      NULL,
    [admin]       NVARCHAR (50) NULL,
    [action_name] SMALLINT      NULL,
    [action_time] DATETIME2 (7) NULL,
    [object]      NVARCHAR (50) NULL,
    [param1]      INT           NULL,
    [param2]      INT           NULL,
    [param3]      INT           NULL,
    [upload_time] DATETIME2 (7) NULL,
    [terminal_id] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_terminallog_terminal_id_667b3ea7_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_terminallog_terminal_id_667b3ea7]
    ON [dbo].[iclock_terminallog]([terminal_id] ASC);

