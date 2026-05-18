CREATE TABLE [dbo].[iclock_terminalparameter] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [param_type]  NVARCHAR (10)  NULL,
    [param_name]  NVARCHAR (30)  NOT NULL,
    [param_value] NVARCHAR (100) NOT NULL,
    [terminal_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_terminalparameter_terminal_id_443872e3_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_terminalparameter_terminal_id_443872e3]
    ON [dbo].[iclock_terminalparameter]([terminal_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [iclock_terminalparameter_terminal_id_param_name_8abbb5c0_uniq]
    ON [dbo].[iclock_terminalparameter]([terminal_id] ASC, [param_name] ASC) WHERE ([terminal_id] IS NOT NULL AND [param_name] IS NOT NULL);

