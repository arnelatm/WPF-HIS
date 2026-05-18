CREATE TABLE [dbo].[django_celery_beat_intervalschedule] (
    [id]     INT           IDENTITY (1, 1) NOT NULL,
    [every]  INT           NOT NULL,
    [period] NVARCHAR (24) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

