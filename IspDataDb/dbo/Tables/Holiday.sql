CREATE TABLE [dbo].[Holiday] (
    [IdNo]           SMALLINT       IDENTITY (1, 1) NOT NULL,
    [PayrollIdNo]    INT            NULL,
    [HolidayName]    NVARCHAR (100) NULL,
    [HolidayNameAra] NVARCHAR (100) NULL,
    [HolidayDate]    DATE           NULL,
    [DateCreated]    DATE           CONSTRAINT [DF_Holiday_DateCreated] DEFAULT (getdate()) NULL,
    [DateTimeStamp]  ROWVERSION     NULL,
    CONSTRAINT [PK_Holiday] PRIMARY KEY CLUSTERED ([IdNo] ASC)
);



