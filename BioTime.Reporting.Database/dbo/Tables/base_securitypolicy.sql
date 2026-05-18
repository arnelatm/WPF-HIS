CREATE TABLE [dbo].[base_securitypolicy] (
    [id]                         INT            IDENTITY (1, 1) NOT NULL,
    [single_login]               BIT            NOT NULL,
    [app_single_user_login]      BIT            NOT NULL,
    [security_code]              BIT            NOT NULL,
    [code_length]                INT            NOT NULL,
    [valid_duration]             INT            NOT NULL,
    [failed_times]               INT            NOT NULL,
    [failed_locked]              BIT            NOT NULL,
    [lock_failed_count]          INT            NOT NULL,
    [lock_duration]              INT            NOT NULL,
    [enforce_pwd_change]         BIT            NOT NULL,
    [enforce_pwd_expiration]     BIT            NOT NULL,
    [validity_period]            INT            NOT NULL,
    [password_level]             SMALLINT       NOT NULL,
    [is_default]                 BIT            NOT NULL,
    [session_timeout]            INT            NOT NULL,
    [export_encryption]          BIT            NOT NULL,
    [export_encryption_password] NVARCHAR (128) NULL,
    [backup_encryption]          BIT            NOT NULL,
    [backup_encryption_password] NVARCHAR (128) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

