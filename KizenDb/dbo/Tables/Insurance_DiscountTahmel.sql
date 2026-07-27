CREATE TABLE [dbo].[Insurance_DiscountTahmel] (
    [ID]                   INT             IDENTITY (1, 1) NOT NULL,
    [GroupCode]            NVARCHAR (100)  NULL,
    [WorkCode]             NVARCHAR (MAX)  NULL,
    [InsurancePolicy]      NVARCHAR (100)  NULL,
    [InsuranceCompanyCode] NVARCHAR (100)  NULL,
    [InsuranceClass]       NVARCHAR (55)   NULL,
    [ValueType]            NVARCHAR (50)   NULL,
    [Value]                DECIMAL (18, 2) NULL,
    [ValueCurancy]         NVARCHAR (2)    NULL,
    [StartDate]            DATE            NULL,
    CONSTRAINT [PK_Insurance_DiscountTahmel] PRIMARY KEY CLUSTERED ([ID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Insurance_DiscountTahmel_Lookup]
    ON [dbo].[Insurance_DiscountTahmel]([InsuranceCompanyCode] ASC, [ValueType] ASC, [InsurancePolicy] ASC, [InsuranceClass] ASC)
    INCLUDE([WorkCode], [Value], [ValueCurancy], [StartDate]);

