CREATE TABLE [dbo].[PMRDiagnosisPatient] (
    [Trans_Key]   NUMERIC (10) DEFAULT (1) NULL,
    [RowNBR]      NUMERIC (10) DEFAULT (1) NULL,
    [DiagnosisID] VARCHAR (15) NOT NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDiagnosisPatient]
    ON [dbo].[PMRDiagnosisPatient]([Trans_Key] ASC, [RowNBR] ASC);

