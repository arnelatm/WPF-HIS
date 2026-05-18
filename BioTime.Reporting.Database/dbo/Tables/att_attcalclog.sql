CREATE TABLE [dbo].[att_attcalclog] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [dept_id]     INT           NULL,
    [emp_id]      INT           NULL,
    [start_date]  DATETIME2 (7) NOT NULL,
    [end_date]    DATETIME2 (7) NOT NULL,
    [update_time] DATETIME2 (7) NOT NULL,
    [log_type]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

