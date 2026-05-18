CREATE TABLE [dbo].[att_leave] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [start_time]              DATETIME2 (7)  NOT NULL,
    [end_time]                DATETIME2 (7)  NOT NULL,
    [apply_reason]            NVARCHAR (MAX) NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [attachment]              NVARCHAR (100) NULL,
    [leave_day]               FLOAT (53)     NOT NULL,
    [pay_code_id]             INT            NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [att_leave_pay_code_id_2fadf493_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    CONSTRAINT [att_leave_workflowinstance_ptr_id_39aaa9d9_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_leave_pay_code_id_2fadf493]
    ON [dbo].[att_leave]([pay_code_id] ASC);

