CREATE TABLE [dbo].[PMRChiefComplaintDetailsDental] (
    [ComplaintID]          VARCHAR (15)   NOT NULL,
    [Trans_key]            NUMERIC (10)   DEFAULT (1) NULL,
    [ComplaintNameEnglish] VARCHAR (100)  NOT NULL,
    [ComplaintNameArabic]  NVARCHAR (100) NULL,
    [UserID]               VARCHAR (15)   NULL,
    [Create_Date]          DATETIME       DEFAULT (getdate()) NULL,
    [MachineID]            VARCHAR (20)   DEFAULT (host_name()) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PMRChiefComplaintDetailsDental]
    ON [dbo].[PMRChiefComplaintDetailsDental]([ComplaintID] ASC);

