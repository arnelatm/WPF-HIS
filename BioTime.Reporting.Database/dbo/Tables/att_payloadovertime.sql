CREATE TABLE [dbo].[att_payloadovertime] (
    [uuid]       NVARCHAR (36) NOT NULL,
    [normal_wt]  INT           NULL,
    [normal_ot]  INT           NULL,
    [weekend_ot] INT           NULL,
    [holiday_ot] INT           NULL,
    [ot_lv1]     INT           NULL,
    [ot_lv2]     INT           NULL,
    [ot_lv3]     INT           NULL,
    [total_ot]   INT           NULL,
    PRIMARY KEY CLUSTERED ([uuid] ASC)
);

