CREATE TABLE [dbo].[BookingSplShiftSchedulexxxxx] (
    [BookingID]   INT          NULL,
    [BranchId]    VARCHAR (2)  NULL,
    [DoctorId]    VARCHAR (5)  NULL,
    [ShiftId]     VARCHAR (10) NULL,
    [SplShiftId]  VARCHAR (10) NULL,
    [DateFrom]    DATE         NULL,
    [DateUpTo]    DATE         NULL,
    [OffDay]      CHAR (1)     NULL,
    [Activate]    CHAR (1)     NULL,
    [Remark]      VARCHAR (50) NULL,
    [UserId]      VARCHAR (30) NULL,
    [Create_date] DATETIME     NULL,
    [MachineId]   VARCHAR (30) NULL
);

