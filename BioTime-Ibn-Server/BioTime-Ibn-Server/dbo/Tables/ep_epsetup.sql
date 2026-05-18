CREATE TABLE [dbo].[ep_epsetup] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [temp_alarm]     BIT            NOT NULL,
    [temp_warning]   NUMERIC (4, 1) NOT NULL,
    [temp_warning_F] NUMERIC (4, 1) NULL,
    [temp_unit]      SMALLINT       NOT NULL,
    [mask_alarm]     BIT            NOT NULL,
    [is_default]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

