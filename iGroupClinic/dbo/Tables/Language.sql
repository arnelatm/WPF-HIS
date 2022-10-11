CREATE TABLE [dbo].[Language] (
    [LabelID]    INT           IDENTITY (1, 1) NOT NULL,
    [ModuleID]   VARCHAR (150) NOT NULL,
    [LabelName]  VARCHAR (50)  NOT NULL,
    [EnglishCap] VARCHAR (50)  NULL,
    [ArabicCap]  NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([LabelID] ASC)
);

