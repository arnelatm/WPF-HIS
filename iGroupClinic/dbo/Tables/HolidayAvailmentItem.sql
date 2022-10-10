CREATE TABLE [dbo].[HolidayAvailmentItem] (
    [IdNo]                 INT  IDENTITY (1, 1) NOT NULL,
    [HolidayAvailmentIdNo] INT  NULL,
    [HolidayTransferIdNo]  INT  NULL,
    [DateAvailed]          DATE NULL,
    CONSTRAINT [PK_HolidayTransferAvailment] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

