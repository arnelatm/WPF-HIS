CREATE TABLE [dbo].[base_adminlog] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [action]          NVARCHAR (50)  NOT NULL,
    [targets]         NVARCHAR (MAX) NULL,
    [targets_repr]    NVARCHAR (MAX) NULL,
    [action_status]   SMALLINT       NOT NULL,
    [description]     NVARCHAR (MAX) NULL,
    [ip_address]      NVARCHAR (39)  NULL,
    [can_routable]    BIT            NOT NULL,
    [op_time]         DATETIME2 (7)  NOT NULL,
    [content_type_id] INT            NULL,
    [user_id]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [base_adminlog_content_type_id_3e553c30_fk_django_content_type_id] FOREIGN KEY ([content_type_id]) REFERENCES [dbo].[django_content_type] ([id]),
    CONSTRAINT [base_adminlog_user_id_ecf659f8_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id])
);


GO
CREATE NONCLUSTERED INDEX [base_adminlog_user_id_ecf659f8]
    ON [dbo].[base_adminlog]([user_id] ASC);


GO
CREATE NONCLUSTERED INDEX [base_adminlog_content_type_id_3e553c30]
    ON [dbo].[base_adminlog]([content_type_id] ASC);

