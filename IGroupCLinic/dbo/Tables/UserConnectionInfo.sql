CREATE TABLE [dbo].[UserConnectionInfo] (
    [UserID]            VARCHAR (15) NOT NULL,
    [client_name]       VARCHAR (40) NULL,
    [client_server]     VARCHAR (20) NULL,
    [client_db_name]    VARCHAR (20) NULL,
    [client_db_user]    VARCHAR (20) NULL,
    [client_db_version] VARCHAR (20) NULL
);

