CREATE TABLE [dbo].[BookingTokenScheduleDetails] (
    [Group_Key]      INT          NULL,
    [TokenNo]        NUMERIC (10) NULL,
    [TimeFrom]       DATETIME     NULL,
    [TimeUpto]       DATETIME     NULL,
    [TokenType]      VARCHAR (50) NULL,
    [BookingNo]      NUMERIC (10) NULL,
    [Status]         VARCHAR (50) NULL,
    [RegistrationNo] NUMERIC (10) NULL,
    [BranchID]       VARCHAR (5)  NULL,
    [DoctorID]       VARCHAR (5)  NULL
);

