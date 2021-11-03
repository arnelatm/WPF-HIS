CREATE TABLE [dbo].[LeaveStatus] (
    [IdNo]          INT            NULL,
    [LeaveIdNo]     INT            NULL,
    [EnteredBy]     INT            NULL,
    [Status]        CHAR (1)       NULL,
    [Note]          NVARCHAR (100) NULL,
    [DateAdded]     DATETIME       NULL,
    [DateTimeStamp] ROWVERSION     NULL
);

