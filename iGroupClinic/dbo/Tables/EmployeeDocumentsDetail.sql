CREATE TABLE [dbo].[EmployeeDocumentsDetail] (
    [EmpID]        VARCHAR (15)  NOT NULL,
    [DocID]        VARCHAR (15)  NOT NULL,
    [IssueCountry] VARCHAR (4)   NULL,
    [IssueDate]    VARCHAR (10)  NULL,
    [ExpiryDate]   VARCHAR (10)  NULL,
    [remark]       VARCHAR (150) NULL,
    [DocumentNo]   VARCHAR (30)  NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_EmployeeDocumentsDetail]
    ON [dbo].[EmployeeDocumentsDetail]([EmpID] ASC, [DocID] ASC);

