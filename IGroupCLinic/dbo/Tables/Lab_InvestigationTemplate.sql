CREATE TABLE [dbo].[Lab_InvestigationTemplate] (
    [Trans_Key]       NUMERIC (12)    NOT NULL,
    [TemplateID]      VARCHAR (15)    NOT NULL,
    [TemplateName]    VARCHAR (50)    NOT NULL,
    [ServiceID]       VARCHAR (15)    NULL,
    [InvestigationID] VARCHAR (15)    NOT NULL,
    [SlNo]            NUMERIC (5)     NOT NULL,
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
    [s4]              CHAR (1)        NULL,
    [UserID]          VARCHAR (15)    NULL,
    [Create_Date]     DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]       VARCHAR (20)    DEFAULT (host_name()) NULL,
    [Status]          INT             DEFAULT ((1)) NULL,
    [Remark]          NVARCHAR (300)  NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_InvestigationTemplate]
    ON [dbo].[Lab_InvestigationTemplate]([TemplateName] ASC, [SlNo] ASC);

