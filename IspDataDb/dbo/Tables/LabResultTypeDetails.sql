CREATE TABLE [dbo].[LabResultTypeDetails] (
    [IdNo]              INT           IDENTITY (1, 1) NOT NULL,
    [LabResultTypeIdNo] INT           NULL,
    [Result]            VARCHAR (255) NULL,
    CONSTRAINT [PK_LabResultTypeDetails] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

