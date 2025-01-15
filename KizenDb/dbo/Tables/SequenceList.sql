CREATE TABLE [dbo].[SequenceList] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Comment]       NVARCHAR (MAX) NULL,
    [NetWorkPath]   NVARCHAR (MAX) NULL,
    [LastEditDate]  DATETIME       NULL,
    [DeviceName]    NVARCHAR (MAX) NULL,
    [SequanceNote]  NVARCHAR (MAX) NULL,
    [CustomClinics] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_SequenceList] PRIMARY KEY CLUSTERED ([ID] ASC)
);

