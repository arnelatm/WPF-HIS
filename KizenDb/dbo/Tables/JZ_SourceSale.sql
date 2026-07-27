CREATE TABLE [dbo].[JZ_SourceSale] (
    [Id]                           INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]                    INT            NOT NULL,
    [SystemId]                     INT            NOT NULL,
    [SourceType]                   NVARCHAR (200) NOT NULL,
    [RegistrationMethod]           NVARCHAR (200) NULL,
    [XMLCheckOnline]               BIT            NOT NULL,
    [PreventPrintBeforeGenerateQR] BIT            NOT NULL,
    [PreventPrintBeforeReporting]  BIT            NOT NULL,
    [WorkflowType]                 INT            NOT NULL,
    [CustomizedQuery]              NVARCHAR (MAX) NULL,
    [InvoicingStartDate]           DATETIME       NULL,
    CONSTRAINT [PK_dbo.JZ_SourceSale] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_SourceSale_dbo.JZ_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JZ_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JZ_SourceSale]([CompanyId] ASC);

