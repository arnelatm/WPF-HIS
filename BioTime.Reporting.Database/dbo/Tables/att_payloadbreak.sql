CREATE TABLE [dbo].[att_payloadbreak] (
    [uuid]            NVARCHAR (36) NOT NULL,
    [break_out]       DATETIME2 (7) NULL,
    [break_in]        DATETIME2 (7) NULL,
    [duration]        INT           NULL,
    [taken]           INT           NULL,
    [actual_duration] INT           NULL,
    [early_in]        INT           NULL,
    [late_in]         INT           NULL,
    [late]            INT           NULL,
    [early_leave]     INT           NULL,
    [absent]          INT           NULL,
    [work_time]       INT           NULL,
    [overtime]        INT           NULL,
    [weekend_ot]      INT           NULL,
    [holiday_ot]      INT           NULL,
    PRIMARY KEY CLUSTERED ([uuid] ASC)
);

