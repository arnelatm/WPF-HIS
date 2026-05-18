CREATE TABLE [dbo].[iclock_transactionproofcmd] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [action_time]    DATETIME2 (7) NOT NULL,
    [start_time]     DATETIME2 (7) NOT NULL,
    [end_time]       DATETIME2 (7) NOT NULL,
    [terminal_count] INT           NULL,
    [server_count]   INT           NULL,
    [flag]           SMALLINT      NULL,
    [reserved_init]  INT           NULL,
    [reserved_float] FLOAT (53)    NULL,
    [reserved_char]  NVARCHAR (30) NULL,
    [terminal_id]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_transactionproofcmd_terminal_id_08b81e1e_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_transactionproofcmd_terminal_id_08b81e1e]
    ON [dbo].[iclock_transactionproofcmd]([terminal_id] ASC);

