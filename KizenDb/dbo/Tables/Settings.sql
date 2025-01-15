CREATE TABLE [dbo].[Settings] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [NetWorkSettingInfor] NVARCHAR (MAX) NULL,
    [ReSettingInfo]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED ([id] ASC)
);

