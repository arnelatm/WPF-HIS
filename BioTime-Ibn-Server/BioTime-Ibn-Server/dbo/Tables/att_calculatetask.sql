CREATE TABLE [dbo].[att_calculatetask] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [emp]        INT            NOT NULL,
    [start_date] DATETIME2 (7)  NOT NULL,
    [end_date]   DATETIME2 (7)  NOT NULL,
    [event]      NVARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [att_calculatetask_end_date_75d1d6d2]
    ON [dbo].[att_calculatetask]([end_date] ASC);


GO
CREATE NONCLUSTERED INDEX [att_calculatetask_start_date_7bbaa889]
    ON [dbo].[att_calculatetask]([start_date] ASC);

