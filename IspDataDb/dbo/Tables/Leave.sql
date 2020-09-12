CREATE TABLE [dbo].[Leave] (
    [IdNo]                  SMALLINT      IDENTITY (1, 1) NOT NULL,
    [AbsenceLeaveName]      VARCHAR (50)  NULL,
    [AbsenceLeaveNameAra]   NVARCHAR (50) NULL,
    [PaidDays]              SMALLINT      NULL,
    [WarningDays]           SMALLINT      NULL,
    [Cumulative]            BIT           NULL,
    [WithMaximumCumulative] BIT           NULL,
    [MaximumCumulativeDays] SMALLINT      NULL,
    CONSTRAINT [PK_AbsenceLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

