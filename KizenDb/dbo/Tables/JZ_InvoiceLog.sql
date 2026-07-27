CREATE TABLE [dbo].[JZ_InvoiceLog] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [EventDateTime] DATETIME       NOT NULL,
    [CompanyId]     INT            NOT NULL,
    [SystemId]      INT            NOT NULL,
    [SourceType]    NVARCHAR (200) NOT NULL,
    [SourceId]      NVARCHAR (100) NOT NULL,
    [InvoiceId]     INT            NULL,
    [ResultStatus]  INT            NOT NULL,
    [ResultText]    NVARCHAR (MAX) NULL,
    [ResultXML]     NVARCHAR (MAX) NULL,
    [Steps]         NVARCHAR (50)  NULL,
    [VersionNumber] NVARCHAR (50)  NULL,
    CONSTRAINT [PK_dbo.JZ_InvoiceLog] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SourceId]
    ON [dbo].[JZ_InvoiceLog]([SourceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_System_Source]
    ON [dbo].[JZ_InvoiceLog]([SystemId] ASC, [SourceType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Company_Source]
    ON [dbo].[JZ_InvoiceLog]([CompanyId] ASC, [SystemId] ASC, [SourceType] ASC, [SourceId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JZ_InvoiceLog]([CompanyId] ASC);

