CREATE TABLE [dbo].[personnel_employee_flow_role] (
    [id]              INT IDENTITY (1, 1) NOT NULL,
    [employee_id]     INT NOT NULL,
    [workflowrole_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employee_flow_role_employee_id_c27f8a56_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [personnel_employee_flow_role_workflowrole_id_4704db32_fk_workflow_workflowrole_id] FOREIGN KEY ([workflowrole_id]) REFERENCES [dbo].[workflow_workflowrole] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_employee_flow_role_employee_id_workflowrole_id_46b0e5e0_uniq]
    ON [dbo].[personnel_employee_flow_role]([employee_id] ASC, [workflowrole_id] ASC) WHERE ([employee_id] IS NOT NULL AND [workflowrole_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_flow_role_employee_id_c27f8a56]
    ON [dbo].[personnel_employee_flow_role]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_flow_role_workflowrole_id_4704db32]
    ON [dbo].[personnel_employee_flow_role]([workflowrole_id] ASC);

