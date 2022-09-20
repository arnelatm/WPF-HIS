CREATE TABLE [dbo].[HREmployeeInstallmentGroup] (
    [Trans_Key]        INT             NOT NULL,
    [EmpID]            VARCHAR (15)    NOT NULL,
    [Month]            VARCHAR (15)    NULL,
    [Year]             VARCHAR (4)     NULL,
    [TransNBR]         NUMERIC (10)    NULL,
    [TransDateEnglish] VARCHAR (10)    NULL,
    [TransType]        VARCHAR (10)    NULL,
    [StartingMonth]    VARCHAR (15)    NULL,
    [StartingYear]     VARCHAR (4)     NULL,
    [TotalAmount]      NUMERIC (10, 2) NULL,
    [NoOfInstallments] INT             NULL,
    [InstallmentAmt]   NUMERIC (10, 2) NULL,
    [Remark]           VARCHAR (300)   NULL,
    [UserID]           VARCHAR (15)    NULL,
    [Create_Date]      DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_HREmployeeInstallmentGroup]
    ON [dbo].[HREmployeeInstallmentGroup]([TransNBR] ASC, [EmpID] ASC);

