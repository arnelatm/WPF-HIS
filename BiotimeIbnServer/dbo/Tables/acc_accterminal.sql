CREATE TABLE [dbo].[acc_accterminal] (
    [id]                  INT            IDENTITY (1, 1) NOT NULL,
    [create_time]         DATETIME2 (7)  NULL,
    [create_user]         NVARCHAR (150) NULL,
    [change_time]         DATETIME2 (7)  NULL,
    [change_user]         NVARCHAR (150) NULL,
    [status]              SMALLINT       NOT NULL,
    [door_name]           NVARCHAR (50)  NULL,
    [door_lock_delay]     INT            NOT NULL,
    [door_sensor_delay]   INT            NOT NULL,
    [door_sensor_type]    SMALLINT       NOT NULL,
    [door_alarm_delay]    INT            NOT NULL,
    [retry_times]         SMALLINT       NOT NULL,
    [valid_holiday]       SMALLINT       NOT NULL,
    [nc_time_period]      INT            NOT NULL,
    [no_time_period]      INT            NOT NULL,
    [speaker_alarm]       SMALLINT       NOT NULL,
    [duress_fun_on]       SMALLINT       NOT NULL,
    [alarm_1_1]           SMALLINT       NOT NULL,
    [alarm_1_n]           SMALLINT       NOT NULL,
    [alarm_password]      SMALLINT       NOT NULL,
    [duress_alarm_delay]  INT            NOT NULL,
    [anti_passback_mode]  SMALLINT       NOT NULL,
    [anti_door_direction] SMALLINT       NOT NULL,
    [verify_mode_485]     SMALLINT       NOT NULL,
    [push_time]           DATETIME2 (7)  NULL,
    [terminal_id]         INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [acc_accterminal_terminal_id_fc92cce2_fk_iclock_terminal_id] FOREIGN KEY ([terminal_id]) REFERENCES [dbo].[iclock_terminal] ([id])
);


GO
CREATE NONCLUSTERED INDEX [acc_accterminal_terminal_id_fc92cce2]
    ON [dbo].[acc_accterminal]([terminal_id] ASC);

