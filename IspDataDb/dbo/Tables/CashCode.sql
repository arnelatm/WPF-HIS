CREATE TABLE [dbo].[CashCode] (
    [IdNo]                      TINYINT        IDENTITY (1, 1) NOT NULL,
    [CashCode]                  CHAR (1)       COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CashName]                  NVARCHAR (30)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [CashNameAra]               NVARCHAR (30)  COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [AccountIdNo]               INT            NULL,
    [Rate]                      DECIMAL (5, 2) NULL,
    [WithBankCharges]           BIT            NULL,
    [BankChargesAccountIdNo]    INT            NULL,
    [BankChargesVatAccountIdNo] INT            NULL,
    [Notes]                     NVARCHAR (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    CONSTRAINT [PK_CashCode] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



