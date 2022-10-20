CREATE TABLE [dbo].[Lab_DiagnosisMasterDetails] (
    [BranchID]          VARCHAR (15)   NOT NULL,
    [Trans_Key]         BIGINT         NOT NULL,
    [DiagnosisID]       VARCHAR (15)   NULL,
    [InputID]           VARCHAR (15)   NULL,
    [ReportID]          VARCHAR (15)   NULL,
    [InvestigationID]   VARCHAR (15)   NOT NULL,
    [InvestigationName] VARCHAR (50)   NOT NULL,
    [ReportHeader]      VARCHAR (75)   NULL,
    [SubHeader]         VARCHAR (75)   NULL,
    [Column1]           VARCHAR (75)   NULL,
    [Column2]           VARCHAR (75)   NULL,
    [Column3]           VARCHAR (75)   NULL,
    [ColumnPage1]       VARCHAR (75)   NULL,
    [ColumnPage2]       VARCHAR (75)   NULL,
    [ColumnPage3]       VARCHAR (75)   NULL,
    [Footer1]           VARCHAR (50)   NULL,
    [Footer2]           VARCHAR (50)   NULL,
    [ServiceID]         VARCHAR (15)   NULL,
    [Remark]            NVARCHAR (300) DEFAULT (NULL) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_DiagnosisMasterDetails]
    ON [dbo].[Lab_DiagnosisMasterDetails]([BranchID] ASC, [Trans_Key] ASC, [DiagnosisID] ASC);

