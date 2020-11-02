CREATE TABLE [dbo].[PaymentType] (
    [IdNo]                      TINYINT        IDENTITY (1, 1) NOT NULL,
    [PaymentTypeCode]           CHAR (1)       NULL,
    [PaymentTypeName]           NVARCHAR (30)  NULL,
    [PaymentTypeNameAra]        NVARCHAR (30)  NULL,
    [AccountIdNo]               INT            NULL,
    [Rate]                      DECIMAL (5, 2) NULL,
    [WithBankCharges]           BIT            NULL,
    [BankChargesAccountIdNo]    INT            NULL,
    [BankChargesVatAccountIdNo] INT            NULL,
    [Notes]                     NVARCHAR (255) NULL,
    CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

