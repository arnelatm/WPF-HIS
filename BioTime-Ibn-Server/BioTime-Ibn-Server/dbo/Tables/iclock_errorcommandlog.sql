CREATE TABLE [dbo].[iclock_errorcommandlog] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [error_code]  NVARCHAR (16)  NULL,
    [error_msg]   NVARCHAR (50)  NULL,
    [data_origin] NVARCHAR (MAX) NULL,
    [cmd]         NVARCHAR (50)  NULL,
    [additional]  NVARCHAR (MAX) NULL,
    [upload_time] DATETIME2 (7)  NOT NULL,
    [terminal_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_errorcommandlog_terminal_id_3b2d7cbd_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_errorcommandlog_terminal_id_3b2d7cbd]
    ON [dbo].[iclock_errorcommandlog]([terminal_id] ASC);

