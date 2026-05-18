CREATE TABLE [dbo].[payroll_specialpayment] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (255) NULL,
    [remark]     NVARCHAR (MAX) NULL,
    [created_at] DATETIME2 (7)  NULL,
    [updated_at] DATETIME2 (7)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [payroll_specialpayment_name_797d57c6_uniq]
    ON [dbo].[payroll_specialpayment]([name] ASC) WHERE ([name] IS NOT NULL);

