CREATE TABLE [dbo].[base_attparamdepts] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [rulename] NVARCHAR (40) NOT NULL,
    [deptid]   INT           NOT NULL,
    [operator] NVARCHAR (20) NULL,
    [optime]   DATETIME2 (7) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([rulename] ASC)
);

