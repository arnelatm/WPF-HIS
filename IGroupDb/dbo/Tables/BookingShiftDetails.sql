CREATE TABLE [dbo].[BookingShiftDetails] (
    [Trans_key]   INT          NULL,
    [BranchId]    VARCHAR (5)  NULL,
    [DoctorId]    VARCHAR (5)  NULL,
    [Description] VARCHAR (50) NULL,
    [DIrectShift] CHAR (10)    NULL,
    [ShiftStart]  TIME (7)     NULL,
    [shiftEnd]    TIME (7)     NULL,
    [LunchStart]  TIME (7)     NULL,
    [LunchEnd]    TIME (7)     NULL,
    [Activate]    CHAR (1)     NULL,
    [UserId]      VARCHAR (30) NULL,
    [Create_date] DATETIME     NULL,
    [MachineId]   VARCHAR (30) NULL
);

