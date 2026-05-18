CREATE TABLE [dbo].[workflow_workflownode_approver] (
    [id]              INT IDENTITY (1, 1) NOT NULL,
    [workflownode_id] INT NOT NULL,
    [workflowrole_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_workflownode_approver_workflownode_id_d814c941_fk_workflow_workflownode_id] FOREIGN KEY ([workflownode_id]) REFERENCES [dbo].[workflow_workflownode] ([id]),
    CONSTRAINT [workflow_workflownode_approver_workflowrole_id_c8e00d42_fk_workflow_workflowrole_id] FOREIGN KEY ([workflowrole_id]) REFERENCES [dbo].[workflow_workflowrole] ([id])
);


GO
CREATE NONCLUSTERED INDEX [workflow_workflownode_approver_workflownode_id_d814c941]
    ON [dbo].[workflow_workflownode_approver]([workflownode_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [workflow_workflownode_approver_workflownode_id_workflowrole_id_7543ba37_uniq]
    ON [dbo].[workflow_workflownode_approver]([workflownode_id] ASC, [workflowrole_id] ASC) WHERE ([workflownode_id] IS NOT NULL AND [workflowrole_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [workflow_workflownode_approver_workflowrole_id_c8e00d42]
    ON [dbo].[workflow_workflownode_approver]([workflowrole_id] ASC);

