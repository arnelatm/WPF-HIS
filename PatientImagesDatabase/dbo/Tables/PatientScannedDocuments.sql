CREATE TABLE [dbo].[PatientScannedDocuments] (
    [BranchID]       VARCHAR (15)   NOT NULL,
    [RegistrationNo] NUMERIC (12)   NOT NULL,
    [PatientType]    VARCHAR (15)   NOT NULL,
    [DocumentID]     VARCHAR (15)   NOT NULL,
    [DocumentType]   VARCHAR (15)   NULL,
    [Width]          NUMERIC (7, 2) NULL,
    [Height]         NUMERIC (7, 2) NULL,
    [Brightness]     NUMERIC (2)    NULL,
    [Contrast]       NUMERIC (2)    NULL,
    [DocumentInfo]   IMAGE          NULL,
    [UserID]         VARCHAR (15)   NULL,
    [Create_Date]    DATETIME       NULL,
    [MachineID]      VARCHAR (20)   NULL
);

