CREATE TABLE [dbo].[RevCostCenterOrg] (
    [IDNo]                INT           NOT NULL,
    [ParentID]            INT           NULL,
    [RevCostCenterCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [RevCostCenterName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [RevCostCenterNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Descripton]          VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [EmployeeName]        NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC),
    FOREIGN KEY ([ParentID]) REFERENCES [dbo].[RevCostCenterOrg] ([IDNo])
);

