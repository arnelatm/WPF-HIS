CREATE TABLE [dbo].[PMRFavoriteSignificantSigns] (
    [SSID]          VARCHAR (15)  NOT NULL,
    [SSNameEnglish] VARCHAR (300) NULL,
    [SSNameArabic]  VARCHAR (300) NULL,
    [DoctorID]      VARCHAR (15)  NOT NULL,
    [UserID]        VARCHAR (15)  NULL,
    [Create_Date]   DATETIME      NULL,
    [MachineID]     VARCHAR (20)  NULL
);

