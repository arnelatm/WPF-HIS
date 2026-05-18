CREATE TABLE [dbo].[att_webpunch] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [punch_time]              DATETIME2 (7)  NOT NULL,
    [punch_state]             NVARCHAR (5)   NOT NULL,
    [work_code]               NVARCHAR (20)  NULL,
    [apply_reason]            NVARCHAR (MAX) NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [verify_type]             INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [att_webpunch_workflowinstance_ptr_id_c5f1c02e_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);

