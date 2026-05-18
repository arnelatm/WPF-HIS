CREATE TABLE [dbo].[iclock_publicmessage] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [last_send]   DATETIME2 (7)  NULL,
    [message_id]  INT            NULL,
    [terminal_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_publicmessage_message_id_7d125e28_fk_iclock_shortmessage_id] FOREIGN KEY ([message_id]) REFERENCES [dbo].[iclock_shortmessage] ([id]),
    CONSTRAINT [iclock_publicmessage_terminal_id_c3b5e4cf_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_publicmessage_message_id_7d125e28]
    ON [dbo].[iclock_publicmessage]([message_id] ASC);


GO
CREATE NONCLUSTERED INDEX [iclock_publicmessage_terminal_id_c3b5e4cf]
    ON [dbo].[iclock_publicmessage]([terminal_id] ASC);

