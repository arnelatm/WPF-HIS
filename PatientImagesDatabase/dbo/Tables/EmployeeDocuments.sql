CREATE TABLE [dbo].[EmployeeDocuments] (
    [EmpID]      VARCHAR (15)    NULL,
    [DocumentID] VARCHAR (15)    NULL,
    [Photo]      VARBINARY (MAX) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_EmployeeDocuments]
    ON [dbo].[EmployeeDocuments]([EmpID] ASC, [DocumentID] ASC);

