CREATE TABLE [dbo].[att_leavegroup] (
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
    CONSTRAINT [att_leavegroup_company_id_a1c75fcb_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    UNIQUE NONCLUSTERED ([code] ASC),
    UNIQUE NONCLUSTERED ([name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [att_leavegroup_company_id_a1c75fcb]
    ON [dbo].[att_leavegroup]([company_id] ASC);

