CREATE TABLE [dbo].[SystemView] (
    [IdNo]                SMALLINT     IDENTITY (1, 1) NOT NULL,
    [SystemViewName]      VARCHAR (50) NULL,
    [SystemViewNameAra]   VARCHAR (50) NULL,
    [DefaultValuesEnable] BIT          NULL,
    CONSTRAINT [PK_SystemView] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

