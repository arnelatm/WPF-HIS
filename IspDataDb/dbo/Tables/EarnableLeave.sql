CREATE TABLE [dbo].[EarnableLeave] (
    [IdNo]                    SMALLINT        IDENTITY (1, 1) NOT NULL,
    [LeaveIdNo]               SMALLINT        NULL,
    [NoLimit]                 BIT             NULL,
    [YearsOfServiceStart]     TINYINT         NULL,
    [YearsOfServiceEnd]       TINYINT         NULL,
    [LeaveDaysAllowedPerYear] TINYINT         NULL,
    [DaysRatio]               DECIMAL (10, 2) NULL,
    [MinimumDaysForLeave]     TINYINT         NULL,
    [MinimumDays]             SMALLINT        NULL,
    CONSTRAINT [PK_EarnableLeave] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



