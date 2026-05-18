CREATE TABLE [dbo].[att_overtime] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [overtime_type]           SMALLINT       NOT NULL,
    [start_time]              DATETIME2 (7)  NOT NULL,
    [end_time]                DATETIME2 (7)  NOT NULL,
    [apply_reason]            NVARCHAR (MAX) NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [attachment]              NVARCHAR (100) NULL,
    [pay_code_id]             INT            NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [att_overtime_pay_code_id_05600ee0_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id]),
    CONSTRAINT [att_overtime_workflowinstance_ptr_id_6bd6a6f4_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_overtime_pay_code_id_05600ee0]
    ON [dbo].[att_overtime]([pay_code_id] ASC);

