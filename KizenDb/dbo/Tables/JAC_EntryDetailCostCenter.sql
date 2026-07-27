CREATE TABLE [dbo].[JAC_EntryDetailCostCenter] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [EntryDetailId] INT             NOT NULL,
    [CostCenterId]  INT             NOT NULL,
    [Percent]       DECIMAL (19, 4) NOT NULL,
    [Debit]         DECIMAL (19, 4) NOT NULL,
    [Credit]        DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_EntryDetailCostCenter] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_EntryDetailCostCenter_dbo.JAC_CostCenter_CostCenterId] FOREIGN KEY ([CostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_EntryDetailCostCenter_dbo.JAC_EntryDetail_EntryDetailId] FOREIGN KEY ([EntryDetailId]) REFERENCES [dbo].[JAC_EntryDetail] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CostCenterId]
    ON [dbo].[JAC_EntryDetailCostCenter]([CostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EntryDetailId]
    ON [dbo].[JAC_EntryDetailCostCenter]([EntryDetailId] ASC);

