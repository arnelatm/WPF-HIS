CREATE TABLE [dbo].[mobile_appnotification] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [sender]            NVARCHAR (50)  NULL,
    [system_sender]     NVARCHAR (50)  NULL,
    [category]          SMALLINT       NOT NULL,
    [sub_category]      INT            NULL,
    [content]           NVARCHAR (MAX) NULL,
    [payload]           NVARCHAR (MAX) NULL,
    [source]            INT            NULL,
    [notification_time] DATETIME2 (7)  NOT NULL,
    [read_status]       SMALLINT       NOT NULL,
    [read_time]         DATETIME2 (7)  NULL,
    [admin_id]          INT            NULL,
    [init_sender_id]    INT            NULL,
    [receiver_id]       INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [mobile_appnotification_admin_id_29c27197_fk_auth_user_id] FOREIGN KEY ([admin_id]) REFERENCES [dbo].[auth_user] ([id]),
    CONSTRAINT [mobile_appnotification_init_sender_id_d8aff845_fk_personnel_employee_id] FOREIGN KEY ([init_sender_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [mobile_appnotification_receiver_id_90c4a355_fk_personnel_employee_id] FOREIGN KEY ([receiver_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [mobile_appnotification_admin_id_29c27197]
    ON [dbo].[mobile_appnotification]([admin_id] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_appnotification_init_sender_id_d8aff845]
    ON [dbo].[mobile_appnotification]([init_sender_id] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_appnotification_receiver_id_90c4a355]
    ON [dbo].[mobile_appnotification]([receiver_id] ASC);

