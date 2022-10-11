CREATE TABLE [dbo].[PMRFavoriteChiefComplaints] (
    [ComplaintID]          VARCHAR (15)  NOT NULL,
    [ComplaintNameEnglish] VARCHAR (300) NULL,
    [ComplaintNameArabic]  VARCHAR (300) NULL,
    [DoctorID]             VARCHAR (15)  NOT NULL,
    [UserID]               VARCHAR (15)  NULL,
    [Create_Date]          DATETIME      NULL,
    [MachineID]            VARCHAR (20)  NULL
);

