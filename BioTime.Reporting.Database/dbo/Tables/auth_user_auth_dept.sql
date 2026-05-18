CREATE TABLE [dbo].[auth_user_auth_dept] (
    [id]            INT IDENTITY (1, 1) NOT NULL,
    [myuser_id]     INT NOT NULL,
    [department_id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_user_auth_dept_department_id_5866c514_fk_personnel_department_id] FOREIGN KEY ([department_id]) REFERENCES [dbo].[personnel_department] ([id]),
    CONSTRAINT [auth_user_auth_dept_myuser_id_18a51b27_fk_auth_user_id] FOREIGN KEY ([myuser_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [auth_user_auth_dept_myuser_id_department_id_61d83386_uniq]
    ON [dbo].[auth_user_auth_dept]([myuser_id] ASC, [department_id] ASC) WHERE ([myuser_id] IS NOT NULL AND [department_id] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [auth_user_auth_dept_department_id_5866c514]
    ON [dbo].[auth_user_auth_dept]([department_id] ASC);


GO
CREATE NONCLUSTERED INDEX [auth_user_auth_dept_myuser_id_18a51b27]
    ON [dbo].[auth_user_auth_dept]([myuser_id] ASC);

