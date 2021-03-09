CREATE TABLE [dbo].[Earning] (
    [IdNo]            SMALLINT        IDENTITY (1, 1) NOT NULL,
    [EarningCode]     VARCHAR (10)    NULL,
    [EarningName]     VARCHAR (50)    NULL,
    [EarningNameAra]  NVARCHAR (50)   NULL,
    [Frequency]       CHAR (1)        NULL,
    [EarningType]     CHAR (1)        NULL,
    [AccountIdNo]     SMALLINT        NULL,
    [BasePaymentIdNo] SMALLINT        NULL,
    [CalculationType] CHAR (1)        NULL,
    [DefaultQuantity] DECIMAL (10, 4) NULL,
    [Multiplier]      VARCHAR (10)    NULL,
    [MultiplierType]  CHAR (1)        NULL,
    [IncludeInEos]    BIT             NULL,
    [Rate]            MONEY           NULL,
    [Taxable]         BIT             NULL,
    [Unit]            CHAR (1)        NULL,
    [UsePayGroups]    BIT             NULL,
    [Notes]           NVARCHAR (100)  NULL,
    [DateTimeStamp]   ROWVERSION      NULL,
    [Summary]         BIT             NULL,
    CONSTRAINT [PK_Earning] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

























