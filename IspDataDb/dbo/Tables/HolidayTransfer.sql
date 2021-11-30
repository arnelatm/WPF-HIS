CREATE TABLE [dbo].[HolidayTransfer] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [HolidayIdNo]   INT        NULL,
    [AppliedBy]     INT        NULL,
    [DateCreated]   DATETIME   CONSTRAINT [DF_HolidayTransfer_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_HolidayTransfer] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);





