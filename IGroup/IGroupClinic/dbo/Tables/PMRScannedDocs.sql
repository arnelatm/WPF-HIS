CREATE TABLE [dbo].[PMRScannedDocs] (
    [DocID]              VARCHAR (10)    NOT NULL,
    [DescriptionEnglish] VARCHAR (40)    NULL,
    [DescriptionArabic]  NVARCHAR (40)   NULL,
    [AllignLeft]         NUMERIC (10, 2) DEFAULT (0) NULL,
    [AllignTop]          NUMERIC (10, 2) DEFAULT (0) NULL,
    [DocWidth]           NUMERIC (10, 2) DEFAULT (8.23) NULL,
    [DocHeight]          NUMERIC (10, 2) DEFAULT (11.5) NULL,
    [UserID]             VARCHAR (15)    DEFAULT ('TEKNOSys') NULL,
    [Create_Date]        DATETIME        DEFAULT (getdate()) NULL,
    [MachineID]          VARCHAR (20)    DEFAULT (host_name()) NULL
);

