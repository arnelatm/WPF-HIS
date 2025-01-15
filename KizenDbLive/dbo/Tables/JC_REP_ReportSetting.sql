CREATE TABLE [dbo].[JC_REP_ReportSetting] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [ReportId]    INT             NOT NULL,
    [DeviceName]  NVARCHAR (255)  NOT NULL,
    [UserId]      INT             NULL,
    [PrinterName] NVARCHAR (MAX)  NULL,
    [Layout]      VARBINARY (MAX) NULL,
    CONSTRAINT [PK_dbo.JC_REP_ReportSetting] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JC_REP_ReportSetting_dbo.JC_REP_Report_ReportId] FOREIGN KEY ([ReportId]) REFERENCES [dbo].[JC_REP_Report] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ReportId]
    ON [dbo].[JC_REP_ReportSetting]([ReportId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReportAndDeviceAndUser]
    ON [dbo].[JC_REP_ReportSetting]([ReportId] ASC, [DeviceName] ASC, [UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DeviceName]
    ON [dbo].[JC_REP_ReportSetting]([DeviceName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[JC_REP_ReportSetting]([UserId] ASC);

