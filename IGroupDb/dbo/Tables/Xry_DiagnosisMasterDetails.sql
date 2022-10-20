CREATE TABLE [dbo].[Xry_DiagnosisMasterDetails] (
    [BranchID]                 VARCHAR (15)   NOT NULL,
    [Trans_Key]                BIGINT         NOT NULL,
    [DiagnosisID]              VARCHAR (15)   NULL,
    [InpWndID]                 VARCHAR (15)   NULL,
    [ReportID]                 VARCHAR (15)   NULL,
    [InvestigationID]          VARCHAR (15)   NOT NULL,
    [InvestigationName]        VARCHAR (50)   NOT NULL,
    [InvestigationDescription] NVARCHAR (MAX) NULL,
    [ReportHeader]             VARCHAR (75)   NULL,
    [SubHeader]                VARCHAR (75)   NULL,
    [Footer1]                  VARCHAR (50)   NULL,
    [Footer2]                  VARCHAR (50)   NULL
);

