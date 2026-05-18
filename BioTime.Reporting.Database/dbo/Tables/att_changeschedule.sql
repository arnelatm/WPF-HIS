CREATE TABLE [dbo].[att_changeschedule] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [att_date]                DATE           NOT NULL,
    [previous_timeinterval]   NVARCHAR (100) NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [apply_reason]            NVARCHAR (200) NULL,
    [attachment]              NVARCHAR (100) NULL,
    [timeinterval_id]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [att_changeschedule_timeinterval_id_d41ac077_fk_att_timeinterval_id] FOREIGN KEY ([timeinterval_id]) REFERENCES [dbo].[att_timeinterval] ([id]),
    CONSTRAINT [att_changeschedule_workflowinstance_ptr_id_cee602bb_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_changeschedule_timeinterval_id_d41ac077]
    ON [dbo].[att_changeschedule]([timeinterval_id] ASC);

