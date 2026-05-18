CREATE TABLE [dbo].[att_departmentschedule] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [create_time]   DATETIME2 (7)  NULL,
    [create_user]   NVARCHAR (150) NULL,
    [change_time]   DATETIME2 (7)  NULL,
    [change_user]   NVARCHAR (150) NULL,
    [status]        SMALLINT       NOT NULL,
    [start_date]    DATE           NOT NULL,
    [end_date]      DATE           NOT NULL,
    [department_id] INT            NOT NULL,
    [shift_id]      INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_departmentschedule_department_id_c68fca3d_fk_personnel_department_id] FOREIGN KEY ([department_id]) REFERENCES [dbo].[personnel_department] ([id]),
    CONSTRAINT [att_departmentschedule_shift_id_c37d5ade_fk_att_attshift_id] FOREIGN KEY ([shift_id]) REFERENCES [dbo].[att_attshift] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_departmentschedule_shift_id_c37d5ade]
    ON [dbo].[att_departmentschedule]([shift_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_departmentschedule_department_id_c68fca3d]
    ON [dbo].[att_departmentschedule]([department_id] ASC);

