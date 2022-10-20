CREATE TABLE [dbo].[HRShiftDetails] (
    [BranchID]                    VARCHAR (15)  NOT NULL,
    [ShiftID]                     VARCHAR (15)  NOT NULL,
    [ShiftDescription]            VARCHAR (50)  NOT NULL,
    [PunchNecessary]              INT           NULL,
    [ShiftType]                   INT           NULL,
    [OverNight]                   INT           NULL,
    [NextDay]                     INT           NULL,
    [PrevDay]                     INT           NULL,
    [ShiftStart]                  VARCHAR (12)  NULL,
    [ShiftEnd]                    VARCHAR (12)  NULL,
    [RestStart]                   VARCHAR (12)  NULL,
    [RestEnd]                     VARCHAR (12)  NULL,
    [PunchExceptionShiftStarting] INT           NULL,
    [PunchExceptionShiftEnding]   INT           NULL,
    [PunchExceptionRestStarting]  INT           NULL,
    [PunchExceptionRestEnding]    INT           NULL,
    [ShiftColor]                  VARCHAR (50)  NULL,
    [Remark]                      VARCHAR (150) NULL
);

