CREATE TABLE [dbo].[mobile_announcement] (
    [id]             INT            IDENTITY (1, 1) NOT NULL,
    [subject]        NVARCHAR (100) NOT NULL,
    [content]        NVARCHAR (MAX) NOT NULL,
    [category]       SMALLINT       NOT NULL,
    [sender]         NVARCHAR (50)  NULL,
    [system_sender]  NVARCHAR (50)  NULL,
    [create_time]    DATETIME2 (7)  NULL,
    [admin_id]       INT            NULL,
    [init_sender_id] INT            NULL,
    [receiver_id]    INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [mobile_announcement_admin_id_6af3868c_fk_auth_user_id] FOREIGN KEY ([admin_id]) REFERENCES [dbo].[auth_user] ([id]),
    CONSTRAINT [mobile_announcement_init_sender_id_2f5e35bd_fk_personnel_employee_id] FOREIGN KEY ([init_sender_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [mobile_announcement_receiver_id_ddf2a860_fk_personnel_employee_id] FOREIGN KEY ([receiver_id]) REFERENCES [dbo].[personnel_employee] ([id])
);


GO
CREATE NONCLUSTERED INDEX [mobile_announcement_receiver_id_ddf2a860]
    ON [dbo].[mobile_announcement]([receiver_id] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_announcement_init_sender_id_2f5e35bd]
    ON [dbo].[mobile_announcement]([init_sender_id] ASC);


GO
CREATE NONCLUSTERED INDEX [mobile_announcement_admin_id_6af3868c]
    ON [dbo].[mobile_announcement]([admin_id] ASC);

