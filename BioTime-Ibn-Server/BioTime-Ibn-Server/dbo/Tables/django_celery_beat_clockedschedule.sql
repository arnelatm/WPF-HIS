CREATE TABLE [dbo].[django_celery_beat_clockedschedule] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [clocked_time] DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

