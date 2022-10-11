CREATE TABLE [dbo].[Lab_DiagnosisItemDefaults] (
    [BranchID]        VARCHAR (15)   NOT NULL,
    [SlNo]            BIGINT         NOT NULL,
    [InvestigationID] VARCHAR (15)   NOT NULL,
    [DefaultValue]    NVARCHAR (100) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_DiagnosisItemDefaults]
    ON [dbo].[Lab_DiagnosisItemDefaults]([SlNo] ASC, [InvestigationID] ASC);

