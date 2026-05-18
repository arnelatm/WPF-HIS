CREATE TABLE [dbo].[iclock_biophoto] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [first_name]     NVARCHAR (100) NULL,
    [last_name]      NVARCHAR (100) NULL,
    [email]          NVARCHAR (254) NULL,
    [enroll_sn]      NVARCHAR (50)  NULL,
    [register_photo] NVARCHAR (100) NOT NULL,
    [register_time]  DATETIME2 (7)  NOT NULL,
    [approval_photo] NVARCHAR (100) NULL,
    [approval_state] SMALLINT       NOT NULL,
    [approval_time]  DATETIME2 (7)  NULL,
    [remark]         NVARCHAR (100) NULL,
    [employee_id]    INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_biophoto_employee_id_3dba5819_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_biophoto_employee_id_3dba5819]
    ON [dbo].[iclock_biophoto]([employee_id] ASC);

