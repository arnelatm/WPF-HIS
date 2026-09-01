CREATE TABLE [dbo].[MedicalFitnessReportFormatAssignment] (
    [IdNo]          INT            IDENTITY (1, 1) NOT NULL,
    [CompanyName]   NVARCHAR (255) NOT NULL,
    [MRIdNo]        INT            NOT NULL,
    [Active]        BIT            CONSTRAINT [DF_MedicalFitnessReportFormatAssignment_Active] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_MedicalFitnessReportFormatAssignment] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_MedicalFitnessReportFormatAssignment_Company] UNIQUE NONCLUSTERED ([CompanyName] ASC),
    CONSTRAINT [FK_MedicalFitnessReportFormatAssignment_Format] FOREIGN KEY ([MRIdNo]) REFERENCES [dbo].[MedicalFitnessReportFormat] ([MRIdNo])
);


GO
