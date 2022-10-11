CREATE TABLE [dbo].[HREmployeeInstallmentDetails] (
    [Group_Key]       INT             NOT NULL,
    [RowNBR]          INT             NULL,
    [Month]           VARCHAR (15)    NULL,
    [Year]            VARCHAR (4)     NULL,
    [InstallmentsAmt] NUMERIC (10, 2) NULL,
    [PendingAmt]      NUMERIC (10, 2) NULL,
    [DeductedAmt]     NUMERIC (10, 2) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_HREmployeeInstallmentDetails]
    ON [dbo].[HREmployeeInstallmentDetails]([Group_Key] ASC, [RowNBR] ASC, [Month] ASC, [Year] ASC);

