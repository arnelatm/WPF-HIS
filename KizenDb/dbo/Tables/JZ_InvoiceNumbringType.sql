CREATE TABLE [dbo].[JZ_InvoiceNumbringType] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CompanyId]        INT            NOT NULL,
    [SystemId]         INT            NOT NULL,
    [SourceType]       NVARCHAR (200) NOT NULL,
    [NumberingType]    INT            NOT NULL,
    [Prefix]           NVARCHAR (15)  NULL,
    [FullNumberLength] INT            NOT NULL,
    CONSTRAINT [PK_dbo.JZ_InvoiceNumbringType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JZ_InvoiceNumbringType_dbo.JZ_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JZ_Company] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Company_System_SourceType]
    ON [dbo].[JZ_InvoiceNumbringType]([CompanyId] ASC, [SystemId] ASC, [SourceType] ASC);

