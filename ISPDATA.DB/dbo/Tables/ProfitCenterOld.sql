CREATE TABLE [dbo].[ProfitCenterOld] (
    [IDNo]                SMALLINT     IDENTITY (1, 1) NOT NULL,
    [ProfitCenterCode]    VARCHAR (5)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProfitCenterName]    VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProfitCenterNameAra] VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Description]         VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

