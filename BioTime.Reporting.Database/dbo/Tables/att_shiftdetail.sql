CREATE TABLE [dbo].[att_shiftdetail] (
    [id]               INT      IDENTITY (1, 1) NOT NULL,
    [in_time]          TIME (7) NOT NULL,
    [out_time]         TIME (7) NOT NULL,
    [day_index]        INT      NOT NULL,
    [shift_id]         INT      NOT NULL,
    [time_interval_id] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_shiftdetail_shift_id_7d694501_fk_att_attshift_id] FOREIGN KEY ([shift_id]) REFERENCES [dbo].[att_attshift] ([id]),
    CONSTRAINT [att_shiftdetail_time_interval_id_777dde8f_fk_att_timeinterval_id] FOREIGN KEY ([time_interval_id]) REFERENCES [dbo].[att_timeinterval] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_shiftdetail_time_interval_id_777dde8f]
    ON [dbo].[att_shiftdetail]([time_interval_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_shiftdetail_shift_id_7d694501]
    ON [dbo].[att_shiftdetail]([shift_id] ASC);

