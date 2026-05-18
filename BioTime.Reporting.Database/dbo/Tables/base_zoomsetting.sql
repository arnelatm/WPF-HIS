CREATE TABLE [dbo].[base_zoomsetting] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [jwt_token]       NVARCHAR (512) NOT NULL,
    [zoom_user_email] NVARCHAR (128) NOT NULL,
    [zoom_enable]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([jwt_token] ASC),
    UNIQUE NONCLUSTERED ([zoom_user_email] ASC)
);

