CREATE TABLE [dbo].[JC_TOL_NumberingLog] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [NumberingSettingId] INT           NOT NULL,
    [SourceId]           INT           NOT NULL,
    [Prefix]             NVARCHAR (15) NULL,
    [PrefixDate]         DATETIME      NULL,
    [FullNumberLength]   INT           NOT NULL,
    [BatchNumber]        INT           NOT NULL,
    [Number]             INT           NOT NULL,
    [FullNumber]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_dbo.JC_TOL_NumberingLog] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JC_TOL_NumberingLog_dbo.JC_TOL_NumberingSetting_NumberingSettingId] FOREIGN KEY ([NumberingSettingId]) REFERENCES [dbo].[JC_TOL_NumberingSetting] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_NumberingSettingId]
    ON [dbo].[JC_TOL_NumberingLog]([NumberingSettingId] ASC);

