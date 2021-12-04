CREATE TABLE [dbo].[HolidayAvailmentApprovalItem] (
    [IdNo]                         INT            IDENTITY (1, 1) NOT NULL,
    [HolidayAvailmentApprovalIdNo] INT            NULL,
    [HolidayAvailmentIdNo]         INT            NULL,
    [Status]                       CHAR (1)       NULL,
    [Note]                         NVARCHAR (100) NULL,
    CONSTRAINT [PK_HolidayAvailmentStatusItem] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

