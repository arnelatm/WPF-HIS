CREATE TABLE [dbo].[Printer] (
    [IdNo]                    INT           IDENTITY (1, 1) NOT NULL,
    [PrinterCode]             VARCHAR (10)  NOT NULL,
    [PrinterName]             VARCHAR (100) NOT NULL,
    [HostOrIpName]            VARCHAR (100) NULL,
    [DefaultPaperSource]      TINYINT       NULL,
    [DefaultPaperOrientation] TINYINT       NULL,
    [DefaultPaperSize]        INT           NULL,
    [DateTimeStamp]           ROWVERSION    NULL,
    CONSTRAINT [PK_PrinterAssignment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

