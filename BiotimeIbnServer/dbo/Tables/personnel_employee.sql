CREATE TABLE [dbo].[personnel_employee] (
    [id]                        INT            IDENTITY (1, 1) NOT NULL,
    [create_time]               DATETIME2 (7)  NULL,
    [create_user]               NVARCHAR (150) NULL,
    [change_time]               DATETIME2 (7)  NULL,
    [change_user]               NVARCHAR (150) NULL,
    [status]                    SMALLINT       NOT NULL,
    [device_password]           NVARCHAR (20)  NULL,
    [dev_privilege]             INT            NULL,
    [card_no]                   NVARCHAR (20)  NULL,
    [acc_group]                 NVARCHAR (5)   NULL,
    [acc_timezone]              NVARCHAR (20)  NULL,
    [enroll_sn]                 NVARCHAR (20)  NULL,
    [verify_mode]               INT            NULL,
    [app_status]                SMALLINT       NULL,
    [app_role]                  SMALLINT       NULL,
    [last_login]                DATETIME2 (7)  NULL,
    [is_active]                 BIT            NOT NULL,
    [session_key]               NVARCHAR (32)  NULL,
    [login_ip]                  NVARCHAR (32)  NULL,
    [emp_code]                  NVARCHAR (20)  NOT NULL,
    [emp_code_digit]            BIGINT         NULL,
    [first_name]                NVARCHAR (100) NULL,
    [last_name]                 NVARCHAR (100) NULL,
    [nickname]                  NVARCHAR (100) NULL,
    [passport]                  NVARCHAR (30)  NULL,
    [driver_license_automobile] NVARCHAR (30)  NULL,
    [driver_license_motorcycle] NVARCHAR (30)  NULL,
    [photo]                     NVARCHAR (200) NULL,
    [self_password]             NVARCHAR (128) NULL,
    [gender]                    NVARCHAR (1)   NULL,
    [birthday]                  DATE           NULL,
    [address]                   NVARCHAR (200) NULL,
    [postcode]                  NVARCHAR (10)  NULL,
    [office_tel]                NVARCHAR (20)  NULL,
    [contact_tel]               NVARCHAR (20)  NULL,
    [mobile]                    NVARCHAR (20)  NULL,
    [national]                  NVARCHAR (50)  NULL,
    [religion]                  NVARCHAR (20)  NULL,
    [title]                     NVARCHAR (20)  NULL,
    [ssn]                       NVARCHAR (20)  NULL,
    [update_time]               DATETIME2 (7)  NULL,
    [hire_date]                 DATE           NULL,
    [city]                      NVARCHAR (20)  NULL,
    [emp_type]                  SMALLINT       NULL,
    [enable_payroll]            BIT            NOT NULL,
    [email]                     NVARCHAR (50)  NULL,
    [leave_group]               INT            NULL,
    [company_id]                INT            NOT NULL,
    [department_id]             INT            NULL,
    [position_id]               INT            NULL,
    [superior_id]               INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [personnel_employee_company_id_95b3fd72_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    CONSTRAINT [personnel_employee_department_id_068bbd08_fk_personnel_department_id] FOREIGN KEY ([department_id]) REFERENCES [dbo].[personnel_department] ([id]),
    CONSTRAINT [personnel_employee_position_id_c9321343_fk_personnel_position_id] FOREIGN KEY ([position_id]) REFERENCES [dbo].[personnel_position] ([id]),
    CONSTRAINT [personnel_employee_superior_id_ad6e1c47_fk_personnel_employee_id] FOREIGN KEY ([superior_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_company_id_95b3fd72]
    ON [dbo].[personnel_employee]([company_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [personnel_employee_company_id_emp_code_81daa575_uniq]
    ON [dbo].[personnel_employee]([company_id] ASC, [emp_code] ASC) WHERE ([company_id] IS NOT NULL AND [emp_code] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_department_id_068bbd08]
    ON [dbo].[personnel_employee]([department_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_position_id_c9321343]
    ON [dbo].[personnel_employee]([position_id] ASC);


GO
CREATE NONCLUSTERED INDEX [personnel_employee_superior_id_ad6e1c47]
    ON [dbo].[personnel_employee]([superior_id] ASC);

