CREATE TABLE [dbo].[att_leavegroupdetail] (
    [id]                      INT            IDENTITY (1, 1) NOT NULL,
    [create_time]             DATETIME2 (7)  NULL,
    [create_user]             NVARCHAR (150) NULL,
    [change_time]             DATETIME2 (7)  NULL,
    [change_user]             NVARCHAR (150) NULL,
    [status]                  SMALLINT       NOT NULL,
    [leave_type]              INT            NOT NULL,
    [allow_leave_day]         INT            NOT NULL,
    [min_leave_day]           FLOAT (53)     NOT NULL,
    [deduct_holiday_day]      SMALLINT       NOT NULL,
    [leave_entitlement]       INT            NULL,
    [leave_interval]          INT            NOT NULL,
    [leave_distribution_time] INT            NULL,
    [start_day]               NVARCHAR (5)   NOT NULL,
    [set_hire_day]            SMALLINT       NOT NULL,
    [allow_exceed_limit]      SMALLINT       NOT NULL,
    [allow_balance]           SMALLINT       NOT NULL,
    [max_balance]             INT            NULL,
    [entitlement_detail]      NVARCHAR (999) NULL,
    [leave_group_id]          INT            NOT NULL,
    [pay_code_id]             INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [att_leavegroupdetail_leave_group_id_28f69ada_fk_att_leavegroup_id] FOREIGN KEY ([leave_group_id]) REFERENCES [dbo].[att_leavegroup] ([id]),
    CONSTRAINT [att_leavegroupdetail_pay_code_id_5013b373_fk_att_paycode_id] FOREIGN KEY ([pay_code_id]) REFERENCES [dbo].[att_paycode] ([id])
);


GO
CREATE NONCLUSTERED INDEX [att_leavegroupdetail_pay_code_id_5013b373]
    ON [dbo].[att_leavegroupdetail]([pay_code_id] ASC);


GO
CREATE NONCLUSTERED INDEX [att_leavegroupdetail_leave_group_id_28f69ada]
    ON [dbo].[att_leavegroupdetail]([leave_group_id] ASC);

