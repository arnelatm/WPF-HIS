CREATE TABLE [dbo].[JAC_PostingSourceDetail] (
    [Id]                      INT            IDENTITY (1, 1) NOT NULL,
    [PostingId]               INT            NOT NULL,
    [SystemId]                INT            NOT NULL,
    [SourceId]                INT            NOT NULL,
    [SourceDetailId]          INT            NOT NULL,
    [DebitAccountMode]        INT            NOT NULL,
    [DebitAccountId]          INT            NULL,
    [DebitAccountGroupId]     INT            NULL,
    [DebitCostCenterMode]     INT            NOT NULL,
    [DebitCostCenterId]       INT            NULL,
    [DebitCostCenterGroupId]  INT            NULL,
    [CreditAccountMode]       INT            NOT NULL,
    [CreditAccountId]         INT            NULL,
    [CreditAccountGroupId]    INT            NULL,
    [CreditCostCenterMode]    INT            NOT NULL,
    [CreditCostCenterId]      INT            NULL,
    [CreditCostCenterGroupId] INT            NULL,
    [DebitCategoryMode]       INT            DEFAULT ((0)) NOT NULL,
    [DebitCategoryId]         INT            NULL,
    [DebitCategoryGroupId]    INT            NULL,
    [CreditCategoryMode]      INT            DEFAULT ((0)) NOT NULL,
    [CreditCategoryId]        INT            NULL,
    [CreditCategoryGroupId]   INT            NULL,
    [Note]                    NVARCHAR (250) NULL,
    [PostingSettingId]        INT            NULL,
    [HidePosting]             BIT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_PostingSourceDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_Account_CreditAccountId] FOREIGN KEY ([CreditAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_Account_DebitAccountId] FOREIGN KEY ([DebitAccountId]) REFERENCES [dbo].[JAC_Account] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_Category_CreditCategoryId] FOREIGN KEY ([CreditCategoryId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_Category_DebitCategoryId] FOREIGN KEY ([DebitCategoryId]) REFERENCES [dbo].[JAC_Category] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_CostCenter_CreditCostCenterId] FOREIGN KEY ([CreditCostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_CostCenter_DebitCostCenterId] FOREIGN KEY ([DebitCostCenterId]) REFERENCES [dbo].[JAC_CostCenter] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_Posting_PostingId] FOREIGN KEY ([PostingId]) REFERENCES [dbo].[JAC_Posting] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_PostingGroup_CreditAccountGroupId] FOREIGN KEY ([CreditAccountGroupId]) REFERENCES [dbo].[JAC_PostingGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_PostingGroup_CreditCategoryGroupId] FOREIGN KEY ([CreditCategoryGroupId]) REFERENCES [dbo].[JAC_PostingGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_PostingGroup_CreditCostCenterGroupId] FOREIGN KEY ([CreditCostCenterGroupId]) REFERENCES [dbo].[JAC_PostingGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_PostingGroup_DebitAccountGroupId] FOREIGN KEY ([DebitAccountGroupId]) REFERENCES [dbo].[JAC_PostingGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_PostingGroup_DebitCategoryGroupId] FOREIGN KEY ([DebitCategoryGroupId]) REFERENCES [dbo].[JAC_PostingGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_PostingGroup_DebitCostCenterGroupId] FOREIGN KEY ([DebitCostCenterGroupId]) REFERENCES [dbo].[JAC_PostingGroup] ([Id]),
    CONSTRAINT [FK_dbo.JAC_PostingSourceDetail_dbo.JAC_PostingSetting_PostingSettingId] FOREIGN KEY ([PostingSettingId]) REFERENCES [dbo].[JAC_PostingSetting] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PostingSettingId]
    ON [dbo].[JAC_PostingSourceDetail]([PostingSettingId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreditCategoryGroupId]
    ON [dbo].[JAC_PostingSourceDetail]([CreditCategoryGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreditCategoryId]
    ON [dbo].[JAC_PostingSourceDetail]([CreditCategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DebitCategoryGroupId]
    ON [dbo].[JAC_PostingSourceDetail]([DebitCategoryGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DebitCategoryId]
    ON [dbo].[JAC_PostingSourceDetail]([DebitCategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreditCostCenterGroupId]
    ON [dbo].[JAC_PostingSourceDetail]([CreditCostCenterGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreditCostCenterId]
    ON [dbo].[JAC_PostingSourceDetail]([CreditCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreditAccountGroupId]
    ON [dbo].[JAC_PostingSourceDetail]([CreditAccountGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CreditAccountId]
    ON [dbo].[JAC_PostingSourceDetail]([CreditAccountId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DebitCostCenterGroupId]
    ON [dbo].[JAC_PostingSourceDetail]([DebitCostCenterGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DebitCostCenterId]
    ON [dbo].[JAC_PostingSourceDetail]([DebitCostCenterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DebitAccountGroupId]
    ON [dbo].[JAC_PostingSourceDetail]([DebitAccountGroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DebitAccountId]
    ON [dbo].[JAC_PostingSourceDetail]([DebitAccountId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PostingSystemSourceSourceDetail]
    ON [dbo].[JAC_PostingSourceDetail]([PostingId] ASC, [SystemId] ASC, [SourceId] ASC, [SourceDetailId] ASC);

