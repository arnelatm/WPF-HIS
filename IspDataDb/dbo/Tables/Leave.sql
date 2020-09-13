CREATE TABLE [dbo].[Leave] (
    [IdNo]                  SMALLINT       IDENTITY (1, 1) NOT NULL,
    [LeaveName]             VARCHAR (100)  NOT NULL,
    [LeaveNameAra]          VARCHAR (100)  NOT NULL,
    [NumberOfDays]          SMALLINT       NULL,
    [Percentage]            DECIMAL (5, 2) NULL,
    [WarningDays]           SMALLINT       NULL,
    [Cumulative]            BIT            NULL,
    [WithMaximumCumulative] BIT            NULL,
    [MaximumCumulativeDays] SMALLINT       NULL,
    [Notes]                 NVARCHAR (200) NULL,
    CONSTRAINT [PK_AbsenceLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



