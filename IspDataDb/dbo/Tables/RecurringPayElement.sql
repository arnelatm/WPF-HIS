CREATE TABLE [dbo].[RecurringPayElement] (
    [IdNo]            INT        IDENTITY (1, 1) NOT NULL,
    [EmployeeIdNo]    INT        NULL,
    [LimitAmount]     MONEY      NULL,
    [StartDate]       DATE       NULL,
    [EndDate]         DATE       NULL,
    [PayElementIdNo]  SMALLINT   NULL,
    [PeriodicAmount] MONEY      NULL,
    [RecurType]      CHAR (1)   NULL,
    [Active]          BIT        NULL,
    [DateCreated]     DATETIME   CONSTRAINT [DF_RecurringPayElement_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]   ROWVERSION NULL,
    CONSTRAINT [PK_RecurringPayElement] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



