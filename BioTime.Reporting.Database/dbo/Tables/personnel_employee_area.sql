CREATE TABLE [dbo].[personnel_employee_area] (
    [id]          INT IDENTITY (1, 1) NOT NULL,
    [employee_id] INT NOT NULL,
    [area_id]     INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employee_area_area_id_64c21925_fk_personnel_area_id] FOREIGN KEY ([area_id]) REFERENCES [dbo].[personnel_area] ([id]),
    CONSTRAINT [personnel_employee_area_employee_id_8e5cec21_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_employee_area_employee_id_area_id_00b3d777_uniq]
    ON [dbo].[personnel_employee_area]([employee_id] ASC, [area_id] ASC) WHERE ([employee_id] IS NOT NULL AND [area_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_area_employee_id_8e5cec21]
    ON [dbo].[personnel_employee_area]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_area_area_id_64c21925]
    ON [dbo].[personnel_employee_area]([area_id] ASC);

