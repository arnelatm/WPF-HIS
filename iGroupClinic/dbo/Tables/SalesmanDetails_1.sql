CREATE TABLE [dbo].[SalesmanDetails] (
    [Primary_Key]         INT             IDENTITY (1, 1) NOT NULL,
    [BranchID]            VARCHAR (15)    NOT NULL,
    [SalesmanID]          VARCHAR (15)    NOT NULL,
    [Courtesy]            VARCHAR (15)    NULL,
    [SalesmanNameEnglish] VARCHAR (50)    NOT NULL,
    [SalesmanNameArabic]  NVARCHAR (50)   NULL,
    [Mobile]              VARCHAR (50)    NULL,
    [email]               VARCHAR (50)    NULL,
    [AC_Code]             VARCHAR (10)    NULL,
    [CreditAmt]           NUMERIC (12, 2) NULL,
    [CreditPer]           NUMERIC (12, 2) NULL,
    [Remarks]             VARCHAR (150)   NULL,
    [Blocked]             VARCHAR (3)     DEFAULT ('No') NULL,
    [Create_date]         VARCHAR (10)    NULL,
    [UserId]              VARCHAR (10)    NULL,
    [MachineId]           VARCHAR (20)    NULL,
    PRIMARY KEY CLUSTERED ([Primary_Key] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SalesmanDetails]
    ON [dbo].[SalesmanDetails]([SalesmanID] ASC);

