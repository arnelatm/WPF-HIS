CREATE TABLE [dbo].[AppSetting] (
    [IdNo]                INT          IDENTITY (1, 1) NOT NULL,
    [AppSettingGroupIdNo] TINYINT      NULL,
    [Selector1IdNo]       INT          NULL,
    [Selector2IdNo]       INT          NULL,
    [SettingValue]        VARCHAR (50) NULL,
    CONSTRAINT [PK_AppSetting] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_AppSetting] UNIQUE NONCLUSTERED ([Selector1IdNo] ASC, [Selector2IdNo] ASC, [AppSettingGroupIdNo] ASC)
);



