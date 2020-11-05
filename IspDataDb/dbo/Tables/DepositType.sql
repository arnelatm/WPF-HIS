CREATE TABLE [dbo].[DepositType] (
    [IdNo]                      SMALLINT       IDENTITY (1, 1) NOT NULL,
    [DepositTypeCode]           CHAR (1)       NOT NULL,
    [DepositTypeName]           NVARCHAR (30)  NOT NULL,
    [DepositTypeNameAra]        NVARCHAR (30)  NULL,
    [AccountIdNo]               SMALLINT       NULL,
    [Rate]                      DECIMAL (8, 4) NULL,
    [WithBankCharges]           BIT            NULL,
    [BankChargesAccountIdNo]    SMALLINT       NULL,
    [BankChargesVatAccountIdNo] SMALLINT       NULL,
    [Notes]                     NVARCHAR (255) NULL,
    [DateTimeStamp]             ROWVERSION     NULL,
    CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

