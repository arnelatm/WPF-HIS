CREATE TABLE [dbo].[django_celery_beat_periodictask] (
    [id]              INT            IDENTITY (1, 1) NOT NULL,
    [name]            NVARCHAR (200) NOT NULL,
    [task]            NVARCHAR (200) NOT NULL,
    [args]            NVARCHAR (MAX) NOT NULL,
    [kwargs]          NVARCHAR (MAX) NOT NULL,
    [queue]           NVARCHAR (200) NULL,
    [exchange]        NVARCHAR (200) NULL,
    [routing_key]     NVARCHAR (200) NULL,
    [expires]         DATETIME2 (7)  NULL,
    [enabled]         BIT            NOT NULL,
    [last_run_at]     DATETIME2 (7)  NULL,
    [total_run_count] INT            NOT NULL,
    [date_changed]    DATETIME2 (7)  NOT NULL,
    [description]     NVARCHAR (MAX) NOT NULL,
    [crontab_id]      INT            NULL,
    [interval_id]     INT            NULL,
    [solar_id]        INT            NULL,
    [one_off]         BIT            NOT NULL,
    [start_time]      DATETIME2 (7)  NULL,
    [priority]        INT            NULL,
    [headers]         NVARCHAR (MAX) NOT NULL,
    [clocked_id]      INT            NULL,
    [expire_seconds]  INT            NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CHECK ([expire_seconds]>=(0)),
    CHECK ([priority]>=(0)),
    CONSTRAINT [django_celery_beat_periodictask_total_run_count_cf45f5ae_check] CHECK ([total_run_count]>=(0)),
    CONSTRAINT [django_celery_beat_periodictask_clocked_id_47a69f82_fk_django_celery_beat_clockedschedule_id] FOREIGN KEY ([clocked_id]) REFERENCES [dbo].[django_celery_beat_clockedschedule] ([id]),
    CONSTRAINT [django_celery_beat_periodictask_crontab_id_d3cba168_fk_django_celery_beat_crontabschedule_id] FOREIGN KEY ([crontab_id]) REFERENCES [dbo].[django_celery_beat_crontabschedule] ([id]),
    CONSTRAINT [django_celery_beat_periodictask_interval_id_a8ca27da_fk_django_celery_beat_intervalschedule_id] FOREIGN KEY ([interval_id]) REFERENCES [dbo].[django_celery_beat_intervalschedule] ([id]),
    CONSTRAINT [django_celery_beat_periodictask_solar_id_a87ce72c_fk_django_celery_beat_solarschedule_id] FOREIGN KEY ([solar_id]) REFERENCES [dbo].[django_celery_beat_solarschedule] ([id]),
    UNIQUE NONCLUSTERED ([name] ASC)
);


GO
CREATE NONCLUSTERED INDEX [django_celery_beat_periodictask_clocked_id_47a69f82]
    ON [dbo].[django_celery_beat_periodictask]([clocked_id] ASC);


GO
CREATE NONCLUSTERED INDEX [django_celery_beat_periodictask_solar_id_a87ce72c]
    ON [dbo].[django_celery_beat_periodictask]([solar_id] ASC);


GO
CREATE NONCLUSTERED INDEX [django_celery_beat_periodictask_crontab_id_d3cba168]
    ON [dbo].[django_celery_beat_periodictask]([crontab_id] ASC);


GO
CREATE NONCLUSTERED INDEX [django_celery_beat_periodictask_interval_id_a8ca27da]
    ON [dbo].[django_celery_beat_periodictask]([interval_id] ASC);

