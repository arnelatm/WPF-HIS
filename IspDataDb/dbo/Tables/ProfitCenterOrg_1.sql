CREATE TABLE [dbo].[ProfitCenterOrg] (
    [IDNo]                INT           NOT NULL,
    [ParentID]            INT           NULL,
    [ProfitCenterCode]    VARCHAR (5)   COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProfitCenterName]    VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [ProfitCenterNameAra] NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
    [Descripton]          VARCHAR (50)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [EmployeeName]        NVARCHAR (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    PRIMARY KEY CLUSTERED ([IDNo] ASC),
    FOREIGN KEY ([ParentID]) REFERENCES [dbo].[ProfitCenterOrg] ([IDNo])
);

