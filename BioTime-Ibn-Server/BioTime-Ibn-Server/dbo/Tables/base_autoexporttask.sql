CREATE TABLE [dbo].[base_autoexporttask] (
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
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([task_code] ASC)
);

