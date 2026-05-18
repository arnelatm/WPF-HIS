CREATE TABLE [dbo].[workflow_workflownode_notifier] (
    [id]              INT IDENTITY (1, 1) NOT NULL,
    [workflownode_id] INT NOT NULL,
    [workflowrole_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_workflownode_notifier_workflownode_id_57298016_fk_workflow_workflownode_id] FOREIGN KEY ([workflownode_id]) REFERENCES [dbo].[workflow_workflownode] ([id]),
    CONSTRAINT [workflow_workflownode_notifier_workflowrole_id_73de7fc2_fk_workflow_workflowrole_id] FOREIGN KEY ([workflowrole_id]) REFERENCES [dbo].[workflow_workflowrole] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [workflow_workflownode_notifier_workflownode_id_workflowrole_id_cac02b37_uniq]
    ON [dbo].[workflow_workflownode_notifier]([workflownode_id] ASC, [workflowrole_id] ASC) WHERE ([workflownode_id] IS NOT NULL AND [workflowrole_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [workflow_workflownode_notifier_workflowrole_id_73de7fc2]
    ON [dbo].[workflow_workflownode_notifier]([workflowrole_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflownode_notifier_workflownode_id_57298016]
    ON [dbo].[workflow_workflownode_notifier]([workflownode_id] ASC);

