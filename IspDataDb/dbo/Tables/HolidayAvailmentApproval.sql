CREATE TABLE [dbo].[HolidayAvailmentApproval] (
    [IdNo]          INT        IDENTITY (1, 1) NOT NULL,
    [EnteredBy]     INT        NULL,
    [DateCreated]   DATETIME   CONSTRAINT [DF_HolidayAvailmentStatus_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_HolidayAvailmentStatus] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

