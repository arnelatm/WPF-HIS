CREATE TABLE [dbo].[PatientScanningDocuments] (
    [DocumentID]   VARCHAR (15)   NOT NULL,
    [DocumentType] VARCHAR (15)   NOT NULL,
    [Width]        NUMERIC (7, 2) NULL,
    [Height]       NUMERIC (7, 2) NULL,
    [Brightness]   NUMERIC (2)    NULL,
    [Contrast]     NUMERIC (2)    NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PatientScanningDocuments]
    ON [dbo].[PatientScanningDocuments]([DocumentID] ASC, [DocumentType] ASC);

