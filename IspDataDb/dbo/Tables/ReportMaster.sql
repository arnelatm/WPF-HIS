CREATE TABLE [dbo].[ReportMaster] (
    [ReportID]     VARCHAR (15) NOT NULL,
    [Department]   VARCHAR (50) NOT NULL,
    [Description]  VARCHAR (50) NOT NULL,
    [ReportOrder]  NUMERIC (4)  NULL,
    [TabOrder]     NUMERIC (4)  NULL,
    [ReportSource] VARCHAR (10) NULL,
    [Activate]     VARCHAR (1)  DEFAULT ('N') NULL
);

