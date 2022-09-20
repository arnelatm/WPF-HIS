CREATE TABLE [dbo].[Lab_DiagnosisItemDetails] (
    [BranchID]           VARCHAR (15)    NOT NULL,
    [ColumnNos]          BIGINT          NULL,
    [SlNo]               BIGINT          NOT NULL,
    [InvestigationID]    VARCHAR (15)    NOT NULL,
    [InvestigationName1] VARCHAR (50)    NULL,
    [SuffixPrefix1]      NVARCHAR (100)  NULL,
    [DefaultValue1]      NVARCHAR (3000) NULL,
    [InvestigationName2] NVARCHAR (50)   NULL,
    [SuffixPrefix2]      NVARCHAR (100)  NULL,
    [DefaultValue2]      NVARCHAR (100)  NULL,
    [InvestigationName3] NVARCHAR (50)   NULL,
    [SuffixPrefix3]      NVARCHAR (100)  NULL,
    [DefaultValue3]      NVARCHAR (100)  NULL,
    [InvestigationName4] NVARCHAR (50)   NULL,
    [SuffixPrefix4]      NVARCHAR (100)  NULL,
    [DefaultValue4]      NVARCHAR (100)  NULL,
    [CFactor]            BIGINT          NULL,
    [PrintStatus]        INT             NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_DiagnosisItemDetails]
    ON [dbo].[Lab_DiagnosisItemDetails]([BranchID] ASC, [SlNo] ASC, [InvestigationID] ASC);

