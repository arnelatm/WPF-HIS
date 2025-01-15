CREATE TABLE [dbo].[JC_REP_Report] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [SystemId] SMALLINT       NOT NULL,
    [Name]     NVARCHAR (500) NOT NULL,
    [Type]     SMALLINT       NOT NULL,
    CONSTRAINT [PK_dbo.JC_REP_Report] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SystemId]
    ON [dbo].[JC_REP_Report]([SystemId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SystemAndNameAndType]
    ON [dbo].[JC_REP_Report]([SystemId] ASC, [Name] ASC, [Type] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Name]
    ON [dbo].[JC_REP_Report]([Name] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Type]
    ON [dbo].[JC_REP_Report]([Type] ASC);

