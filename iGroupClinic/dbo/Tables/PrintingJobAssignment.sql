CREATE TABLE [dbo].[PrintingJobAssignment] (
    [id]                 INT          IDENTITY (1, 1) NOT NULL,
    [WorkID]             VARCHAR (20) NOT NULL,
    [MachineID]          VARCHAR (20) NOT NULL,
    [PrinterName]        VARCHAR (50) NULL,
    [NetWorkPrinterName] VARCHAR (50) NULL,
    [DriverName]         VARCHAR (50) NULL,
    [AttachedPort]       VARCHAR (50) NULL,
    [PaperSource]        VARCHAR (20) DEFAULT ('BOTTOM') NULL,
    [Orientation]        VARCHAR (20) DEFAULT ('PORTRAIT') NULL,
    [DefaultSource]      VARCHAR (20) DEFAULT ('TOP') NULL,
    [DefaultPrinter]     INT          DEFAULT (0) NULL
);


GO
CREATE UNIQUE CLUSTERED INDEX [IDX_PrintingJobAssignment]
    ON [dbo].[PrintingJobAssignment]([id] ASC, [WorkID] ASC);

