CREATE TABLE [dbo].[JC_TOL_NumberingSetting] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [SystemId]         INT            NOT NULL,
    [SourceType]       NVARCHAR (250) NOT NULL,
    [NumberingType]    INT            NOT NULL,
    [Prefix]           NVARCHAR (15)  NULL,
    [FullNumberLength] INT            NOT NULL,
    [SeedNumber]       INT            NOT NULL,
    [BatchNumber]      INT            NOT NULL,
    CONSTRAINT [PK_dbo.JC_TOL_NumberingSetting] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_System_SourceType]
    ON [dbo].[JC_TOL_NumberingSetting]([SystemId] ASC, [SourceType] ASC);

