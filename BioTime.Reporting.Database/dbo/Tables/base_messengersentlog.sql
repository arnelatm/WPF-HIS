CREATE TABLE [dbo].[base_messengersentlog] (
    [id]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [action]          SMALLINT       NOT NULL,
    [targets]         NVARCHAR (MAX) NULL,
    [targets_repr]    NVARCHAR (MAX) NULL,
    [action_status]   SMALLINT       NOT NULL,
    [description]     NVARCHAR (MAX) NULL,
    [ip_address]      NVARCHAR (39)  NULL,
    [can_routable]    BIT            NOT NULL,
    [op_time]         DATETIME2 (7)  NOT NULL,
    [bot_uid]         NVARCHAR (100) NULL,
    [content_type_id] INT            NULL,
    [emp_id]          INT            NULL,
    [user_id]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [base_messengersentlog_content_type_id_e6e9b3d5_fk_django_content_type_id] FOREIGN KEY ([content_type_id]) REFERENCES [dbo].[django_content_type] ([id]),
    CONSTRAINT [base_messengersentlog_emp_id_44eba15e_fk_personnel_employee_id] FOREIGN KEY ([emp_id]) REFERENCES [dbo].[personnel_employee] ([id]),
    CONSTRAINT [base_messengersentlog_user_id_64034c70_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [base_messengersentlog_user_id_64034c70]
    ON [dbo].[base_messengersentlog]([user_id] ASC);


GO
CREATE NONCLUSTERED INDEX [base_messengersentlog_emp_id_44eba15e]
    ON [dbo].[base_messengersentlog]([emp_id] ASC);


GO
CREATE NONCLUSTERED INDEX [base_messengersentlog_content_type_id_e6e9b3d5]
    ON [dbo].[base_messengersentlog]([content_type_id] ASC);

