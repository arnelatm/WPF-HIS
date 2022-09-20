CREATE TABLE [dbo].[PMRClinicInvoiceGenerated] (
    [PMRTrans_Key]     BIGINT          NOT NULL,
    [ClinicTrans_Key]  BIGINT          NULL,
    [ClinicTransNBR]   BIGINT          NULL,
    [TransDateEnglish] VARCHAR (10)    NOT NULL,
    [PatientType]      VARCHAR (15)    NOT NULL,
    [RegistrationNo]   NUMERIC (10)    NOT NULL,
    [DoctorID]         VARCHAR (15)    NOT NULL,
    [ServiceID]        VARCHAR (15)    NOT NULL,
    [BillAmt]          NUMERIC (10, 2) NULL,
    [Printed]          INT             DEFAULT ((0)) NULL,
    [UserID]           VARCHAR (15)    NULL,
    [Create_Date]      DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]        VARCHAR (20)    DEFAULT (host_name()) NULL
);

