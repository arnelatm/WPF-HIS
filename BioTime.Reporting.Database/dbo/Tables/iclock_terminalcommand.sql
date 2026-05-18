CREATE TABLE [dbo].[iclock_terminalcommand] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [content]       NVARCHAR (MAX) NOT NULL,
    [commit_time]   DATETIME2 (7)  NOT NULL,
    [transfer_time] DATETIME2 (7)  NULL,
    [return_time]   DATETIME2 (7)  NULL,
    [return_value]  INT            NULL,
    [package]       INT            NULL,
    [terminal_id]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_terminalcommand_terminal_id_3dcf836f_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_terminalcommand_terminal_id_3dcf836f]
    ON [dbo].[iclock_terminalcommand]([terminal_id] ASC);

