CREATE TABLE [dbo].[PharmacyDosageDetails] (
    [branchID]           VARCHAR (15)  NULL,
    [Trans_key]          NUMERIC (12)  NOT NULL,
    [RowNBR]             NUMERIC (5)   NULL,
    [PatientNameEnglish] NVARCHAR (50) NULL,
    [item_code]          VARCHAR (15)  NULL,
    [expiry]             DATETIME      NULL,
    [dosageID]           VARCHAR (15)  NULL,
    [create_date]        DATETIME      DEFAULT (getdate()) NULL,
    [userid]             VARCHAR (15)  NULL,
    [machineid]          VARCHAR (20)  NULL
);

