CREATE TABLE [dbo].[PrintJob] (
    [IdNo]             INT          IDENTITY (1, 1) NOT NULL,
    [PrintJobName]     VARCHAR (20) NOT NULL,
    [ComputerIdNo]     SMALLINT     NOT NULL,
    [PrinterIdNo]      SMALLINT     NOT NULL,
    [PaperSource]      TINYINT      CONSTRAINT [DF__PrintingJ__Paper__0015E5C7] DEFAULT ((7)) NULL,
    [PaperOrientation] TINYINT      CONSTRAINT [DF__PrintingJ__Orien__010A0A00] DEFAULT ((0)) NULL,
    [PaperSize]        INT          NULL,
    [NetworkName]      VARCHAR (50) NULL,
    [DateTimeStamp]    ROWVERSION   NULL,
    CONSTRAINT [PK_PrintJobAssignment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



