CREATE TABLE [dbo].[HolidayAvailment] (
    [IdNo]                SMALLINT   IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]        INT        NULL,
    [HolidayTransferIdNo] INT        NULL,
    [EnteredBy]           INT        NULL,
    [DateCreated]         DATE       CONSTRAINT [DF_HolidayAvailment_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]       ROWVERSION NULL,
    CONSTRAINT [PK_HolidayAvailment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



