CREATE TABLE [dbo].[Deduction] (
    [IdNo]             SMALLINT        IDENTITY (1, 1) NOT NULL,
    [DeductionCode]    VARCHAR (10)    NULL,
    [DeductionName]    VARCHAR (50)    NULL,
    [DeductionNameAra] NVARCHAR (50)   NULL,
    [Frequency]        CHAR (1)        NULL,
    [AccountIdNo]      SMALLINT        NULL,
    [DeductionType]    CHAR (1)        NULL,
    [DeductionPlace]   CHAR (1)        NULL,
    [BasePaymentIdNo]  SMALLINT        NULL,
    [CalculationType]  CHAR (1)        NULL,
    [DefaultQuantity]  DECIMAL (10, 4) NULL,
    [FactorValue]       DECIMAL(10, 4)    NULL,
    [FactorType]   CHAR (1)        NULL,
    [Rate]             MONEY           NULL,
    [Unit]             CHAR (1)        NULL,
    [UsePayGroups]     BIT             NULL,
    [Notes]            NVARCHAR (100)  NULL,
    [DateTimeStamp]    ROWVERSION      NULL,
    CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);















