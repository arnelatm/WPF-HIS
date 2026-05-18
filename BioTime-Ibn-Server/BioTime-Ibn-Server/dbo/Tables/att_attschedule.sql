CREATE TABLE [dbo].[att_attschedule] (
    [id]          INT  IDENTITY (1, 1) NOT NULL,
    [start_date]  DATE NOT NULL,
    [end_date]    DATE NOT NULL,
    [employee_id] INT  NOT NULL,
    [shift_id]    INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_attschedule_employee_id_caa61686_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_attschedule_shift_id_13d2db9a_fk_att_attshift_id] FOREIGN KEY ([shift_id]) REFERENCES [dbo].[att_attshift] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_attschedule_employee_id_caa61686]
    ON [dbo].[att_attschedule]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_attschedule_shift_id_13d2db9a]
    ON [dbo].[att_attschedule]([shift_id] ASC);

