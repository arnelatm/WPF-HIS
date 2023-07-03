CREATE TABLE [dbo].[DosageLabel] (
    [IdNo]             INT          IDENTITY (1, 1) NOT NULL,
    [ComputerName]     VARCHAR (30) NULL,
    [PrescriptionIdNo] INT          NULL,
    [PatientName]      VARCHAR (50) NULL,
    [FileNo]           INT          NULL,
    [Age]              INT          NULL,
    [AgeYmd]           VARCHAR (10) NULL,
    [Gender]           CHAR (1)     NULL,
    [DoctorName]       VARCHAR (50) NULL,
    CONSTRAINT [PK_DosageLabel] PRIMARY KEY CLUSTERED ([IdNo] ASC),
    CONSTRAINT [IX_DosageLabel] UNIQUE NONCLUSTERED ([ComputerName] ASC)
);

