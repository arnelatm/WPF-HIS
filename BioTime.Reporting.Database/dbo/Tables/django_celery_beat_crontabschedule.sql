CREATE TABLE [dbo].[django_celery_beat_crontabschedule] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [minute]        NVARCHAR (240) NOT NULL,
    [hour]          NVARCHAR (96)  NOT NULL,
    [day_of_week]   NVARCHAR (64)  NOT NULL,
    [day_of_month]  NVARCHAR (124) NOT NULL,
    [month_of_year] NVARCHAR (64)  NOT NULL,
    [timezone]      NVARCHAR (63)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

