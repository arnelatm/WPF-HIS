CREATE TABLE [dbo].[PrintJob] (
    [IdNo]             INT      IDENTITY (1, 1) NOT NULL,
    [ComputerIdNo]     SMALLINT NOT NULL,
    [PrintJobIdNo]     SMALLINT NOT NULL,
    [PrinterIdNo]      SMALLINT NULL,
    [PaperSource]      TINYINT  CONSTRAINT [DF__PrintingJ__Paper__0015E5C7] DEFAULT ((7)) NULL,
    [PaperOrientation] TINYINT  CONSTRAINT [DF__PrintingJ__Orien__010A0A00] DEFAULT ((0)) NULL,
    [PaperSize]        INT      NULL,
    CONSTRAINT [PK_PrintJobAssignment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





