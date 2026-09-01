CREATE TABLE [dbo].[MedicalFitnessReportExamTemplate] (
    [IdNo]            INT            IDENTITY (1, 1) NOT NULL,
    [SectionCode]     VARCHAR (20)   CONSTRAINT [DF_MedicalFitnessReportExamTemplate_SectionCode] DEFAULT ('CLINICAL') NOT NULL,
    [TestCode]        VARCHAR (50)   NOT NULL,
    [TestNameEnglish] NVARCHAR (255) NOT NULL,
    [TestNameArabic]  NVARCHAR (255) NULL,
    [Unit]            NVARCHAR (100) NULL,
    [DefaultValue]    NVARCHAR (255) NULL,
    [DisplayOrder]    INT            NOT NULL,
    [InputMode]       VARCHAR (20)   CONSTRAINT [DF_MedicalFitnessReportExamTemplate_InputMode] DEFAULT ('FIT_UNFIT') NOT NULL,
    [IsRequired]      BIT            CONSTRAINT [DF_MedicalFitnessReportExamTemplate_IsRequired] DEFAULT ((0)) NOT NULL,
    [Active]          BIT            CONSTRAINT [DF_MedicalFitnessReportExamTemplate_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_MedicalFitnessReportExamTemplate] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_MedicalFitnessReportExamTemplate_TestCode] UNIQUE NONCLUSTERED ([TestCode] ASC),
    CONSTRAINT [CK_MedicalFitnessReportExamTemplate_SectionCode] CHECK ([SectionCode] IN ('CLINICAL', 'XRAY')),
    CONSTRAINT [CK_MedicalFitnessReportExamTemplate_InputMode] CHECK ([InputMode] IN ('FIT_UNFIT', 'TEXT', 'NUMBER'))
);


GO
