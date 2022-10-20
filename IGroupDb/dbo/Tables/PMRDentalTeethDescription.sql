CREATE TABLE [dbo].[PMRDentalTeethDescription] (
    [Trans_Key]        BIGINT          NOT NULL,
    [RowNBR]           NUMERIC (5)     DEFAULT (1) NOT NULL,
    [TransDateEnglish] VARCHAR (10)    NOT NULL,
    [PatientType]      VARCHAR (15)    NOT NULL,
    [Series]           VARCHAR (2)     NOT NULL,
    [RegistrationNo]   NUMERIC (10)    NOT NULL,
    [DoctorID]         VARCHAR (10)    NULL,
    [ToothNBR]         VARCHAR (2)     NULL,
    [ToothSurface]     VARCHAR (20)    NULL,
    [Treatment]        VARCHAR (50)    NULL,
    [Remarks]          NTEXT           NULL,
    [Cost]             NUMERIC (10, 2) DEFAULT (0) NULL,
    [UserID]           VARCHAR (15)    NULL,
    [Create_Date]      DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)    DEFAULT (host_name()) NULL,
    [Discount]         NUMERIC (10, 2) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRDentalTeethDescription]
    ON [dbo].[PMRDentalTeethDescription]([Trans_Key] ASC, [RowNBR] ASC);

