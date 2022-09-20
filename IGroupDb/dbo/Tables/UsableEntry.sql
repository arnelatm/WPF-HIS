CREATE TABLE [dbo].[UsableEntry] (
    [AttendenceID] VARCHAR (15) NULL,
    [Date]         VARCHAR (10) NULL,
    [IndexKey]     BIGINT       NULL,
    [LoginTime]    DATETIME     NULL,
    [cnt]          INT          DEFAULT ((1)) NULL,
    [FunctionKey]  INT          NULL
);

