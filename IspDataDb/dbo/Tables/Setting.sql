CREATE TABLE [dbo].[Setting] (
    [IdNo]        SMALLINT       NOT NULL,
    [Group]       VARCHAR (10)   NOT NULL,
    [SettingCode] VARCHAR (10)   NOT NULL,
    [ValueType]   VARCHAR (2)    NULL,
    [Value]       VARCHAR (100)  NULL,
    [Notes]       NVARCHAR (200) NULL
);

