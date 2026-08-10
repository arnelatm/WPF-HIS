CREATE TABLE [dbo].[MedicalFitnessReportTestResult] (
    [IdNo]                   INT            IDENTITY (1, 1) NOT NULL,
    [MedicalFitnessReportIdNo] INT          NOT NULL,
    [SectionCode]            VARCHAR (30)   NOT NULL,
    [TestCode]               VARCHAR (50)   NOT NULL,
    [TestNameEnglish]        NVARCHAR (255) NOT NULL,
    [TestNameArabic]         NVARCHAR (255) NULL,
    [DisplayOrder]           INT            NOT NULL,
    [Sequence]               AS ([DisplayOrder]),
    [ResultStatus]           CHAR (1)       NULL,
    [ResultText]             NVARCHAR (MAX) NULL,
    [Remarks]                NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_MedicalFitnessReportTestResult] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [FK_MedicalFitnessReportTestResult_MedicalFitnessReport] FOREIGN KEY ([MedicalFitnessReportIdNo]) REFERENCES [dbo].[MedicalFitnessReport] ([IdNo]) ON DELETE CASCADE,
    CONSTRAINT [CK_MedicalFitnessReportTestResult_ResultStatus] CHECK ([ResultStatus] IS NULL OR [ResultStatus] IN ('F', 'U'))
);

GO
CREATE NONCLUSTERED INDEX [IX_MedicalFitnessReportTestResult_ReportDisplay]
    ON [dbo].[MedicalFitnessReportTestResult]([MedicalFitnessReportIdNo] ASC, [DisplayOrder] ASC);
