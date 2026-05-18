CREATE TABLE [dbo].[att_timeinterval_break_time] (
    [id]              INT IDENTITY (1, 1) NOT NULL,
    [timeinterval_id] INT NOT NULL,
    [breaktime_id]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_timeinterval_break_time_breaktime_id_08462308_fk_att_breaktime_id] FOREIGN KEY ([breaktime_id]) REFERENCES [dbo].[att_breaktime] ([id]),
    CONSTRAINT [att_timeinterval_break_time_timeinterval_id_2287017e_fk_att_timeinterval_id] FOREIGN KEY ([timeinterval_id]) REFERENCES [dbo].[att_timeinterval] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [att_timeinterval_break_time_timeinterval_id_breaktime_id_6e1bfb4e_uniq]
    ON [dbo].[att_timeinterval_break_time]([timeinterval_id] ASC, [breaktime_id] ASC) WHERE ([timeinterval_id] IS NOT NULL AND [breaktime_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [att_timeinterval_break_time_timeinterval_id_2287017e]
    ON [dbo].[att_timeinterval_break_time]([timeinterval_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_timeinterval_break_time_breaktime_id_08462308]
    ON [dbo].[att_timeinterval_break_time]([breaktime_id] ASC);

