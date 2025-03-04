CREATE TABLE [dbo].[Insurance_Policy] (
    [ID]                 INT             IDENTITY (1, 1) NOT NULL,
    [Code]               NVARCHAR (100)  NULL,
    [CompanyCode]        NVARCHAR (100)  NULL,
    [Name]               NVARCHAR (MAX)  NULL,
    [LatinName]          NVARCHAR (MAX)  NULL,
    [StartDate]          DATE            NULL,
    [EndDate]            DATE            NULL,
    [LimitCustDay]       DECIMAL (18, 2) NULL,
    [UpToPer]            DECIMAL (18, 2) NULL,
    [UpToMoney]          DECIMAL (18, 2) NULL,
    [Class]              NVARCHAR (55)   NULL,
    [Disable]            BIT             NULL,
    [Code2]              NVARCHAR (100)  NULL,
    [CompanyCode2]       NVARCHAR (100)  NULL,
    [Class2]             NVARCHAR (55)   NULL,
    [Code3]              NVARCHAR (100)  NULL,
    [CompanyCode3]       NVARCHAR (100)  NULL,
    [Class3]             NVARCHAR (55)   NULL,
    [DefaultDisc]        DECIMAL (18, 2) NULL,
    [CustomDiscEnb]      BIT             NULL,
    [CustomTahamalEnb]   BIT             NULL,
    [LimitCustVisit]     DECIMAL (18, 2) NULL,
    [ApprovalLimit]      DECIMAL (18, 2) NULL,
    [WithoutDate]        BIT             NULL,
    [CustomItemLimitEnb] BIT             NULL,
    [Code4]              NVARCHAR (100)  NULL,
    [CompanyCode4]       NVARCHAR (100)  NULL,
    [Class4]             NVARCHAR (55)   NULL,
    CONSTRAINT [PK_Insurance_Policy] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Insurance_Policy_Link]
    ON [dbo].[Insurance_Policy]([Code] ASC, [Class] ASC, [CompanyCode] ASC);

