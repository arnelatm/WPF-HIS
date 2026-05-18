CREATE TABLE [dbo].[visitor_visitortransaction] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [visitor_code]   NVARCHAR (50)  NOT NULL,
    [area]           NVARCHAR (30)  NOT NULL,
    [punch_time]     DATETIME2 (7)  NULL,
    [punch_state]    NVARCHAR (5)   NOT NULL,
    [verify_type]    INT            NOT NULL,
    [temperature]    NUMERIC (4, 1) NOT NULL,
    [is_mask]        INT            NOT NULL,
    [upload_time]    DATETIME2 (7)  NOT NULL,
    [source]         SMALLINT       NOT NULL,
    [terminal_sn]    NVARCHAR (50)  NULL,
    [terminal_alias] NVARCHAR (50)  NULL,
    [terminal_id]    INT            NULL,
    [visitor_id]     INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [visitor_visitortransaction_terminal_id_7527ef69_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id]),
    CONSTRAINT [visitor_visitortransaction_visitor_id_0ee95624_fk_visitor_visitor_id] FOREIGN KEY ([visitor_id]) REFERENCES [dbo].[visitor_visitor] ([id])
);


GO
CREATE NONCLUSTERED INDEX [visitor_visitortransaction_terminal_id_7527ef69]
    ON [dbo].[visitor_visitortransaction]([terminal_id] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [visitor_visitortransaction_visitor_code_punch_time_2b871513_uniq]
    ON [dbo].[visitor_visitortransaction]([visitor_code] ASC, [punch_time] ASC) WHERE ([visitor_code] IS NOT NULL AND [punch_time] IS NOT NULL);


GO
CREATE NONCLUSTERED INDEX [visitor_visitortransaction_visitor_id_0ee95624]
    ON [dbo].[visitor_visitortransaction]([visitor_id] ASC);

