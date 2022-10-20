CREATE TABLE [dbo].[PatientTokenBookingDetailsxxxx] (
    [Trans_key]   INT          NULL,
    [BranchID]    VARCHAR (3)  NULL,
    [TokenNo]     NUMERIC (10) NOT NULL,
    [TokenDate]   VARCHAR (10) NOT NULL,
    [DoctorID]    VARCHAR (15) NOT NULL,
    [BookingType] INT          NOT NULL,
    [BookingTime] VARCHAR (15) NULL,
    [DoctorShift] INT          NULL
);

