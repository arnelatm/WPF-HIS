CREATE TABLE [dbo].[att_attgroup] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [code]        NVARCHAR (50)  NOT NULL,
    [name]        NVARCHAR (100) NOT NULL,
    [company_id]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_attgroup_company_id_cd1b54f8_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_attgroup_company_id_cd1b54f8]
    ON [dbo].[att_attgroup]([company_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [att_attgroup_company_id_code_0e94d13b_uniq]
    ON [dbo].[att_attgroup]([company_id] ASC, [code] ASC) WHERE ([company_id] IS NOT NULL AND [code] IS NOT NULL);

