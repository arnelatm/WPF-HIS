CREATE TABLE [dbo].[workflow_workflownode] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [node_name]           NVARCHAR (30) NOT NULL,
    [order_id]            INT           NOT NULL,
    [approver_by_overall] BIT           NOT NULL,
    [notify_by_overall]   BIT           NOT NULL,
    [from_day]            INT           NULL,
    [to_day]              INT           NULL,
    [workflow_engine_id]  INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_workflownode_workflow_engine_id_04c8f470_fk_workflow_workflowengine_id] FOREIGN KEY ([workflow_engine_id]) REFERENCES [dbo].[workflow_workflowengine] ([id])
);


GO
CREATE NONCLUSTERED INDEX [workflow_workflownode_workflow_engine_id_04c8f470]
    ON [dbo].[workflow_workflownode]([workflow_engine_id] ASC);

