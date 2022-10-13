CREATE TABLE [dbo].[PrintJobAssignment] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [PrintJobName]     VARCHAR (20)  NOT NULL,
    [ComputerName]     VARCHAR (30)  NOT NULL,
    [PrinterName]      VARCHAR (100) NOT NULL,
    [PaperSource]      TINYINT       CONSTRAINT [DF__PrintingJ__Paper__0015E5C7] DEFAULT ((7)) NULL,
    [PaperOrientation] TINYINT       CONSTRAINT [DF__PrintingJ__Orien__010A0A00] DEFAULT ((0)) NULL,
    [PaperSize]        INT           NULL,
    CONSTRAINT [PK_PrintJobAssignment] PRIMARY KEY CLUSTERED ([id] ASC)
);

