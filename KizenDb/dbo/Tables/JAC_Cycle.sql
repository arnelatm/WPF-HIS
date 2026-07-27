CREATE TABLE [dbo].[JAC_Cycle] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [CompanyId]      INT           NOT NULL,
    [Title]          NVARCHAR (50) NOT NULL,
    [BaseCurrencyId] INT           NOT NULL,
    [BeginDate]      DATETIME      NOT NULL,
    [EndDate]        DATETIME      NOT NULL,
    [Locked]         BIT           DEFAULT ((0)) NOT NULL,
    [TitleLatin]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_dbo.JAC_Cycle] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_Cycle_dbo.JAC_Company_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [dbo].[JAC_Company] ([Id]),
    CONSTRAINT [FK_dbo.JAC_Cycle_dbo.JAC_Currency_BaseCurrencyId] FOREIGN KEY ([BaseCurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_BaseCurrencyId]
    ON [dbo].[JAC_Cycle]([BaseCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Title]
    ON [dbo].[JAC_Cycle]([Title] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CompanyAndTitle]
    ON [dbo].[JAC_Cycle]([CompanyId] ASC, [Title] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CompanyId]
    ON [dbo].[JAC_Cycle]([CompanyId] ASC);

