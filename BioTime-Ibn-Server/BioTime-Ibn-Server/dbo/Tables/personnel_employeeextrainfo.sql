CREATE TABLE [dbo].[personnel_employeeextrainfo] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [value]       NVARCHAR (MAX) NOT NULL,
    [employee_id] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employeeextrainfo_employee_id_41e2b04d_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([employee_id] ASC)
);

