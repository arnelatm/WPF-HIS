CREATE TABLE [dbo].[MedicalFitnessReportLabTemplate] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [TestCode]        VARCHAR (50)   NOT NULL,
    [TestNameEnglish] NVARCHAR (255) NOT NULL,
    [TestNameArabic]  NVARCHAR (255) NULL,
    [EnglishNameOverride] NVARCHAR (255) NULL,
    [ArabicNameOverride] NVARCHAR (255) NULL,
    [DisplayOrder]    INT            NOT NULL,
    [CopyResultToEntry] BIT          CONSTRAINT [DF_MedicalFitnessReportLabTemplate_CopyResultToEntry] DEFAULT ((0)) NOT NULL,
    [Active]          BIT            CONSTRAINT [DF_MedicalFitnessReportLabTemplate_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_MedicalFitnessReportLabTemplate] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_MedicalFitnessReportLabTemplate_TestCode] UNIQUE NONCLUSTERED ([TestCode] ASC)
);

