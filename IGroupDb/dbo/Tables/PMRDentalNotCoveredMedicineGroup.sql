CREATE TABLE [dbo].[PMRDentalNotCoveredMedicineGroup] (
    [Trans_Key]        BIGINT          NOT NULL,
    [TransNBR]         BIGINT          NOT NULL,
    [TransDateEnglish] VARCHAR (10)    DEFAULT (getdate()) NULL,
    [PatientType]      VARCHAR (2)     NULL,
    [Series]           VARCHAR (2)     NOT NULL,
    [RegistrationNo]   NUMERIC (10)    NOT NULL,
    [InsuranceID]      VARCHAR (15)    NULL,
    [InsuranceGroupID] VARCHAR (15)    NULL,
    [DoctorID]         VARCHAR (10)    NULL,
    [BillAmt]          NUMERIC (10, 2) DEFAULT (0) NULL,
    [IssueFlag]        CHAR (1)        DEFAULT ('N') NULL,
    [Remarks]          NTEXT           NULL,
    [UserID]           VARCHAR (15)    NULL,
    [Create_Date]      DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalNotCoveredMedicineGroup]
    ON [dbo].[PMRDentalNotCoveredMedicineGroup]([Trans_Key] ASC, [TransNBR] ASC);

