CREATE TABLE [dbo].[Report] (
    [IdNo]                  SMALLINT       IDENTITY (1, 1) NOT NULL,
    [BranchIdNo]            TINYINT        NULL,
    [BranchID]              VARCHAR (15)   NULL,
    [ReportCode]            VARCHAR (5)    NULL,
    [ReportName]            VARCHAR (200)  NULL,
    [ReportNameAra]         NVARCHAR (200) NULL,
    [PrintJobIdNo]          SMALLINT       NULL,
    [PrinterIdNo]           SMALLINT       NULL,
    [PaperSource]           TINYINT        NULL,
    [PaperOrientation]      TINYINT        NULL,
    [PaperSize]             SMALLINT       NULL,
    [ReportGroup]           VARCHAR (10)   NULL,
    [ReportGroupIdNo]       SMALLINT       NULL,
    [ReportNo]              NUMERIC (5)    NULL,
    [ReportOrder]           NUMERIC (5)    NULL,
    [ReportFileName]        VARCHAR (200)  NULL,
    [ReportTitle]           VARCHAR (200)  NULL,
    [ReportTitleAra]        NVARCHAR (200) NULL,
    [ReportHeadingEnglish1] VARCHAR (75)   NULL,
    [ReportHeadingEnglish2] VARCHAR (75)   NULL,
    [ReportHeadingArabic1]  NVARCHAR (75)  NULL,
    [ReportHeadingArabic2]  NVARCHAR (75)  NULL,
    [QueryColumns]          VARCHAR (1000) NULL,
    [QueryFrom]             VARCHAR (500)  NULL,
    [SQLWhereClause]        VARCHAR (500)  NULL,
    [SQLGroupClause]        VARCHAR (500)  NULL,
    [QueryParameters]       VARCHAR (250)  NULL,
    [SQLOrderByClause]      VARCHAR (250)  NULL,
    [ReportUsedFunction]    VARCHAR (50)   NULL,
    [ReportDescription]     VARCHAR (300)  NULL,
    [ReportTxtParameters]   VARCHAR (500)  NULL,
    [UnionParameters]       VARCHAR (15)   NULL,
    [OtherParameters]       VARCHAR (300)  NULL,
    [doc_type]              CHAR (1)       CONSTRAINT [DF__ReportCre__doc_t__2C938683] DEFAULT ('D') NULL,
    [UserID]                VARCHAR (15)   CONSTRAINT [DF__ReportCre__UserI__2D87AABC] DEFAULT ('Admin') NULL,
    [DateCreated]           DATETIME       CONSTRAINT [DF__ReportCre__Creat__2E7BCEF5] DEFAULT (getdate()) NULL,
    [MachineID]             VARCHAR (20)   CONSTRAINT [DF__ReportCre__Machi__2F6FF32E] DEFAULT (host_name()) NULL,
    [QueryForm]             VARCHAR (50)   NULL,
    [QueryFormParameters]   VARCHAR (MAX)  NULL,
    [DatabaseName]          VARCHAR (12)   NULL,
    [Active]                BIT            NULL,
    CONSTRAINT [PK_ReportCreator] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);











