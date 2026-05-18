CREATE TABLE [dbo].[visitor_reservation] (
    [workflowinstance_ptr_id] INT            NOT NULL,
    [vis_first_name]          NVARCHAR (25)  NULL,
    [vis_last_name]           NVARCHAR (25)  NULL,
    [cert_no]                 NVARCHAR (50)  NOT NULL,
    [gender]                  NVARCHAR (1)   NULL,
    [company]                 NVARCHAR (100) NULL,
    [update_time]             DATETIME2 (7)  NULL,
    [visit_quantity]          INT            NOT NULL,
    [visit_date]              DATETIME2 (7)  NOT NULL,
    [apply_time]              DATETIME2 (7)  NOT NULL,
    [apply_reason]            NVARCHAR (MAX) NULL,
    [email]                   NVARCHAR (50)  NULL,
    [cert_type_id]            INT            NOT NULL,
    [visit_department_id]     INT            NULL,
    [visit_reason_id]         INT            NULL,
    PRIMARY KEY CLUSTERED ([workflowinstance_ptr_id] ASC),
    CONSTRAINT [visitor_reservation_cert_type_id_4f047f2a_fk_personnel_certification_id] FOREIGN KEY ([cert_type_id]) REFERENCES [dbo].[personnel_certification] ([id]),
    CONSTRAINT [visitor_reservation_visit_department_id_2d293e10_fk_personnel_department_id] FOREIGN KEY ([visit_department_id]) REFERENCES [dbo].[personnel_department] ([id]),
    CONSTRAINT [visitor_reservation_visit_reason_id_c9ac83ac_fk_visitor_reason_id] FOREIGN KEY ([visit_reason_id]) REFERENCES [dbo].[visitor_reason] ([id]),
    CONSTRAINT [visitor_reservation_workflowinstance_ptr_id_3787bcd6_fk_workflow_workflowinstance_id] FOREIGN KEY ([workflowinstance_ptr_id]) REFERENCES [dbo].[workflow_workflowinstance] ([id])
);


GO
CREATE NONCLUSTERED INDEX [visitor_reservation_cert_type_id_4f047f2a]
    ON [dbo].[visitor_reservation]([cert_type_id] ASC);


GO
CREATE NONCLUSTERED INDEX [visitor_reservation_visit_department_id_2d293e10]
    ON [dbo].[visitor_reservation]([visit_department_id] ASC);


GO
CREATE NONCLUSTERED INDEX [visitor_reservation_visit_reason_id_c9ac83ac]
    ON [dbo].[visitor_reservation]([visit_reason_id] ASC);

