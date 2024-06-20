CREATE TABLE [dbo].[IBLabSampleTaken] (
    [IdNo]        INT          IDENTITY (1, 1) NOT NULL,
    [Trans_Key]   NUMERIC (10) NOT NULL,
    [LabReportNo] VARCHAR (15) NULL,
    [TakenDate]   VARCHAR (10) CONSTRAINT [DF__IBLabSamp__Taken__1D1D0420] DEFAULT (getdate()) NULL,
    [TakenTime]   VARCHAR (15) NULL,
    [TakenBy]     VARCHAR (50) CONSTRAINT [DF__IBLabSamp__Taken__1E112859] DEFAULT ('Admin') NULL,
    [Urine]       BIT          NULL,
    [Stool]       BIT          NULL,
    [RBS]         SMALLINT     NULL,
    [Create_Date] DATETIME     CONSTRAINT [DF__IBLabSamp__Creat__1F054C92] DEFAULT (getdate()) NULL,
    [MachineID]   VARCHAR (20) CONSTRAINT [DF__IBLabSamp__Machi__1FF970CB] DEFAULT (host_name()) NULL
);




GO
CREATE CLUSTERED INDEX [IDX_IBLabSampleTaken]
    ON [dbo].[IBLabSampleTaken]([LabReportNo] ASC);

