CREATE TABLE [dbo].[PMRPatientInvestigation] (
    [Trans_Key]           BIGINT          NOT NULL,
    [TransNBR]            BIGINT          NOT NULL,
    [Series]              VARCHAR (2)     NOT NULL,
    [RegistrationNo]      NUMERIC (10)    NOT NULL,
    [DoctorID]            VARCHAR (15)    NULL,
    [InsuranceID]         VARCHAR (15)    NULL,
    [InsuranceGroupID]    VARCHAR (15)    NULL,
    [RowNBR]              INT             NOT NULL,
    [Item_Code]           VARCHAR (15)    NULL,
    [DepartmentID]        VARCHAR (15)    NULL,
    [Qty]                 NUMERIC (5)     DEFAULT (1) NULL,
    [Unit]                CHAR (1)        DEFAULT ('B') NULL,
    [SalePrice]           NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountPer]         NUMERIC (10, 2) DEFAULT (0) NULL,
    [DiscountAmt]         NUMERIC (10, 2) DEFAULT (0) NULL,
    [DeductibleAmt]       NUMERIC (10, 2) DEFAULT (0) NULL,
    [CostPrice]           NUMERIC (10, 2) DEFAULT (0) NULL,
    [BillAmt]             NUMERIC (10, 2) DEFAULT (0) NULL,
    [Issue_Flag]          CHAR (1)        DEFAULT ('N') NULL,
    [Dsh_Key]             NUMERIC (10)    DEFAULT (0) NULL,
    [Remark]              NTEXT           NULL,
    [UserID]              VARCHAR (15)    NULL,
    [Create_Date]         DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]           VARCHAR (20)    DEFAULT (host_name()) NULL,
    [InvestigationRemark] VARCHAR (100)   NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRPatientInvestigation]
    ON [dbo].[PMRPatientInvestigation]([Trans_Key] ASC, [TransNBR] ASC, [RowNBR] ASC);

