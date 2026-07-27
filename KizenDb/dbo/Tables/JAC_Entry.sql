CREATE TABLE [dbo].[JAC_Entry] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CycleId]          INT            NOT NULL,
    [PatternId]        INT            NULL,
    [BranchId]         INT            NOT NULL,
    [Code]             INT            NOT NULL,
    [DateTime]         DATETIME       NOT NULL,
    [Note]             NVARCHAR (250) NULL,
    [IsPosted]         BIT            NOT NULL,
    [IsAuto]           TINYINT        NOT NULL,
    [IsConfirm]        BIT            NOT NULL,
    [IsDeleted]        BIT            NOT NULL,
    [IsOpening]        BIT            DEFAULT ((0)) NOT NULL,
    [Number]           INT            DEFAULT ((0)) NOT NULL,
    [UserId]           INT            NULL,
    [UserName]         NVARCHAR (250) NULL,
    [UserIdLastEdit]   INT            NULL,
    [UserNameLastEdit] NVARCHAR (250) NULL,
    [CurrencyId]       INT            NOT NULL,
    CONSTRAINT [PK_dbo.JAC_Entry] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Entry_dbo.JAC_Branch_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[JAC_Branch] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Entry_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Entry_dbo.JAC_Cycle_CycleId] FOREIGN KEY ([CycleId]) REFERENCES [dbo].[JAC_Cycle] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Entry_dbo.JAC_Pattern_PatternId] FOREIGN KEY ([PatternId]) REFERENCES [dbo].[JAC_Pattern] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_Entry]([CurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsOpening]
    ON [dbo].[JAC_Entry]([IsOpening] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsDeleted]
    ON [dbo].[JAC_Entry]([IsDeleted] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsConfirm]
    ON [dbo].[JAC_Entry]([IsConfirm] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsAuto]
    ON [dbo].[JAC_Entry]([IsAuto] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IsPosted]
    ON [dbo].[JAC_Entry]([IsPosted] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DateTime]
    ON [dbo].[JAC_Entry]([DateTime] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Number]
    ON [dbo].[JAC_Entry]([Number] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CycleAndPatternAndBranchAndNumber]
    ON [dbo].[JAC_Entry]([CycleId] ASC, [PatternId] ASC, [BranchId] ASC, [Number] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Code]
    ON [dbo].[JAC_Entry]([Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BranchId]
    ON [dbo].[JAC_Entry]([BranchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PatternId]
    ON [dbo].[JAC_Entry]([PatternId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CycleAndBranchAndCode]
    ON [dbo].[JAC_Entry]([CycleId] ASC, [BranchId] ASC, [Code] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CycleId]
    ON [dbo].[JAC_Entry]([CycleId] ASC);

