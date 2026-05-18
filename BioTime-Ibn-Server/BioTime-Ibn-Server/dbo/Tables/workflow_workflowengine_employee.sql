CREATE TABLE [dbo].[workflow_workflowengine_employee] (
    [id]                INT IDENTITY (1, 1) NOT NULL,
    [workflowengine_id] INT NOT NULL,
    [employee_id]       INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_workflowengine_employee_employee_id_803a409e_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [workflow_workflowengine_employee_workflowengine_id_6ebcc5f2_fk_workflow_workflowengine_id] FOREIGN KEY ([workflowengine_id]) REFERENCES [dbo].[workflow_workflowengine] ([id])
);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowengine_employee_employee_id_803a409e]
    ON [dbo].[workflow_workflowengine_employee]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowengine_employee_workflowengine_id_6ebcc5f2]
    ON [dbo].[workflow_workflowengine_employee]([workflowengine_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [workflow_workflowengine_employee_workflowengine_id_employee_id_8128deb2_uniq]
    ON [dbo].[workflow_workflowengine_employee]([workflowengine_id] ASC, [employee_id] ASC) WHERE ([workflowengine_id] IS NOT NULL AND [employee_id] IS NOT NULL);

