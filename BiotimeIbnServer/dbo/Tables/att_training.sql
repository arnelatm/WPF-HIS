CREATE TABLE [dbo].[att_training] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [start_time]              DATETIME2 (7)  NOT NULL,
    [end_time]                DATETIME2 (7)  NOT NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [apply_reason]            NVARCHAR (MAX) NULL,
    [attachment]              NVARCHAR (100) NULL,
    [pay_code_id]             INT            NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [att_training_pay_code_id_5790afdd_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    CONSTRAINT [att_training_workflowinstance_ptr_id_0aef1508_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_training_pay_code_id_5790afdd]
    ON [dbo].[att_training]([pay_code_id] ASC);

