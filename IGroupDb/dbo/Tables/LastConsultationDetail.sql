CREATE TABLE [dbo].[LastConsultationDetail] (
    [RegistrationNo]       NUMERIC (12) NOT NULL,
    [Series]               VARCHAR (2)  NOT NULL,
    [InsuranceID]          VARCHAR (15) NULL,
    [DoctorID]             VARCHAR (15) NOT NULL,
    [LastConsultationDate] VARCHAR (10) NULL,
    [LastInvoiceNo]        NUMERIC (10) NULL,
    [LastInvoiceDate]      VARCHAR (10) NULL,
    [UserID]               VARCHAR (15) NOT NULL,
    [Create_Date]          DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]            VARCHAR (20) DEFAULT (host_name()) NULL
);

