CREATE TABLE [dbo].[MedicalFitnessReport] (
    [IdNo]              INT            IDENTITY (1, 1) NOT NULL,
    [InvoiceNo]         INT            NOT NULL,
    [InvoiceDate]       DATETIME       NULL,
    [FileNo]            INT            NULL,
    [PatientName]       NVARCHAR (255) NULL,
    [Gender]            NVARCHAR (50)  NULL,
    [Age]               NVARCHAR (50)  NULL,
    [Nationality]       NVARCHAR (255) NULL,
    [IdentityNo]        NVARCHAR (255) NULL,
    [DoctorName]        NVARCHAR (255) NULL,
    [BloodType]         NVARCHAR (10)  NULL,
    [FinalResultStatus] CHAR (1)       NULL,
    [Remarks]           NVARCHAR (MAX) NULL,
    [UserID]            VARCHAR (15)   CONSTRAINT [DF_MedicalFitnessReport_UserID] DEFAULT ('Admin') NULL,
    [DateCreated]       DATETIME       CONSTRAINT [DF_MedicalFitnessReport_DateCreated] DEFAULT (getdate()) NULL,
    [MachineID]         VARCHAR (20)   CONSTRAINT [DF_MedicalFitnessReport_MachineID] DEFAULT (host_name()) NULL,
    CONSTRAINT [PK_MedicalFitnessReport] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [UQ_MedicalFitnessReport_InvoiceNo] UNIQUE NONCLUSTERED ([InvoiceNo] ASC),
    CONSTRAINT [CK_MedicalFitnessReport_FinalResultStatus] CHECK ([FinalResultStatus] IS NULL OR [FinalResultStatus] IN ('F', 'U'))
);

