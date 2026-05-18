CREATE TABLE [dbo].[custom_att_stage_PunchAgg] (
    [emp_id]          INT           NULL,
    [att_date]        DATE          NULL,
    [punch_count]     INT           NULL,
    [first_in]        DATETIME2 (7) NULL,
    [last_out]        DATETIME2 (7) NULL,
    [first_any_punch] DATETIME2 (7) NULL,
    [last_any_punch]  DATETIME2 (7) NULL
);

