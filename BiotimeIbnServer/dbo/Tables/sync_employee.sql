CREATE TABLE [dbo].[sync_employee] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [post_time]     DATETIME2 (7)  NULL,
    [flag]          SMALLINT       NOT NULL,
    [update_time]   DATETIME2 (7)  NULL,
    [sync_ret]      NVARCHAR (200) NULL,
    [emp_code]      NVARCHAR (20)  NOT NULL,
    [first_name]    NVARCHAR (100) NULL,
    [last_name]     NVARCHAR (100) NULL,
    [dept_code]     NVARCHAR (50)  NULL,
    [dept_name]     NVARCHAR (200) NULL,
    [job_code]      NVARCHAR (50)  NULL,
    [job_name]      NVARCHAR (100) NULL,
    [area_code]     NVARCHAR (30)  NULL,
    [area_name]     NVARCHAR (100) NULL,
    [card_no]       NVARCHAR (20)  NULL,
    [multi_area]    BIT            NOT NULL,
    [hire_date]     DATE           NULL,
    [gender]        NVARCHAR (2)   NULL,
    [birthday]      DATE           NULL,
    [email]         NVARCHAR (100) NULL,
    [active_status] BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [sync_employee_emp_code_521bf06d_uniq]
    ON [dbo].[sync_employee]([emp_code] ASC) WHERE ([emp_code] IS NOT NULL);

