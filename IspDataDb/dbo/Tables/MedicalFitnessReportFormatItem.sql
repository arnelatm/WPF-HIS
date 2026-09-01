CREATE TABLE [dbo].[MedicalFitnessReportFormatItem] (
    [IdNo]                  INT            IDENTITY (1, 1) NOT NULL,
    [MRIdNo]                INT            NOT NULL,
    [ExamTemplateIdNo]      INT            NOT NULL,
    [SectionCode]           VARCHAR (20)   NOT NULL,
    [DisplayOrder]          INT            NULL,
    [DefaultValue]          NVARCHAR (255) NULL,
    [InputMode]             VARCHAR (20)   NULL,
    [IsRequired]            BIT            NULL,
    [Active]                BIT            CONSTRAINT [DF_MedicalFitnessReportFormatItem_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_MedicalFitnessReportFormatItem] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_MedicalFitnessReportFormatItem_FormatTemplate] UNIQUE NONCLUSTERED ([MRIdNo] ASC, [ExamTemplateIdNo] ASC),
    CONSTRAINT [FK_MedicalFitnessReportFormatItem_Format] FOREIGN KEY ([MRIdNo]) REFERENCES [dbo].[MedicalFitnessReportFormat] ([MRIdNo]),
    CONSTRAINT [FK_MedicalFitnessReportFormatItem_Template] FOREIGN KEY ([ExamTemplateIdNo]) REFERENCES [dbo].[MedicalFitnessReportExamTemplate] ([IdNo]),
    CONSTRAINT [CK_MedicalFitnessReportFormatItem_SectionCode] CHECK ([SectionCode] IN ('CLINICAL', 'XRAY')),
    CONSTRAINT [CK_MedicalFitnessReportFormatItem_InputMode] CHECK ([InputMode] IS NULL OR [InputMode] IN ('FIT_UNFIT', 'TEXT', 'NUMBER'))
);


GO
