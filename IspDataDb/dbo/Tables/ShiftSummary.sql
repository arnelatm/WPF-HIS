CREATE TABLE [dbo].[ShiftSummary] (
    [IdNo]      INT             IDENTITY (1, 1) NOT NULL,
    [UserIdNo]  INT             NULL,
    [DateStart] DATE            NULL,
    [DateEnd]   DATE            NULL,
    [Cash]      DECIMAL (10, 2) NULL,
    [Cards]     DECIMAL (10, 2) NULL,
    CONSTRAINT [PK_ShiftSummary] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);

