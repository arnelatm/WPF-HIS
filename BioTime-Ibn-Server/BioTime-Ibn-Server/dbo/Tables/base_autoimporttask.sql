CREATE TABLE [dbo].[base_autoimporttask] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [create_time]  DATETIME2 (7)  NULL,
    [create_user]  NVARCHAR (150) NULL,
    [change_time]  DATETIME2 (7)  NULL,
    [change_user]  NVARCHAR (150) NULL,
    [status]       SMALLINT       NOT NULL,
    [task_code]    NVARCHAR (30)  NOT NULL,
    [task_name]    NVARCHAR (30)  NOT NULL,
    [params]       NVARCHAR (MAX) NULL,
    [enable]       BIT            NOT NULL,
    [process_time] DATETIME2 (7)  NULL,
    [company_id]   INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [base_autoimporttask_company_id_d18431a1_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    UNIQUE NONCLUSTERED ([task_code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [base_autoimporttask_company_id_d18431a1]
    ON [dbo].[base_autoimporttask]([company_id] ASC);

