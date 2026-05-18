CREATE TABLE [dbo].[att_reporttemplate] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [create_time]       DATETIME2 (7)  NULL,
    [create_user]       NVARCHAR (150) NULL,
    [change_time]       DATETIME2 (7)  NULL,
    [change_user]       NVARCHAR (150) NULL,
    [status]            SMALLINT       NOT NULL,
    [report]            NVARCHAR (50)  NOT NULL,
    [template_name]     NVARCHAR (50)  NOT NULL,
    [template_value]    NVARCHAR (MAX) NOT NULL,
    [is_share]          BIT            NOT NULL,
    [is_auto_export]    BIT            NOT NULL,
    [fixed_date_period] BIT            NOT NULL,
    [language]          NVARCHAR (10)  NOT NULL,
    [builder_id]        INT            NULL,
    [employee_id]       INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_reporttemplate_builder_id_e1bb15c6_fk_auth_user_id] FOREIGN KEY ([builder_id]) REFERENCES [dbo].[auth_user] ([id]),
    CONSTRAINT [att_reporttemplate_employee_id_4f80d866_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_reporttemplate_builder_id_e1bb15c6]
    ON [dbo].[att_reporttemplate]([builder_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_reporttemplate_employee_id_4f80d866]
    ON [dbo].[att_reporttemplate]([employee_id] ASC);

