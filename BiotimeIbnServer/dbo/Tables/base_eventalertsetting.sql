CREATE TABLE [dbo].[base_eventalertsetting] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [create_user]    NVARCHAR (150) NULL,
    [change_time]    DATETIME2 (7)  NULL,
    [change_user]    NVARCHAR (150) NULL,
    [status]         SMALLINT       NOT NULL,
    [event_id]       INT            NOT NULL,
    [event]          NVARCHAR (50)  NOT NULL,
    [module]         NVARCHAR (50)  NOT NULL,
    [sub_module]     NVARCHAR (50)  NOT NULL,
    [email_alert]    BIT            NOT NULL,
    [app_alert]      BIT            NOT NULL,
    [sms_alert]      BIT            NOT NULL,
    [whatapp_alert]  BIT            NOT NULL,
    [facebook_alert] BIT            NOT NULL,
    [lineapp_alert]  BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

