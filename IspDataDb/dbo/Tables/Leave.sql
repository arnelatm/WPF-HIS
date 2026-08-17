CREATE TABLE [dbo].[Leave] (
    [IdNo]          SMALLINT       IDENTITY (1, 1) NOT NULL,
    [LeaveCode]     VARCHAR (3)    NOT NULL,
    [LeaveName]     VARCHAR (100)  NOT NULL,
    [LeaveNameAra]  NVARCHAR (100) NOT NULL,
    [LeaveAllowed]  DECIMAL (6, 2) NULL,
    [LeaveType]     CHAR (1)       NULL,
    [PaidPercent]   DECIMAL (6, 2) NULL,
    [MaxCarryOver]  DECIMAL (6, 2) NULL,
    [Holiday]       BIT            NULL,
    [Cumulative]    BIT            NULL,
    [NoMaxLimit]    BIT            NULL,
    [MaxLimit]      DECIMAL (7, 2) NULL,
    [Notes]         NVARCHAR (200) NULL,
    [Earnable]      BIT            NULL,
    [DateTimeStamp] ROWVERSION     NULL,
    CONSTRAINT [PK_AbsenceLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);


GO

CREATE UNIQUE NONCLUSTERED INDEX [LeaveLeaveCode]
    ON [dbo].[Leave]([LeaveCode] ASC);


GO

