CREATE TABLE [dbo].[CashFlowAccountRule] (
    [IdNo]               INT            IDENTITY (1, 1) NOT NULL,
    [AccountIdNo]        SMALLINT       NOT NULL,
    [ClassificationCode] VARCHAR (40)   NOT NULL,
    [CategoryCode]       VARCHAR (40)   NULL,
    [IsCashEquivalent]   BIT            CONSTRAINT [DF_CashFlowAccountRule_IsCashEquivalent] DEFAULT ((0)) NOT NULL,
    [IsActive]           BIT            CONSTRAINT [DF_CashFlowAccountRule_IsActive] DEFAULT ((1)) NOT NULL,
    [EffectiveFrom]      DATE           NULL,
    [EffectiveTo]        DATE           NULL,
    [Notes]              NVARCHAR (500) NULL,
    [CreatedBy]          NVARCHAR (100) NULL,
    [CreatedAt]          DATETIME       CONSTRAINT [DF_CashFlowAccountRule_CreatedAt] DEFAULT (getdate()) NOT NULL,
    [DateTimeStamp]      ROWVERSION     NULL,
    CONSTRAINT [PK_CashFlowAccountRule] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK_CashFlowAccountRule_Account] FOREIGN KEY ([AccountIdNo]) REFERENCES [dbo].[Account] ([IdNo]),
    CONSTRAINT [FK_CashFlowAccountRule_Classification] FOREIGN KEY ([ClassificationCode]) REFERENCES [dbo].[CashFlowClassification] ([Code]),
    CONSTRAINT [FK_CashFlowAccountRule_Category] FOREIGN KEY ([CategoryCode]) REFERENCES [dbo].[CashFlowClassification] ([Code]),
    CONSTRAINT [CK_CashFlowAccountRule_Dates] CHECK ([EffectiveFrom] IS NULL OR [EffectiveTo] IS NULL OR [EffectiveFrom] <= [EffectiveTo])
);

GO
CREATE UNIQUE NONCLUSTERED INDEX [UX_CashFlowAccountRule_ActivePeriod]
    ON [dbo].[CashFlowAccountRule] ([AccountIdNo] ASC, [EffectiveFrom] ASC, [EffectiveTo] ASC)
    WHERE [IsActive] = 1;
