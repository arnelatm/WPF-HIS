CREATE TABLE [dbo].[Lab_SampleCollectionGroup] (
    [BranchID]       VARCHAR (15)  NOT NULL,
    [Trans_Key]      NUMERIC (12)  NOT NULL,
    [TransType]      VARCHAR (15)  NOT NULL,
    [SampleNo]       NUMERIC (10)  NOT NULL,
    [TakenDate]      VARCHAR (10)  NOT NULL,
    [TakenTime]      VARCHAR (15)  NOT NULL,
    [TransNo]        NUMERIC (10)  NOT NULL,
    [TransDate]      VARCHAR (10)  NOT NULL,
    [PatientType]    VARCHAR (15)  NOT NULL,
    [RegistrationNo] NUMERIC (10)  NOT NULL,
    [TakenByID]      VARCHAR (15)  NULL,
    [TakenByName]    NVARCHAR (50) NULL,
    [PassedByID]     VARCHAR (15)  NULL,
    [PassedByName]   NVARCHAR (50) NULL,
    [Remark]         VARCHAR (100) NULL,
    [PassedDate]     VARCHAR (10)  NULL,
    [PassedTime]     VARCHAR (20)  NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_Lab_SampleCollectionGroup]
    ON [dbo].[Lab_SampleCollectionGroup]([SampleNo] ASC);

