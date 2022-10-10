CREATE TABLE [dbo].[Holiday] (
    [IdNo]          SMALLINT   IDENTITY (1, 1) NOT NULL,
    [LeaveIdNo]     SMALLINT   NULL,
    [DateStart]     DATE       NULL,
    [DateEnd]       DATE       NULL,
    [EnteredBy]     INT        NULL,
    [DateCreated]   DATE       CONSTRAINT [DF_Holiday_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION NULL,
    CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

