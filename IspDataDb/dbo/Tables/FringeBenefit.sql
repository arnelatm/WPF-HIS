CREATE TABLE [dbo].[FringeBenefit] (
    [IdNo]                 SMALLINT      IDENTITY (1, 1) NOT NULL,
    [FringeBenefitCode]    VARCHAR (10)  NULL,
    [FringeBenefitName]    VARCHAR (50)  NULL,
    [FringeBenefitNameAra] NVARCHAR (50) NULL,
    [DefaultFrequency]     CHAR (1)      NULL,
    [AccountIdNo]          INT           NULL,
    [FringeBenefitType]    CHAR (1)      NULL,
    [DateTimeStamp]        ROWVERSION    NULL,
    CONSTRAINT [PK_FringeBenefits] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



