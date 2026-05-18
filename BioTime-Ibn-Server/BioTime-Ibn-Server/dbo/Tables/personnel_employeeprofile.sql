CREATE TABLE [dbo].[personnel_employeeprofile] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [column_order]    NVARCHAR (MAX) NOT NULL,
    [disabled_fields] NVARCHAR (MAX) NOT NULL,
    [preferences]     NVARCHAR (MAX) NOT NULL,
    [pwd_update_time] DATETIME2 (7)  NULL,
    [emp_id]          INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employeeprofile_emp_id_3a69c313_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([emp_id] ASC)
);

