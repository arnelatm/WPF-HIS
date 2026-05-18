CREATE TABLE [dbo].[iclock_privatemessage] (
    [id]          INT            IDENTITY (1, 1) NOT NULL,
    [create_time] DATETIME2 (7)  NULL,
    [create_user] NVARCHAR (150) NULL,
    [change_time] DATETIME2 (7)  NULL,
    [change_user] NVARCHAR (150) NULL,
    [status]      SMALLINT       NOT NULL,
    [last_send]   DATETIME2 (7)  NULL,
    [employee_id] INT            NOT NULL,
    [message_id]  INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [iclock_privatemessage_employee_id_e84a34c0_fk_personnel_employee_id] FOREIGN KEY ([employee_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [iclock_privatemessage_message_id_e3145d3b_fk_iclock_shortmessage_id] FOREIGN KEY ([message_id]) REFERENCES [dbo].[iclock_shortmessage] ([id])
);


GO
CREATE NONCLUSTERED INDEX [iclock_privatemessage_employee_id_e84a34c0]
    ON [dbo].[iclock_privatemessage]([employee_id] ASC);


GO
CREATE NONCLUSTERED INDEX [iclock_privatemessage_message_id_e3145d3b]
    ON [dbo].[iclock_privatemessage]([message_id] ASC);

