CREATE TABLE [dbo].[visitor_reason] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [create_time]  DATETIME2 (7)  NULL,
    [create_user]  NVARCHAR (150) NULL,
    [change_time]  DATETIME2 (7)  NULL,
    [change_user]  NVARCHAR (150) NULL,
    [status]       SMALLINT       NOT NULL,
    [visit_reason] NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

