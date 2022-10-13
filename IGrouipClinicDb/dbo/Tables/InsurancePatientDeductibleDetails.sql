CREATE TABLE [dbo].[InsurancePatientDeductibleDetails] (
    [BranchID]             VARCHAR (15) NOT NULL,
    [RegistrationNo]       NUMERIC (12) NOT NULL,
    [Series]               VARCHAR (10) NOT NULL,
    [PatientType]          VARCHAR (10) NULL,
    [GroupNo]              NUMERIC (12) NULL,
    [DepartmentID]         VARCHAR (15) NULL,
    [InsuranceID]          VARCHAR (15) NOT NULL,
    [CategoryID]           VARCHAR (15) NOT NULL,
    [DoctorCode]           VARCHAR (10) NOT NULL,
    [ReconsultationDays]   NUMERIC (2)  DEFAULT (1) NULL,
    [LastConsultationDate] VARCHAR (10) DEFAULT (getdate()) NULL,
    [UpperLimit]           NUMERIC (5)  NULL,
    [DeductibleAmt]        NUMERIC (5)  DEFAULT (0) NULL
);

