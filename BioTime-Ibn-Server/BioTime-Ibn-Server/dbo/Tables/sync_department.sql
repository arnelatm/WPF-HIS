CREATE TABLE [dbo].[sync_department] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [post_time]   DATETIME2 (7)  NULL,
    [flag]        SMALLINT       NOT NULL,
    [update_time] DATETIME2 (7)  NULL,
    [sync_ret]    NVARCHAR (200) NULL,
    [dept_code]   NVARCHAR (50)  NOT NULL,
    [dept_name]   NVARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [sync_department_dept_code_dept_name_93923213_uniq]
    ON [dbo].[sync_department]([dept_code] ASC, [dept_name] ASC) WHERE ([dept_code] IS NOT NULL AND [dept_name] IS NOT NULL);

