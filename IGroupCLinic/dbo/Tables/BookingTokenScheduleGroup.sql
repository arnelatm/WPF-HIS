CREATE TABLE [dbo].[BookingTokenScheduleGroup] (
    [Trans_Key]       INT          NULL,
    [BranchID]        VARCHAR (5)  NULL,
    [DoctorID]        VARCHAR (5)  NULL,
    [ShiftID]         INT          NULL,
    [ScheduleDate]    DATE         NULL,
    [LastTokenNo]     INT          NULL,
    [PrebookingToken] INT          NULL,
    [RegularToken]    INT          NULL,
    [UserID]          VARCHAR (50) NULL,
    [Create_Date]     DATE         NULL,
    [MachineID]       VARCHAR (50) NULL,
    [BookingNumber]   NUMERIC (10) NULL,
    [RegistrationNo]  NUMERIC (12) NULL
);

