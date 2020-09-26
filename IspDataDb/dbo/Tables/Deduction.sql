CREATE TABLE [dbo].[Deduction] (
    [IdNo]             SMALLINT       IDENTITY (1, 1) NOT NULL,
    [DeductionCode]    VARCHAR (10)   NULL,
    [DeductionName]    VARCHAR (50)   NULL,
    [DeductionNameAra] NVARCHAR (50)  NULL,
    [DefaultFrequency] CHAR (1)       NULL,
    [AccountIdNo]      SMALLINT       NULL,
    [DeductionType]    CHAR (1)       NULL,
    [DeductionPlace]   CHAR (1)       NULL,
    [ComputationType]  CHAR (1)       NULL,
    [Percentage]       DECIMAL (4, 2) NULL,
    [Notes]            NVARCHAR (100) NULL,
    [DateTimeStamp]    ROWVERSION     NULL,
    CONSTRAINT [PK_Deduction] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









