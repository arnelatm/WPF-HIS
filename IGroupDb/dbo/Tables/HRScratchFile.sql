CREATE TABLE [dbo].[HRScratchFile] (
    [EmpID]       VARCHAR (15) NULL,
    [ShiftID]     VARCHAR (15) NULL,
    [Date]        VARCHAR (10) NULL,
    [Time1]       VARCHAR (30) NULL,
    [Time2]       VARCHAR (30) NULL,
    [Time3]       VARCHAR (30) NULL,
    [Time4]       VARCHAR (30) NULL,
    [ShiftDirect] INT          NULL,
    [OverNight]   INT          NULL,
    [PrevDay]     INT          NULL,
    [NextDay]     INT          NULL,
    [IndexKey]    BIGINT       NULL
);

