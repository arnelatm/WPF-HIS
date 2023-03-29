CREATE TABLE [dbo].[PrintSetup] (
    [IdNo]             INT        NOT NULL,
    [ComputerIdNo]     SMALLINT   NOT NULL,
    [PrintJobIdNo]     SMALLINT   NULL,
    [PrinterIdNo]      SMALLINT   NULL,
    [PaperSource]      TINYINT    CONSTRAINT [DF__PrintingJ__Paper__0015E5C7] DEFAULT ((7)) NULL,
    [PaperOrientation] TINYINT    CONSTRAINT [DF__PrintingJ__Orien__010A0A00] DEFAULT ((0)) NULL,
    [PaperSize]        INT        NULL,
    [DateTimeStamp]    ROWVERSION NULL
);

