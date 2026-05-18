CREATE TABLE [dbo].[workflow_workflowinstance] (
    [id]                 INT            IDENTITY (1, 1) NOT NULL,
    [approval_time]      DATETIME2 (7)  NULL,
    [approval_status]    SMALLINT       NOT NULL,
    [approval_remark]    NVARCHAR (MAX) NULL,
    [approver]           NVARCHAR (30)  NULL,
    [approver_instance]  NVARCHAR (MAX) NULL,
    [employee_id]        INT            NOT NULL,
    [workflow_engine_id] INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_workflowinstance_employee_id_c7cff08e_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [workflow_workflowinstance_workflow_engine_id_1e6ac40f_fk_workflow_workflowengine_id] FOREIGN KEY ([workflow_engine_id]) REFERENCES [dbo].[workflow_workflowengine] ([id])
);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowinstance_workflow_engine_id_1e6ac40f]
    ON [dbo].[workflow_workflowinstance]([workflow_engine_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowinstance_employee_id_c7cff08e]
    ON [dbo].[workflow_workflowinstance]([employee_id] ASC);

