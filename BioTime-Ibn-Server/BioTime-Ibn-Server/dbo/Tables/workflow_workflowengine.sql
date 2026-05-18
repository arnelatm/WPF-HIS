CREATE TABLE [dbo].[workflow_workflowengine] (
    [id]                    INT           IDENTITY (1, 1) NOT NULL,
    [workflow_code]         NVARCHAR (50) NOT NULL,
    [workflow_name]         NVARCHAR (50) NOT NULL,
    [start_date]            DATE          NOT NULL,
    [end_date]              DATE          NOT NULL,
    [description]           NVARCHAR (50) NOT NULL,
    [workflow_type]         SMALLINT      NOT NULL,
    [is_leave]              BIT           NOT NULL,
    [applicant_position_id] INT           NULL,
    [company_id]            INT           NOT NULL,
    [content_type_id]       INT           NULL,
    [departments_id]        INT           NULL,
    [leave_type_id]         INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [workflow_workflowengine_applicant_position_id_8a65e03a_fk_personnel_position_id] FOREIGN KEY ([applicant_position_id]) REFERENCES [dbo].[personnel_position] ([id]),
    CONSTRAINT [workflow_workflowengine_company_id_c42adcb0_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [workflow_workflowengine_content_type_id_f7345c20_fk_django_content_type_id] FOREIGN KEY ([content_type_id]) REFERENCES [dbo].[django_content_type] ([id]),
    CONSTRAINT [workflow_workflowengine_departments_id_0f06d4c7_fk_personnel_department_id] FOREIGN KEY ([departments_id]) REFERENCES [dbo].[personnel_department] ([id]),
    CONSTRAINT [workflow_workflowengine_leave_type_id_7f03c9cc_fk_att_paycode_id] FOREIGN KEY ([leave_type_id]) REFERENCES [dbo].[att_paycode] ([id]),
    UNIQUE NONCLUSTERED ([workflow_code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowengine_applicant_position_id_8a65e03a]
    ON [dbo].[workflow_workflowengine]([applicant_position_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowengine_company_id_c42adcb0]
    ON [dbo].[workflow_workflowengine]([company_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowengine_content_type_id_f7345c20]
    ON [dbo].[workflow_workflowengine]([content_type_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowengine_departments_id_0f06d4c7]
    ON [dbo].[workflow_workflowengine]([departments_id] ASC);


GO
CREATE NONCLUSTERED INDEX [workflow_workflowengine_leave_type_id_7f03c9cc]
    ON [dbo].[workflow_workflowengine]([leave_type_id] ASC);

