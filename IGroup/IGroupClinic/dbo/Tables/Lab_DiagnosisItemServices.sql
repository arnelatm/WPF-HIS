CREATE TABLE [dbo].[Lab_DiagnosisItemServices] (
    [BranchID]        VARCHAR (15) NOT NULL,
    [InvestigationID] VARCHAR (15) NOT NULL,
    [ServiceID]       VARCHAR (15) NOT NULL,
    [Default]         INT          DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_DiagnosisItemServices]
    ON [dbo].[Lab_DiagnosisItemServices]([InvestigationID] ASC, [ServiceID] ASC);

