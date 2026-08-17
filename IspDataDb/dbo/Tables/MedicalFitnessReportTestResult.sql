CREATE TABLE [dbo].[MedicalFitnessReportTestResult] (
    [IdNo]                     INT            IDENTITY (1, 1) NOT NULL,
    [MedicalFitnessReportIdNo] INT            NOT NULL,
    [SectionCode]              VARCHAR (30)   NOT NULL,
    [TestCode]                 VARCHAR (50)   NOT NULL,
    [TestNameEnglish]          NVARCHAR (255) NOT NULL,
    [TestNameArabic]           NVARCHAR (255) NULL,
    [DisplayOrder]             INT            NOT NULL,
    [ResultStatus]             CHAR (1)       NULL,
    [ResultText]               NVARCHAR (MAX) NULL,
    [Remarks]                  NVARCHAR (MAX) NULL,
    [Sequence]                 AS             ([DisplayOrder]),
    [LabResult]                NVARCHAR (MAX) NULL,
    [LabReferenceValue]        NVARCHAR (MAX) NULL,
    [LabUnit]                  NVARCHAR (100) NULL,
    [LabAssessment]            VARCHAR (30)   NULL,
    [ResultStatusSource]       CHAR (1)       NULL,
    CONSTRAINT [PK_MedicalFitnessReportTestResult] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [CK_MedicalFitnessReportTestResult_ResultStatus] CHECK ([ResultStatus] IS NULL OR ([ResultStatus]='U' OR [ResultStatus]='F')),
    CONSTRAINT [CK_MedicalFitnessReportTestResult_ResultStatusSource] CHECK ([ResultStatusSource] IS NULL OR ([ResultStatusSource]='M' OR [ResultStatusSource]='A'))
);


GO

