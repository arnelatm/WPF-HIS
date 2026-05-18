CREATE TABLE [dbo].[auth_user_profile] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [login_name]      NVARCHAR (30)  NOT NULL,
    [pin_tabs]        NVARCHAR (MAX) NOT NULL,
    [disabled_fields] NVARCHAR (MAX) NOT NULL,
    [column_order]    NVARCHAR (MAX) NOT NULL,
    [preferences]     NVARCHAR (MAX) NOT NULL,
    [pwd_update_time] DATETIME2 (7)  NULL,
    [employee_fields] NVARCHAR (MAX) NOT NULL,
    [user_id]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [auth_user_profile_user_id_f9aded29_fk_auth_user_id] FOREIGN KEY ([user_id]) REFERENCES [dbo].[auth_user] ([id]),
    UNIQUE NONCLUSTERED ([user_id] ASC)
);

