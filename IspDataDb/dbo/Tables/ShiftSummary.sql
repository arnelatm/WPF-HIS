CREATE TABLE [dbo].[ShiftSummary] (
    [IdNo]          INT             IDENTITY (1, 1) NOT NULL,
    [UserIdNo]      SMALLINT        NOT NULL,
    [DateStart]     DATETIME        NOT NULL,
    [DateEnd]       DATETIME        NOT NULL,
    [Cash]          DECIMAL (10, 2) NULL,
    [Cards]         DECIMAL (10, 2) NULL,
    [DateCreated]   DATETIME        CONSTRAINT [DF_ShiftSummary_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp] ROWVERSION      NULL,
    CONSTRAINT [PK_ShiftSummary] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



