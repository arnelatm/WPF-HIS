CREATE TABLE [dbo].[visitor_visitorconfig] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [create_time]      DATETIME2 (7)  NULL,
    [create_user]      NVARCHAR (150) NULL,
    [change_time]      DATETIME2 (7)  NULL,
    [change_user]      NVARCHAR (150) NULL,
    [status]           SMALLINT       NOT NULL,
    [qr_code_policy]   SMALLINT       NOT NULL,
    [code_prefix]      NVARCHAR (5)   NOT NULL,
    [code_width]       INT            NOT NULL,
    [code_start]       INT            NOT NULL,
    [auto_delete_data] SMALLINT       NOT NULL,
    [data_retention]   INT            NOT NULL,
    [access_limited]   NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

