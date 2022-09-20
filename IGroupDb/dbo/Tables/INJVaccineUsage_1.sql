CREATE TABLE [dbo].[INJVaccineUsage] (
    [BranchID]       VARCHAR (15)   NULL,
    [TransNbr]       NUMERIC (12)   NULL,
    [TransType]      VARCHAR (10)   NULL,
    [DoctorID]       VARCHAR (15)   NULL,
    [PatientType]    VARCHAR (15)   NULL,
    [RegistrationNo] NUMERIC (12)   NULL,
    [SlNo]           NUMERIC (10)   NULL,
    [Date]           VARCHAR (10)   NULL,
    [CostCentreID]   VARCHAR (15)   NULL,
    [Item_Code]      VARCHAR (15)   NULL,
    [IServiceID]     VARCHAR (15)   NULL,
    [ServiceID]      VARCHAR (15)   NULL,
    [UsedQty]        NUMERIC (5, 2) NULL,
    [UserID]         VARCHAR (15)   NULL,
    [Create_Date]    DATETIME       NULL,
    [MachineID]      VARCHAR (20)   NULL
);

