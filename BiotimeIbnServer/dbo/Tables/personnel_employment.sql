CREATE TABLE [dbo].[personnel_employment] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [employment_type] SMALLINT      NOT NULL,
    [start_date]      DATE          NOT NULL,
    [end_date]        DATE          NOT NULL,
    [active_time]     DATETIME2 (7) NULL,
    [inactive_time]   DATETIME2 (7) NULL,
    [employee_id]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employment_employee_id_f797c7d9_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([employee_id] ASC)
);

