CREATE TABLE [dbo].[visitor_visitor] (
    [id]                   INT            IDENTITY (1, 1) NOT NULL,
    [create_time]          DATETIME2 (7)  NULL,
    [create_user]          NVARCHAR (150) NULL,
    [change_time]          DATETIME2 (7)  NULL,
    [change_user]          NVARCHAR (150) NULL,
    [status]               SMALLINT       NOT NULL,
    [visitor_code]         NVARCHAR (20)  NOT NULL,
    [first_name]           NVARCHAR (25)  NULL,
    [last_name]            NVARCHAR (25)  NULL,
    [cert_no]              NVARCHAR (50)  NOT NULL,
    [photo]                NVARCHAR (200) NULL,
    [password]             NVARCHAR (20)  NULL,
    [card_no]              NVARCHAR (20)  NULL,
    [gender]               NVARCHAR (1)   NULL,
    [company]              NVARCHAR (100) NULL,
    [ssn]                  NVARCHAR (20)  NULL,
    [update_time]          DATETIME2 (7)  NULL,
    [email]                NVARCHAR (50)  NULL,
    [mobile]               NVARCHAR (20)  NULL,
    [visit_quantity]       INT            NOT NULL,
    [entry_carrying_goods] NVARCHAR (200) NULL,
    [start_time]           DATETIME2 (7)  NOT NULL,
    [end_time]             DATETIME2 (7)  NOT NULL,
    [exit_time]            DATETIME2 (7)  NULL,
    [exit_carrying_goods]  NVARCHAR (200) NULL,
    [remark]               NVARCHAR (200) NULL,
    [cert_type_id]         INT            NOT NULL,
    [visit_department_id]  INT            NULL,
    [visit_reason_id]      INT            NULL,
    [visited_id]           INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [visitor_visitor_cert_type_id_f62ea604_fk_personnel_certification_id] FOREIGN KEY ([cert_type_id]) REFERENCES [dbo].[personnel_certification] ([id]),
    CONSTRAINT [visitor_visitor_visit_department_id_f7dbdcb4_fk_personnel_department_id] FOREIGN KEY ([visit_department_id]) REFERENCES [dbo].[personnel_department] ([id]),
    CONSTRAINT [visitor_visitor_visit_reason_id_4b9a2d23_fk_visitor_reason_id] FOREIGN KEY ([visit_reason_id]) REFERENCES [dbo].[visitor_reason] ([id]),
    CONSTRAINT [visitor_visitor_visited_id_8043a7ea_fk_personnel_employee_id] FOREIGN KEY ([visited_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    UNIQUE NONCLUSTERED ([visitor_code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_visit_department_id_f7dbdcb4]
    ON [dbo].[visitor_visitor]([visit_department_id] ASC);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_cert_type_id_f62ea604]
    ON [dbo].[visitor_visitor]([cert_type_id] ASC);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_visited_id_8043a7ea]
    ON [dbo].[visitor_visitor]([visited_id] ASC);


GO
CREATE NONCLUSTERED INDEX [visitor_visitor_visit_reason_id_4b9a2d23]
    ON [dbo].[visitor_visitor]([visit_reason_id] ASC);

