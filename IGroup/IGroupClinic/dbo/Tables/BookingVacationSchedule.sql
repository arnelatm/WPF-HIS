CREATE TABLE [dbo].[BookingVacationSchedule] (
    [DoctorId]    VARCHAR (5)  NULL,
    [BranchID]    VARCHAR (5)  NULL,
    [TransNBR]    INT          NULL,
    [TransDate]   DATE         NULL,
    [ShiftID]     INT          NULL,
    [DateFrom]    DATE         NULL,
    [DateUpTo]    DATE         NULL,
    [Remark]      VARCHAR (50) NULL,
    [UserId]      VARCHAR (30) NULL,
    [Create_date] DATE         NULL,
    [MachineID]   VARCHAR (50) NULL
);

