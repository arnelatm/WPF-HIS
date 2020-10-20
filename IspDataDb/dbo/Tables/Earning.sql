CREATE TABLE [dbo].[Earning] (
    [IdNo]             SMALLINT       IDENTITY (1, 1) NOT NULL,
    [EarningCode]      VARCHAR (10)   NULL,
    [EarningName]      VARCHAR (50)   NULL,
    [EarningNameAra]   NVARCHAR (50)  NULL,
    [Frequency]        CHAR (1)       NULL,
    [EarningType]      CHAR (1)       NULL,
    [AccountIdNo]      SMALLINT       NULL,
    [BasePaymentidNo]  SMALLINT       NULL,
    [CalculationType]  CHAR (1)       NULL,
    [IncludeInEos]     BIT            NULL,
    [IncludeInPension] BIT            NULL,
    [Multiplier]       DECIMAL (6, 2) NULL,
    [MultiplierType]   CHAR (1)       NULL,
    [Notes]            NVARCHAR (100) NULL,
    [Rate]             MONEY          NULL,
    [Taxable]          BIT            NULL,
    [Unit]             CHAR (1)       NULL,
    [DateTimeStamp]    ROWVERSION     NULL,
    CONSTRAINT [PK_Earning] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);











