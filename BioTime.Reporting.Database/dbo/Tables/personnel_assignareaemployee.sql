CREATE TABLE [dbo].[personnel_assignareaemployee] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [assigned_time] DATETIME2 (7) NOT NULL,
    [area_id]       INT           NOT NULL,
    [employee_id]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_assignareaemployee_area_id_6f049d6a_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id]),
    CONSTRAINT [personnel_assignareaemployee_employee_id_a3d4dd25_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [personnel_assignareaemployee_employee_id_a3d4dd25]
    ON [dbo].[personnel_assignareaemployee]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_assignareaemployee_area_id_6f049d6a]
    ON [dbo].[personnel_assignareaemployee]([area_id] ASC);

