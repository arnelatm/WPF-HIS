CREATE TABLE [dbo].[PMRDentalDrawing] (
    [Trans_Key]        BIGINT       NOT NULL,
    [PatientType]      VARCHAR (15) DEFAULT ('Insurance') NULL,
    [Series]           CHAR (2)     DEFAULT ('CR') NULL,
    [RegistrationNo]   NUMERIC (10) NOT NULL,
    [TransDateEnglish] VARCHAR (10) NULL,
    [DoctorID]         VARCHAR (15) NULL,
    [ImageFile]        VARCHAR (75) NULL,
    [Image]            IMAGE        NULL,
    [RowNBR]           NUMERIC (5)  DEFAULT (1) NULL,
    [UserID]           VARCHAR (10) NULL,
    [Create_Date]      DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (15) DEFAULT (host_name()) NULL
);

