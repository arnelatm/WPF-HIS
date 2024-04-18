CREATE TABLE [dbo].[ReportGroup] (
    [IdNo]               SMALLINT      IDENTITY (1, 1) NOT NULL,
    [ReportGroupCode]    VARCHAR (10)  NULL,
    [ReportGroupName]    VARCHAR (50)  NULL,
    [ReportGroupNameAra] NVARCHAR (50) NULL,
    CONSTRAINT [PK_ReportGroup] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

