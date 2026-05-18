CREATE TABLE [dbo].[att_attemployee] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [create_time]         DATETIME2 (7)  NULL,
    [create_user]         NVARCHAR (150) NULL,
    [change_time]         DATETIME2 (7)  NULL,
    [change_user]         NVARCHAR (150) NULL,
    [status]              SMALLINT       NOT NULL,
    [enable_attendance]   BIT            NOT NULL,
    [enable_schedule]     BIT            NOT NULL,
    [enable_overtime]     BIT            NOT NULL,
    [enable_holiday]      BIT            NOT NULL,
    [enable_compensatory] BIT            NOT NULL,
    [ip_address]          NVARCHAR (39)  NULL,
    [emp_id]              INT            NOT NULL,
    [group_id]            INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_attemployee_emp_id_52457e3c_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [att_attemployee_group_id_18d3954d_fk_att_attgroup_id] FOREIGN KEY ([group_id]) REFERENCES [dbo].[att_attgroup] ([id]),
    UNIQUE NONCLUSTERED ([emp_id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [att_attemployee_group_id_18d3954d]
    ON [dbo].[att_attemployee]([group_id] ASC);

