CREATE TABLE [dbo].[Deduction] (
    [IdNo]             SMALLINT      IDENTITY (1, 1) NOT NULL,
    [DeductionCode]    VARCHAR (10)  NULL,
    [DeductionName]    VARCHAR (50)  NULL,
    [DeductionNameAra] NVARCHAR (50) NULL,
    [DefaultFrequency] CHAR (1)      NULL,
    [AccountIdNo]      INT           NULL,
    [DeductionType]    CHAR (1)      NULL,
    [DateTimeStamp]    ROWVERSION    NULL,
    CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

