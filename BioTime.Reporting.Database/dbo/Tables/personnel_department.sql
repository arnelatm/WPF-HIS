CREATE TABLE [dbo].[personnel_department] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [dept_code]       NVARCHAR (50)  NOT NULL,
    [dept_name]       NVARCHAR (200) NOT NULL,
    [is_default]      BIT            NOT NULL,
    [company_id]      INT            NOT NULL,
    [dept_manager_id] INT            NULL,
    [parent_dept_id]  INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_department_company_id_00867fd8_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [personnel_department_dept_manager_id_c5124a7d_fk_personnel_employee_id] FOREIGN KEY ([dept_manager_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [personnel_department_parent_dept_id_d0b44024_fk_personnel_department_id] FOREIGN KEY ([parent_dept_id]) REFERENCES [dbo].[personnel_department] ([id])
);


GO
CREATE NONCLUSTERED INDEX [personnel_department_parent_dept_id_d0b44024]
    ON [dbo].[personnel_department]([parent_dept_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_department_dept_manager_id_c5124a7d]
    ON [dbo].[personnel_department]([dept_manager_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_department_company_id_00867fd8]
    ON [dbo].[personnel_department]([company_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_department_company_id_dept_code_dfa8fff7_uniq]
    ON [dbo].[personnel_department]([company_id] ASC, [dept_code] ASC) WHERE ([company_id] IS NOT NULL AND [dept_code] IS NOT NULL);

