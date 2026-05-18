CREATE TABLE [dbo].[base_sftpsetting] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [host]          NVARCHAR (39)  NOT NULL,
    [port]          INT            NOT NULL,
    [is_sftp]       SMALLINT       NOT NULL,
    [user_name]     NVARCHAR (30)  NOT NULL,
    [user_password] NVARCHAR (128) NULL,
    [user_key]      NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

