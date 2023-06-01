CREATE TABLE [dbo].[PrintJob] (
    [IdNo]             INT           IDENTITY (1, 1) NOT NULL,
    [PrintJobCode]     VARCHAR (10)  NOT NULL,
    [PrintJobName]     VARCHAR (50)  NOT NULL,
    [PrintJobNameAra]  NVARCHAR (50) NULL,
    [PrinterIdNo]      SMALLINT      NULL,
    [PaperSource]      SMALLINT      NULL,
    [PaperOrientation] SMALLINT      NULL,
    [PaperSize]        SMALLINT      NULL,
    [ComputerIdNo]     SMALLINT      NULL,
    [PrintSetupIdNo]   SMALLINT      NULL,
    [DateTimeStamp]    ROWVERSION    NULL,
    CONSTRAINT [PK_PrintJob] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);









