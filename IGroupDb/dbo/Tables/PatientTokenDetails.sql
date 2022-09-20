CREATE TABLE [dbo].[PatientTokenDetails] (
    [TokenNo]     NUMERIC (10) NOT NULL,
    [TokenDate]   VARCHAR (10) NOT NULL,
    [DoctorID]    VARCHAR (15) NOT NULL,
    [BookingType] INT          NOT NULL,
    [BookingTime] VARCHAR (15) NULL,
    [DoctorShift] INT          NULL
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_PatientTokenDetails]
    ON [dbo].[PatientTokenDetails]([TokenNo] ASC, [DoctorID] ASC, [TokenDate] ASC);

