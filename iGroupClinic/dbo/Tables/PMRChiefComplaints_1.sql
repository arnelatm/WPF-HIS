CREATE TABLE [dbo].[PMRChiefComplaints] (
    [ComplaintID]          VARCHAR (15)   NOT NULL,
    [Trans_key]            NUMERIC (10)   NULL,
    [ComplaintNameEnglish] VARCHAR (100)  NOT NULL,
    [ComplaintNameArabic]  NVARCHAR (100) NULL,
    [UserID]               VARCHAR (15)   NULL,
    [Create_Date]          DATETIME       NULL,
    [machineid]            VARCHAR (20)   NULL,
    [id]                   INT            IDENTITY (1, 1) NOT NULL
);

