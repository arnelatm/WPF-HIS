CREATE TABLE [dbo].[Report] (
    [IdNo]           SMALLINT       IDENTITY (1, 1) NOT NULL,
    [ReportFileName] VARCHAR (200)  NULL,
    [ReportTitle]    VARCHAR (200)  NULL,
    [ReportTitleAra] NVARCHAR (200) NULL,
    [PrintSetupIdNo] SMALLINT       NULL,
    [Active]         BIT            NULL,
    [DateCreated]    DATE           CONSTRAINT [DF__Report__Creat__2E7BCEF5] DEFAULT (getdate()) NULL,
    CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









