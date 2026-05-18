CREATE TABLE [dbo].[iclock_terminaluploadlog] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [event]        NVARCHAR (80) NOT NULL,
    [content]      NVARCHAR (80) NOT NULL,
    [upload_count] INT           NOT NULL,
    [error_count]  INT           NOT NULL,
    [upload_time]  DATETIME2 (7) NOT NULL,
    [terminal_id]  INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_terminaluploadlog_terminal_id_9c9a7664_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_terminaluploadlog_terminal_id_9c9a7664]
    ON [dbo].[iclock_terminaluploadlog]([terminal_id] ASC);

