CREATE TABLE [dbo].[TMPLABRESULT] (
    [InvoiceNo]         NUMERIC (10)    NULL,
    [RegistrationNo]    NUMERIC (10)    NULL,
    [InvoiceDate]       VARCHAR (10)    NULL,
    [InvestigationName] VARCHAR (50)    NULL,
    [Observation]       VARCHAR (50)    NULL,
    [Result1]           NVARCHAR (3000) NULL,
    [Suffix1]           NVARCHAR (100)  NULL,
    [ReportHeader]      VARCHAR (75)    NULL,
    [UserName]          NVARCHAR (128)  NULL,
    [PrintStatus]       CHAR (1)        NULL
);

