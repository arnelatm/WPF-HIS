CREATE TABLE [dbo].[SecurityReportAccess] (
    [IdNo]              SMALLINT IDENTITY (1, 1) NOT NULL,
    [ReportGroupIdNo]   SMALLINT NULL,
    [SecurityGroupIdNo] SMALLINT NULL,
    [UserIdNo]          SMALLINT NULL,
    CONSTRAINT [PK_SecurityReportAccess] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

