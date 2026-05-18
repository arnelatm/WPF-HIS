CREATE TABLE [dbo].[payroll_socialsecuritydeduction] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [country_code] NVARCHAR (10)  NULL,
    [used]         INT            NULL,
    [data]         NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

