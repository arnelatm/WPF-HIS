CREATE TABLE [dbo].[AppSettingGroup] (
    [IdNo]                   SMALLINT      IDENTITY (1, 1) NOT NULL,
    [AppSettingCode]         CHAR (4)      NULL,
    [AppSettingGroupName]    VARCHAR (50)  NULL,
    [AppSettingGroupNameAra] NVARCHAR (50) NULL,
    [SelectorTable1]         VARCHAR (50)  NULL,
    [SelectorTable2]         VARCHAR (50)  NULL,
    [SelectorText1]          VARCHAR (20)  NULL,
    [SelectorText2]          VARCHAR (20)  NULL,
    [SelectorCount]          TINYINT       NULL,
    [GroupCodeIdNo]          INT           NULL,
    [DefaultValue]           VARCHAR (50)  NULL,
    CONSTRAINT [PK_InventorySettings] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

