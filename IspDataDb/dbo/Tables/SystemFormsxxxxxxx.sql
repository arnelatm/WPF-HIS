CREATE TABLE [dbo].[SystemFormsxxxxxxx] (
    [IdNo]                SMALLINT     IDENTITY (1, 1) NOT NULL,
    [FormName]            VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [DefaultValuesEnable] BIT          NULL,
    CONSTRAINT [PK_SystemForms] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

