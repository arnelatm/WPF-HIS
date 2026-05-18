CREATE TABLE [dbo].[custom_att_fact_refresh_log] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [date_from]        DATE          NULL,
    [date_to]          DATE          NULL,
    [emp_id]           INT           NULL,
    [start_time]       DATETIME      NULL,
    [end_time]         DATETIME      NULL,
    [duration_seconds] INT           NULL,
    [rows_loaded]      INT           NULL,
    [status]           VARCHAR (20)  NULL,
    [remarks]          VARCHAR (500) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

