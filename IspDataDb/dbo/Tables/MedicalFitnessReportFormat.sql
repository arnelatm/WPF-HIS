CREATE TABLE [dbo].[MedicalFitnessReportFormat] (
    [MRIdNo]                 INT            IDENTITY (1, 1) NOT NULL,
    [FormatCode]             VARCHAR (50)   NOT NULL,
    [TitleEnglish]           NVARCHAR (255) NOT NULL,
    [TitleArabic]            NVARCHAR (255) NULL,
    [CrystalReportFileName]  NVARCHAR (255) NOT NULL,
    [Active]                 BIT            CONSTRAINT [DF_MedicalFitnessReportFormat_Active] DEFAULT ((1)) NOT NULL,
    [DisplayOrder]           INT            CONSTRAINT [DF_MedicalFitnessReportFormat_DisplayOrder] DEFAULT ((10)) NOT NULL,
    [IsDefault]              BIT            CONSTRAINT [DF_MedicalFitnessReportFormat_IsDefault] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_MedicalFitnessReportFormat] PRIMARY KEY CLUSTERED ([MRIdNo] ASC),
    CONSTRAINT [UQ_MedicalFitnessReportFormat_FormatCode] UNIQUE NONCLUSTERED ([FormatCode] ASC)
);


GO
