CREATE TABLE [dbo].[workflow_nodeinstance] (
    [id]                   INT            IDENTITY (1, 1) NOT NULL,
    [node_name]            NVARCHAR (30)  NOT NULL,
    [order_id]             INT            NOT NULL,
    [approval_status]      SMALLINT       NOT NULL,
    [approval_time]        DATETIME2 (7)  NULL,
    [approval_remark]      NVARCHAR (255) NULL,
    [active]               BIT            NOT NULL,
    [targeted]             BIT            NOT NULL,
    [approver_employee_id] INT            NULL,
    [workflow_instance_id] INT            NULL,
    [workflow_node_id]     INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_nodeinstance_approver_employee_id_d36cd45d_fk_personnel_employee_id] FOREIGN KEY ([approver_employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [workflow_nodeinstance_workflow_instance_id_afe84fe4_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflow_instance_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id]),
    CONSTRAINT [workflow_nodeinstance_workflow_node_id_166f36c4_fk_workflow_workflownode_id] FOREIGN KEY ([workflow_node_id]) REFERENCES [dbo].[workflow_workflownode] ([id])
);


GO
CREATE NONCLUSTERED INDEX [workflow_nodeinstance_approver_employee_id_d36cd45d]
    ON [dbo].[workflow_nodeinstance]([approver_employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_nodeinstance_workflow_instance_id_afe84fe4]
    ON [dbo].[workflow_nodeinstance]([workflow_instance_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_nodeinstance_workflow_node_id_166f36c4]
    ON [dbo].[workflow_nodeinstance]([workflow_node_id] ASC);

