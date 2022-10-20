CREATE TABLE [dbo].[PMRFavoriteMedicineGroup] (
    [Trans_Key]        BIGINT          NOT NULL,
    [TransNBR]         BIGINT          NOT NULL,
    [TransDateEnglish] VARCHAR (10)    NOT NULL,
    [PatientType]      VARCHAR (15)    NULL,
    [Series]           VARCHAR (2)     NOT NULL,
    [RegistrationNo]   NUMERIC (10)    NOT NULL,
    [DoctorID]         VARCHAR (15)    NULL,
    [BillAmt]          NUMERIC (10, 2) NULL,
    [Issue_Flag]       CHAR (1)        DEFAULT ('N') NULL,
    [Dsh_Key]          NUMERIC (10)    DEFAULT (0) NULL,
    [Remarks]          NTEXT           NULL,
    [UserID]           VARCHAR (15)    NULL,
    [Create_Date]      DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)    DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRFavoriteMedicineGroup]
    ON [dbo].[PMRFavoriteMedicineGroup]([Trans_Key] ASC);

