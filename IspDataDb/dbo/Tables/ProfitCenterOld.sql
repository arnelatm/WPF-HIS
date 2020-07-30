CREATE TABLE [dbo].[RevCostCenterOld] (
    [IDNo]                SMALLINT     IDENTITY (1, 1) NOT NULL,
    [RevCostCenterCode]    VARCHAR (5)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [RevCostCenterName]    VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [RevCostCenterNameAra] VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Description]         VARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
);

