CREATE TABLE [dbo].[Insurance_DiscountTahmel] (
    [ID]                   INT             IDENTITY (1, 1) NOT NULL,
    [GroupCode]            NVARCHAR (MAX)  NULL,
    [WorkCode]             NVARCHAR (MAX)  NULL,
    [InsurancePolicy]      NVARCHAR (MAX)  NULL,
    [InsuranceCompanyCode] NVARCHAR (MAX)  NULL,
    [InsuranceClass]       NVARCHAR (MAX)  NULL,
    [ValueType]            NVARCHAR (50)   NULL,
    [Value]                DECIMAL (18, 2) NULL,
    [ValueCurancy]         NVARCHAR (2)    NULL,
    [StartDate]            DATE            NULL,
    CONSTRAINT [PK_Insurance_DiscountTahmel] PRIMARY KEY CLUSTERED ([ID] ASC)
);

