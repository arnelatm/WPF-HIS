CREATE TABLE [dbo].[Leave] (
    [IdNo]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [LeaveCode]     VARCHAR (3)    NULL,
    [LeaveName]     VARCHAR (100)  NOT NULL,
    [LeaveNameAra]  NVARCHAR (100) NOT NULL,
    [LeaveAllowed]  SMALLINT       NULL,
    [PaidPercent]   DECIMAL (6, 2) NULL,
    [MaxCarryOver]  SMALLINT       NULL,
    [Cumulative]    BIT            NULL,
    [MaxLimit]      DECIMAL (7, 2) NULL,
    [Notes]         NVARCHAR (200) NULL,
    [DateTimeStamp] ROWVERSION     NULL,
    CONSTRAINT [PK_AbsenceLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);







