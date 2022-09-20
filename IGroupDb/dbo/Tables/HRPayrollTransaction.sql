CREATE TABLE [dbo].[HRPayrollTransaction] (
    [BranchID]    VARCHAR (15) NOT NULL,
    [Trans_Key]   NUMERIC (10) NOT NULL,
    [TransSource] VARCHAR (30) NULL,
    [TransType]   VARCHAR (2)  NULL,
    [TransSeries] VARCHAR (30) NULL,
    [TransNBR]    NUMERIC (10) NOT NULL,
    [TransDate]   VARCHAR (10) NOT NULL,
    [PeriodMonth] VARCHAR (20) NOT NULL,
    [PeriodYear]  VARCHAR (20) NOT NULL,
    [ProcessedOn] VARCHAR (10) NOT NULL,
    [Closed]      INT          NULL,
    [UserID]      VARCHAR (15) NULL,
    [Create_Date] DATETIME     NULL,
    [MachineID]   VARCHAR (20) NULL
);

