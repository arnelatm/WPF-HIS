CREATE TABLE [dbo].[iclock_terminalworkcode] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [create_time]   DATETIME2 (7)  NULL,
    [create_user]   NVARCHAR (150) NULL,
    [change_time]   DATETIME2 (7)  NULL,
    [change_user]   NVARCHAR (150) NULL,
    [status]        SMALLINT       NOT NULL,
    [code]          NVARCHAR (8)   NOT NULL,
    [alias]         NVARCHAR (24)  NOT NULL,
    [last_activity] DATETIME2 (7)  NULL,
    [company_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_terminalworkcode_company_id_77625f26_fk_personnel_company_id] FOREIGN KEY ([company_id]) REFERENCES [dbo].[personnel_company] ([id]),
    UNIQUE NONCLUSTERED ([code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [iclock_terminalworkcode_company_id_77625f26]
    ON [dbo].[iclock_terminalworkcode]([company_id] ASC);

