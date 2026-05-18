CREATE TABLE [dbo].[att_manuallog] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [punch_time]              DATETIME2 (7)  NOT NULL,
    [punch_state]             NVARCHAR (5)   NOT NULL,
    [apply_reason]            NVARCHAR (MAX) NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [attachment]              NVARCHAR (100) NULL,
    [work_code_id]            INT            NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [att_manuallog_work_code_id_09ac4580_fk_iclock_terminalworkcode_id] FOREIGN KEY ([work_code_id]) REFERENCES [dbo].[iclock_terminalworkcode] ([id]),
    CONSTRAINT [att_manuallog_workflowinstance_ptr_id_22a3fbd0_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_manuallog_work_code_id_09ac4580]
    ON [dbo].[att_manuallog]([work_code_id] ASC);

