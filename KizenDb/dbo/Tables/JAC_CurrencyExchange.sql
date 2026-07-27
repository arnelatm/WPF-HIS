CREATE TABLE [dbo].[JAC_CurrencyExchange] (
    [Id]             INT             IDENTITY (1, 1) NOT NULL,
    [CurrencyId]     INT             NOT NULL,
    [BaseCurrencyId] INT             NOT NULL,
    [DateTime]       DATETIME        NOT NULL,
    [Method]         NVARCHAR (5)    NOT NULL,
    [Evaluation]     DECIMAL (19, 9) NOT NULL,
    CONSTRAINT [PK_dbo.JAC_CurrencyExchange] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.JAC_CurrencyExchange_dbo.JAC_Currency_BaseCurrencyId] FOREIGN KEY ([BaseCurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.JAC_CurrencyExchange_dbo.JAC_Currency_CurrencyId] FOREIGN KEY ([CurrencyId]) REFERENCES [dbo].[JAC_Currency] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_BaseCurrencyId]
    ON [dbo].[JAC_CurrencyExchange]([BaseCurrencyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CurrencyId]
    ON [dbo].[JAC_CurrencyExchange]([CurrencyId] ASC);

