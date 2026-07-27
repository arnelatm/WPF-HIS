CREATE TABLE [dbo].[JAC_Session] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [UserId]    INT NOT NULL,
    [CompanyId] INT NULL,
    [BranchId]  INT NULL,
    [CycleId]   INT NULL,
    [ChartId]   INT NULL,
    CONSTRAINT [PK_dbo.JAC_Session] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Session_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Session_dbo.JAC_Chart_ChartId] FOREIGN KEY ([ChartId]) REFERENCES [dbo].[JAC_Chart] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Session_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Session_dbo.JAC_Cycle_CycleId] FOREIGN KEY ([CycleId]) REFERENCES [dbo].[JAC_Cycle] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ChartId]
    ON [dbo].[JAC_Session]([ChartId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CycleId]
    ON [dbo].[JAC_Session]([CycleId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_Session]([BranchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Session]([CompanyId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[JAC_Session]([UserId] ASC);

