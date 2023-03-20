CREATE TABLE [dbo].[ReportSelection] (
    [BranchID]    VARCHAR (15) NOT NULL,
    [ModuleName]  VARCHAR (30) NOT NULL,
    [ReportID]    VARCHAR (15) NOT NULL,
    [ReportOrder] NUMERIC (2)  NOT NULL,
    [Activate]    VARCHAR (1)  DEFAULT ('0') NULL
);

