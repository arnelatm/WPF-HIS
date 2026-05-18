CREATE TABLE [dbo].[ep_eptransaction] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [emp_code]       NVARCHAR (50)  NOT NULL,
    [area]           NVARCHAR (30)  NOT NULL,
    [check_datetime] DATETIME2 (7)  NULL,
    [check_date]     DATE           NOT NULL,
    [check_time]     TIME (7)       NOT NULL,
    [temperature]    NUMERIC (4, 1) NOT NULL,
    [is_mask]        INT            NOT NULL,
    [upload_time]    DATETIME2 (7)  NOT NULL,
    [source]         SMALLINT       NOT NULL,
    [terminal_sn]    NVARCHAR (50)  NULL,
    [emp_id]         INT            NULL,
    [terminal_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [ep_eptransaction_emp_id_1006883f_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [ep_eptransaction_terminal_id_4490b209_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [ep_eptransaction_terminal_id_4490b209]
    ON [dbo].[ep_eptransaction]([terminal_id] ASC);


GO
CREATE NONCLUSTERED INDEX [ep_eptransaction_emp_id_1006883f]
    ON [dbo].[ep_eptransaction]([emp_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [ep_eptransaction_emp_code_check_datetime_0b54f31f_uniq]
    ON [dbo].[ep_eptransaction]([emp_code] ASC, [check_datetime] ASC) WHERE ([emp_code] IS NOT NULL AND [check_datetime] IS NOT NULL);

