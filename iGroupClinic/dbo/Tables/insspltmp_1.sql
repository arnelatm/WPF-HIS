CREATE TABLE [dbo].[insspltmp] (
    [BranchID]           VARCHAR (15)    NOT NULL,
    [InsuranceID]        VARCHAR (15)    NOT NULL,
    [GroupInsuranceID]   VARCHAR (15)    NOT NULL,
    [DepartmentID]       VARCHAR (15)    NOT NULL,
    [ServiceID]          VARCHAR (15)    NOT NULL,
    [ServiceNameEnglish] VARCHAR (75)    NULL,
    [Price]              NUMERIC (10, 2) NULL,
    [DiscountPercent]    NUMERIC (7, 2)  NULL,
    [DiscountAmt]        NUMERIC (10, 2) NULL,
    [Status]             VARCHAR (1)     NULL
);

