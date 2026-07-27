CREATE TABLE [dbo].[A1_WalletPayment] (
    [ID]                INT             IDENTITY (1, 1) NOT NULL,
    [WalletBankID]      INT             NOT NULL,
    [UserID]            INT             NOT NULL,
    [CustId]            INT             NOT NULL,
    [TransactionDate]   DATETIME        NOT NULL,
    [TransactionType]   INT             NOT NULL,
    [TransactionValue]  DECIMAL (18, 2) NOT NULL,
    [Note]              NVARCHAR (MAX)  NULL,
    [PaymentType]       NVARCHAR (50)   NULL,
    [BankID]            INT             NULL,
    [BankTransactionNo] NVARCHAR (MAX)  NULL,
    [BoxId]             INT             NULL,
    [BankTranID]        INT             NULL,
    CONSTRAINT [PK_A1_WalletPayment] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_BankID]
    ON [dbo].[A1_WalletPayment]([BankID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_BoxId]
    ON [dbo].[A1_WalletPayment]([BoxId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_CustId]
    ON [dbo].[A1_WalletPayment]([CustId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_PaymentType]
    ON [dbo].[A1_WalletPayment]([PaymentType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_TransactionDate]
    ON [dbo].[A1_WalletPayment]([TransactionDate] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_TransactionType]
    ON [dbo].[A1_WalletPayment]([TransactionType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_UserID]
    ON [dbo].[A1_WalletPayment]([UserID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_A1_WalletPayment_WalletBankID]
    ON [dbo].[A1_WalletPayment]([WalletBankID] ASC);

