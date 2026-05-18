CREATE TABLE [dbo].[base_dbbackuplog] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [create_time]   DATETIME2 (7)  NULL,
    [create_user]   NVARCHAR (150) NULL,
    [change_time]   DATETIME2 (7)  NULL,
    [change_user]   NVARCHAR (150) NULL,
    [status]        SMALLINT       NOT NULL,
    [db_type]       NVARCHAR (50)  NOT NULL,
    [db_name]       NVARCHAR (50)  NOT NULL,
    [operator]      NVARCHAR (50)  NULL,
    [backup_file]   NVARCHAR (100) NOT NULL,
    [backup_time]   DATETIME2 (7)  NOT NULL,
    [backup_status] SMALLINT       NOT NULL,
    [remark]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

