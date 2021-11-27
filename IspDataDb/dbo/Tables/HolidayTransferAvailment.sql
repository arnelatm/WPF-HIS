CREATE TABLE [dbo].[HolidayTransferAvailment] (
    [IdNo]                INT        IDENTITY (1, 1) NOT NULL,
    [HolidayTransferIdNo] INT        NULL,
    [DateAvailed]         DATE       NULL,
    [EnteredBy]           INT        NULL,
    [DateCreated]         DATE       CONSTRAINT [DF_HolidayTransferAvailment_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]       ROWVERSION NULL,
    CONSTRAINT [PK_HolidayTransferAvailment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



