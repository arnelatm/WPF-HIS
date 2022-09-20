CREATE TABLE [dbo].[IBLabSampleTaken] (
    [Trans_Key]   NUMERIC (10) NOT NULL,
    [LabReportNo] VARCHAR (15) NULL,
    [TakenDate]   VARCHAR (10) DEFAULT (getdate()) NULL,
    [TakenTime]   VARCHAR (15) NULL,
    [TakenBy]     VARCHAR (50) DEFAULT ('Admin') NULL,
    [Create_Date] DATETIME     DEFAULT (getdate()) NULL,
    [MachineID]   VARCHAR (20) DEFAULT (host_name()) NULL
);


GO
CREATE CLUSTERED INDEX [IDX_IBLabSampleTaken]
    ON [dbo].[IBLabSampleTaken]([LabReportNo] ASC);

