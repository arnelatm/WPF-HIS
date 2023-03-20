CREATE TABLE [dbo].[PrintingJobAssignment] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [WorkID]             VARCHAR (20)  NOT NULL,
    [MachineID]          VARCHAR (20)  NOT NULL,
    [PrinterName]        VARCHAR (100) NULL,
    [NetWorkPrinterName] VARCHAR (50)  NULL,
    [DriverName]         VARCHAR (100) NULL,
    [AttachedPort]       VARCHAR (50)  NULL,
    [PaperSource]        VARCHAR (20)  CONSTRAINT [DF__PrintingJ__Paper__39AD8A7F] DEFAULT ('BOTTOM') NULL,
    [Orientation]        VARCHAR (20)  CONSTRAINT [DF__PrintingJ__Orien__3AA1AEB8] DEFAULT ('PORTRAIT') NULL,
    [DefaultSource]      VARCHAR (20)  CONSTRAINT [DF__PrintingJ__Defau__3B95D2F1] DEFAULT ('TOP') NULL,
    [DefaultPrinter]     INT           CONSTRAINT [DF__PrintingJ__Defau__3C89F72A] DEFAULT ((0)) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PrintingJobAssignment]
    ON [dbo].[PrintingJobAssignment]([id] ASC, [WorkID] ASC);

