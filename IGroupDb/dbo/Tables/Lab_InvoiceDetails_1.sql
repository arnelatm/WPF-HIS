CREATE TABLE [dbo].[Lab_InvoiceDetails] (
    [BranchID]        VARCHAR (15)    NOT NULL,
    [Group_Key]       NUMERIC (12)    NOT NULL,
    [SlNo]            NUMERIC (5)     NOT NULL,
    [InvestigationID] VARCHAR (15)    NOT NULL,
    [Diagnosis1]      VARCHAR (100)   NULL,
    [Result1]         NVARCHAR (3000) NULL,
    [Suffix1]         NVARCHAR (100)  NULL,
    [Diagnosis2]      VARCHAR (100)   NULL,
    [Result2]         NVARCHAR (100)  NULL,
    [Suffix2]         NVARCHAR (100)  NULL,
    [Diagnosis3]      VARCHAR (100)   NULL,
    [Result3]         NVARCHAR (100)  NULL,
    [Suffix3]         NVARCHAR (100)  NULL,
    [Diagnosis4]      VARCHAR (100)   NULL,
    [Result4]         NVARCHAR (100)  NULL,
    [Suffix4]         NVARCHAR (100)  NULL,
    [CFactor]         BIGINT          NULL,
    [PrintStatus]     CHAR (1)        NULL,
    [s1]              CHAR (1)        NULL,
    [s2]              CHAR (1)        NULL,
    [s3]              CHAR (1)        NULL,
    [s4]              CHAR (1)        NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_InvoiceDetails]
    ON [dbo].[Lab_InvoiceDetails]([BranchID] ASC, [Group_Key] ASC, [InvestigationID] ASC, [SlNo] ASC);

