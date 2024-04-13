CREATE TABLE [dbo].[EarnableLeave] (
    [IdNo]                    SMALLINT        IDENTITY (1, 1) NOT NULL,
    [LeaveIdNo]               SMALLINT        NOT NULL,
    [NoLimit]                 BIT             NULL,
    [YearsOfServiceStart]     TINYINT         NULL,
    [YearsOfServiceEnd]       TINYINT         NULL,
    [LeaveDaysAllowedPerYear] SMALLINT        NULL,
    [DaysRatio]               DECIMAL (10, 2) NOT NULL,
    [MinimumDaysForLeave]     TINYINT         NULL,
    [MinimumDays]             SMALLINT        NULL,
    CONSTRAINT [PK_EarnableLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





