CREATE TABLE [dbo].[PaymentType] (
    [IdNo]                      SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PaymentTypeCode]           CHAR (1)       NULL,
    [PaymentTypeName]           NVARCHAR (30)  NULL,
    [PaymentTypeNameAra]        NVARCHAR (30)  NULL,
    [AccountIdNo]               SMALLINT       NULL,
    [Rate]                      DECIMAL (8, 4) NULL,
    [WithBankCharges]           BIT            NULL,
    [BankChargesAccountIdNo]    SMALLINT       NULL,
    [BankChargesVatAccountIdNo] SMALLINT       NULL,
    [Notes]                     NVARCHAR (255) NULL,
    CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





