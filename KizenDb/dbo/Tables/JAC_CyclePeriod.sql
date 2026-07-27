CREATE TABLE [dbo].[JAC_CyclePeriod] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [CycleId]    INT           NOT NULL,
    [Title]      NVARCHAR (50) NOT NULL,
    [BeginDate]  DATETIME      NOT NULL,
    [EndDate]    DATETIME      NOT NULL,
    [TitleLatin] NVARCHAR (50) NULL,
    [Locked]     BIT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_CyclePeriod] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_CyclePeriod_dbo.JAC_Cycle_CycleId] FOREIGN KEY ([CycleId]) REFERENCES [dbo].[JAC_Cycle] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CycleAndTitle]
    ON [dbo].[JAC_CyclePeriod]([CycleId] ASC, [Title] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CycleId]
    ON [dbo].[JAC_CyclePeriod]([CycleId] ASC);

